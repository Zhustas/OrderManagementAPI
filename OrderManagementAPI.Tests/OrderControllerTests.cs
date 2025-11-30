using Microsoft.AspNetCore.Mvc;
using Moq;
using OrderManagementAPI.Controllers;
using OrderManagementAPI.DAL;
using OrderManagementAPI.DAL.Models;
using OrderManagementAPI.DAL.Repositories;

namespace OrderManagementAPI.Tests;

[TestFixture]
public class OrderControllerTests
{
    private readonly Mock<OrderRepository> _orderRepository;
    private readonly OrderController _orderController;

    public OrderControllerTests()
    {
        var context = new Mock<OrderManagementContext>();
        _orderRepository = new Mock<OrderRepository>(context.Object);
        _orderController = new(_orderRepository.Object);
    }

    [Test]
    public async Task ShouldAddOrder()
    {
        var order = new Order()
        {
            CustomerName = "Google",
            Items = [
                new()
                {
                    ProductId = 1,
                    Quantity = 5
                }
            ],
        };

        _orderRepository
            .Setup(or => or.Add(It.IsAny<Order>()))
            .Returns(async (Order o) =>
            {
                order.Id = 1;
                order.Items[0].Id = 1;
                order.TotalPrice = 99.95m;

                return await Task.FromResult(order);
            });

        var result = await _orderController.Add(order);
        
        Assert.That(result.Result, Is.TypeOf<OkObjectResult>());

        var okResult = result.Result as OkObjectResult;
        Assert.That(okResult?.Value, Is.TypeOf<Order>());

        var addedOrder = okResult.Value as Order;
        Assert.That(addedOrder?.Id, Is.EqualTo(1));
    }
}
