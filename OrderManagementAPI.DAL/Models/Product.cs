using System.ComponentModel.DataAnnotations;

namespace OrderManagementAPI.DAL.Models;

public class Product
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    [Range(typeof(decimal), "0.01", "9999.99")]
    public decimal Price { get; set; }
}
