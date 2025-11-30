using Microsoft.EntityFrameworkCore;
using OrderManagementAPI.DAL.Exceptions;
using OrderManagementAPI.DAL.Models;

namespace OrderManagementAPI.DAL.Repositories;

public class OrderRepository(OrderManagementContext context) : IOrderRepository
{
    private readonly OrderManagementContext _context = context;

    public virtual async Task<Order> Add(Order order)
    {
        await HandleAllProductsExistCheck(order);

        order.TotalPrice = order.Items
            .Join(_context.Products, o => o.ProductId, p => p.Id, (o, p) => p.Price * o.Quantity)
            .Sum();
        
        await _context.Orders.AddAsync(order);

        await _context.SaveChangesAsync();

        return order;
    }

    public async Task<IList<Order>> GetAll()
    {
        return await _context.Orders
            .Include(o => o.Items)
            .ToListAsync();
    }

    public async Task<Order> GetById(int id)
    {
        return await _context.Orders
            .Include(o => o.Items)
            .FirstOrDefaultAsync(o => o.Id == id)
            ?? throw new OrderNotFoundException($"Order (ID = {id}) not found.");
    }

    private async Task HandleAllProductsExistCheck(Order order)
    {
        var productIds = order.Items.Select(i => i.ProductId).ToList();
        
        if (!await _context.Products.AnyAsync() || !await _context.Products.AllAsync(p => productIds.Contains(p.Id)))
        {
            throw new ProductNotFoundException("Product not found.");
        }
    }
}
