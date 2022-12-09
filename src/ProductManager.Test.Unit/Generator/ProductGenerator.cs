using Bogus;
using Bogus.Extensions.Brazil;
using ProductManager.Domain.Builder;
using ProductManager.Domain.Entities;
using ProductManager.Domain.Enum;
using System.Collections.Generic;

namespace ProductManager.Test.Unit.Generator
{
    public static class ProductGenarator
    {

        public static ICollection<Product> GenerateNewProducts()
            => new Faker<Product>().CustomInstantiator(c => GenerateNewProduct()).Generate(10);

        public static Product GenerateNewProduct(int? code = null)
        {
            var faker = new Faker();
            return new ProductBuilder(new Product())
                .AddProductInfo(code ?? faker.Random.Int(1, 100), faker.Commerce.ProductDescription(), faker.Random.Enum<ProductStatus>())
                .AddProductDate(faker.Date.Past().Date, faker.Date.Future().Date)
                .AddProductProvider(faker.Random.Int(1, 100), faker.Company.CompanyName(), faker.Company.Cnpj())
                .Build();
        }
    }
}
