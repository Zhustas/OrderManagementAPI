using System.ComponentModel.DataAnnotations;

namespace OrderManagementAPI.DAL.Models;

public class OrderItem
{
    public int Id { get; set; }

    [Range(1, int.MaxValue)]
    public int ProductId { get; set; }

    [Range(1, 1000)]
    public int Quantity { get; set; }
}
