using Microsoft.EntityFrameworkCore;
using OrderManagementAPI.DAL.Models;

namespace OrderManagementAPI.DAL;

public class OrderManagementContext : DbContext
{
    public OrderManagementContext()
    {
    }

    public OrderManagementContext(DbContextOptions options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Order> Orders { get; set; }
}
