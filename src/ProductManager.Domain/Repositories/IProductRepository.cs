using ProductManager.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductManager.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetByCodeAsync(int code);
        Task<ICollection<Product>> GetAllAsync();
        Task CreateAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(int code);
    }
}
