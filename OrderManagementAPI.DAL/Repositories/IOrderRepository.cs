using OrderManagementAPI.DAL.Models;

namespace OrderManagementAPI.DAL.Repositories;

public interface IOrderRepository
{
    public Task<Order> Add(Order order);

    public Task<IList<Order>> GetAll();

    public Task<Order> GetById(int id);
}
