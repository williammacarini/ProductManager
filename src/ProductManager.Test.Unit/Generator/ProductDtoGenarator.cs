using Bogus;
using Bogus.Extensions.Brazil;
using ProductManager.Service.DTOs;
using ProductManager.Service.DTOs.Enum;
using System.Collections.Generic;

namespace ProductManager.Test.Unit.Generator
{
    public static class ProductDtoGenarator
    {
        public static ProductDto GenerateNewProductDto(int? code = null)
            => new Faker<ProductDto>()
            .CustomInstantiator
            (c => new ProductDto
            {
                Code = code ?? c.Random.Int(1, 1000000),
                Description = c.Commerce.ProductDescription(),
                Status = c.Random.Enum<ProductStatusDto>(),
                FabricationDate = c.Date.Past().Date,
                ExpireDate = c.Date.Future().Date,
                ProviderCode = c.Random.Int(1, 10000000),
                ProviderDescription = c.Company.CompanyName(),
                CNPJ = c.Company.Cnpj()
            });

        public static IEnumerable<ProductDto> GenerateNewProductsDto()
            => new Faker<ProductDto>().CustomInstantiator(c => GenerateNewProductDto()).Generate(10);
    }
}
