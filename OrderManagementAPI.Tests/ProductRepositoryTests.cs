using Moq;
using Moq.EntityFrameworkCore;
using OrderManagementAPI.DAL;
using OrderManagementAPI.DAL.Models;
using OrderManagementAPI.DAL.Repositories;

namespace OrderManagementAPI.Tests;

[TestFixture]
public class ProductRepositoryTests
{
    private readonly Mock<OrderManagementContext> _context;
    private readonly ProductRepository _productRepository;

    public ProductRepositoryTests()
    {
        _context = new();
        _productRepository = new(_context.Object);
    }

    [Test]
    public async Task ShouldReturnAllProducts()
    {
        var products = new List<Product>
        {
            new()
            {
                Id = 1,
                Name = "TV",
                Price = 599.99m
            },
            new()
            {
                Id = 2,
                Name = "Book",
                Price = 10.99m
            }
        };

        _context.Setup(c => c.Products).ReturnsDbSet(products);

        var result = await _productRepository.GetAll();

        Assert.That(result, Has.Count.EqualTo(2));
    }
}
