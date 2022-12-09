using Microsoft.EntityFrameworkCore;
using ProductManager.Domain.Entities;
using ProductManager.Domain.Repositories;
using ProductManager.Infra.Data.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductManager.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductManagerContext _context;

        public ProductRepository(ProductManagerContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Product product)
        {
            await _context.Product.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int code)
        {
            var product = await _context.Product.FirstOrDefaultAsync(w => w.Code == code);
            product.SetExpireDate(System.DateTime.Now);
            _context.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Product>> GetAllAsync()
            => await _context.Product.ToListAsync();

        public async Task<Product> GetByCodeAsync(int code)
            => await _context.Product.FirstOrDefaultAsync(f => f.Code == code);

        public async Task UpdateAsync(Product product)
        {
            _context.Product.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}
