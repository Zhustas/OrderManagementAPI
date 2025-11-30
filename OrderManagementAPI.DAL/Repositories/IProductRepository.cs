using OrderManagementAPI.DAL.Models;

namespace OrderManagementAPI.DAL.Repositories;

public interface IProductRepository
{
    public Task<Product> Add(Product product);

    public Task<IList<Product>> GetAll();

    public Task<Product> GetById(int id);

    public Task Delete(int id);
}
