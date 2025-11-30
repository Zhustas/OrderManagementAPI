using System.ComponentModel.DataAnnotations;

namespace OrderManagementAPI.DAL.Models;

public class Order
{
    public int Id { get; set; }

    [Required]
    public string CustomerName { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [MinLength(1)]
    public List<OrderItem> Items { get; set; } = [];

    public decimal TotalPrice { get; set; }
}
