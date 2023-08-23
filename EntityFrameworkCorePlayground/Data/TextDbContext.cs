using EntityFrameworkCorePlayground.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCorePlayground.Data
{
    public class TextDbContext : DbContext
    {
        public TextDbContext(DbContextOptions<TextDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
