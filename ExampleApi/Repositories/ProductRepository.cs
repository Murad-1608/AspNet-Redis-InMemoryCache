using ExampleApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ExampleApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Create(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAsync()
        {
            var values = await _context.Products.ToListAsync();
            return values;
        }

        public async Task<Product> GetById(int id)
        {
            var values = await _context.Products.FindAsync(id);
            return values!;
        }
    }
}
