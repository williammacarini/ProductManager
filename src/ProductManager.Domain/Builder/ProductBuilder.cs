using ProductManager.Domain.Entities;
using ProductManager.Domain.Enum;
using System;

namespace ProductManager.Domain.Builder
{
    public class ProductBuilder
    {
        private Product _product;

        public ProductBuilder(Product product)
        {
            _product = product;
        }

        public Product Build() => _product;

        public void Clear() => new Product();

        public ProductBuilder AddProductInfo(int code, string description, ProductStatus status)
        {
            _product.SetProductInfo(code, description, status);
            return this;
        }

        public ProductBuilder AddProductDate(DateTime fabrication, DateTime expired)
        {
            _product.SetProductDate(fabrication, expired);
            return this;
        }

        public ProductBuilder AddProductProvider(int providerCode, string providerDescription, string cnpj)
        {
            _product.SetProductProvider(providerCode, providerDescription, cnpj);
            return this;
        }
    }
}
