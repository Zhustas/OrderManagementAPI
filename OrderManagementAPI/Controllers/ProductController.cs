using Microsoft.AspNetCore.Mvc;
using OrderManagementAPI.DAL.Models;
using OrderManagementAPI.DAL.Repositories;

namespace OrderManagementAPI.Controllers;

[Route("api/products")]
[ApiController]
public class ProductController(IProductRepository productRepository) : ControllerBase
{
    private readonly IProductRepository _productRepository = productRepository;

    [HttpGet]
    public async Task<ActionResult<IList<Product>>> GetAll()
    {
        var products = await _productRepository.GetAll();

        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetById(int id)
    {
        var product = await _productRepository.GetById(id);

        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult<Product>> Add([FromBody] Product product)
    {
        this.HandleParametersCheck(nameof(product));

        var addedProduct = await _productRepository.Add(product);

        return Ok(addedProduct);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _productRepository.Delete(id);

        return Ok($"Product (ID={id}) deleted.");
    }
}
