using blazor_mysql2.Shared;
using Microsoft.EntityFrameworkCore;

namespace blazor_mysql2.Server
{
     public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}