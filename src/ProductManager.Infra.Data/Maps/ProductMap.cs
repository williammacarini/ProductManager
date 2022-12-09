using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductManager.Domain.Entities;

namespace ProductManager.Infra.Data.Maps
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("product");
            builder.HasKey(b => b.Code);
            builder.Property(b => b.Code).HasColumnName("code").UseIdentityColumn().ValueGeneratedOnAdd();
            builder.Property(b => b.Status).HasColumnName("status");
            builder.Property(b => b.Description).HasColumnName("description");
            builder.Property(b => b.FabricationDate).HasColumnName("fabrication_date");
            builder.Property(b => b.ExpireDate).HasColumnName("expire_date");
            builder.Property(b => b.ProviderCode).HasColumnName("provider_code");
            builder.Property(b => b.ProviderDescription).HasColumnName("provider_description");
            builder.Property(b => b.CNPJ).HasColumnName("cnpj");
        }
    }
}
