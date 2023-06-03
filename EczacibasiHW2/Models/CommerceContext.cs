using Microsoft.EntityFrameworkCore;
using EczacibasiHW2.Models.Entity;

namespace EczacibasiHW2.Models
{
    public class CommerceContext : DbContext
    {

        public CommerceContext(DbContextOptions<CommerceContext> options) : base(options)
        {
        }
        public DbSet<Address> Addresses { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<User> Users { get; set; }
    }
}

