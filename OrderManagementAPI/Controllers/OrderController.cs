using Microsoft.AspNetCore.Mvc;
using OrderManagementAPI.DAL.Models;
using OrderManagementAPI.DAL.Repositories;

namespace OrderManagementAPI.Controllers;

[Route("api/orders")]
[ApiController]
public class OrderController(IOrderRepository orderRepository) : ControllerBase
{
    private readonly IOrderRepository _orderRepository = orderRepository;

    [HttpGet]
    public async Task<ActionResult<IList<Order>>> GetAll()
    {
        var orders = await _orderRepository.GetAll();

        return Ok(orders);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Order>> GetById(int id)
    {
        var order = await _orderRepository.GetById(id);

        return Ok(order);
    }

    [HttpPost]
    public async Task<ActionResult<Order>> Add([FromBody] Order order)
    {
        this.HandleParametersCheck(nameof(order));

        var addedOrder = await _orderRepository.Add(order);

        return Ok(addedOrder);
    }
}
