using Moq;
using Moq.EntityFrameworkCore;
using OrderManagementAPI.DAL;
using OrderManagementAPI.DAL.Exceptions;
using OrderManagementAPI.DAL.Models;
using OrderManagementAPI.DAL.Repositories;

namespace OrderManagementAPI.Tests;

[TestFixture]
public class OrderRepositoryTests
{
    private readonly Mock<OrderManagementContext> _context;
    private readonly OrderRepository _orderRepository;

    public OrderRepositoryTests()
    {
        _context = new();
        _orderRepository = new(_context.Object);
    }

    [Test]
    public async Task ShouldThrowProductNotFoundExceptionWhenNoProductExists()
    {
        var product = new Product()
        {
            Id = 1,
            Name = "Laptop",
            Price = 989.99m,
        };
        var order = new Order()
        {
            CustomerName = "Microsoft",
            Items = [
                new() {
                    ProductId = 5,
                    Quantity = 1
                }
            ],
        };

        _context.Setup(c => c.Products).ReturnsDbSet([product]);

        Assert.ThrowsAsync<ProductNotFoundException>(async () =>
        {
            _ = await _orderRepository.Add(order);
        });
    }
}
