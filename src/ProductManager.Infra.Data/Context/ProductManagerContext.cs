using Microsoft.EntityFrameworkCore;
using ProductManager.Domain.Entities;

namespace ProductManager.Infra.Data.Context
{
    public class ProductManagerContext : DbContext
    {
        public ProductManagerContext(DbContextOptions<ProductManagerContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductManagerContext).Assembly);
        }
    }
}
