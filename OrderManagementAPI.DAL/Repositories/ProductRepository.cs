using Microsoft.EntityFrameworkCore;
using OrderManagementAPI.DAL.Exceptions;
using OrderManagementAPI.DAL.Models;

namespace OrderManagementAPI.DAL.Repositories;

public class ProductRepository(OrderManagementContext context) : IProductRepository
{
    private readonly OrderManagementContext _context = context;

    public async Task<Product> Add(Product product)
    {
        await _context.Products.AddAsync(product);

        await _context.SaveChangesAsync();

        return product;
    }

    public async Task Delete(int id)
    {
        var product = await GetById(id);

        _context.Products.Remove(product);

        await _context.SaveChangesAsync();
    }

    public async Task<IList<Product>> GetAll()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product> GetById(int id)
    {
        return await _context.Products.FindAsync(id)
            ?? throw new ProductNotFoundException($"Product (ID = {id}) not found.");
    }
}
