using Microsoft.EntityFrameworkCore;

namespace ExampleApi.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Honda", Price = 12000 },
                new Product { Id = 2, Name = "Mercedes", Price = 25000 },
                new Product { Id = 2, Name = "BMW", Price = 24000 }
                );
        }
    }
}
