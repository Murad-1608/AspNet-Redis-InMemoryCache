using ExampleApi.Models;

namespace ExampleApi.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAsync();
        Task<Product> GetById(int id);
        Task Create(Product product);
    }
}
