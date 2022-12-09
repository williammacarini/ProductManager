using ProductManager.Service.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductManager.Service.Services.Interfaces
{
    public interface IProductService
    {
        Task<ResultService<ProductDto>> GetByCodeAsync(int code);
        Task<ResultService<ICollection<ProductDto>>> GetAllAsync();
        Task<ResultService<ProductDto>> CreateAsync(ProductDto product);
        Task<ResultService> UpdateAsync(ProductDto product);
        Task<ResultService> DeleteAsync(int code);
    }
}
