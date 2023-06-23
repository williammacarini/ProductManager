using AutoMapper;
using ProductManager.Domain.Entities;
using ProductManager.Domain.Repositories;
using ProductManager.Service.DTOs;
using ProductManager.Service.DTOs.Validations;
using ProductManager.Service.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductManager.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<ProductDto>> CreateAsync(ProductDto product)
        {
            if (product is null)
                return ResultService.Fail<ProductDto>("Produto deve ser informado");

            if (product.ExpireDate is not null && (product.FabricationDate > product.ExpireDate || product.FabricationDate == product.ExpireDate))
                return ResultService.Fail<ProductDto>("Fabrication date must be less than Expire date");

            var result = new ProductDtoValidator().Validate(product);

            if (!result.IsValid)
                return ResultService.RequestError<ProductDto>("Validação!", result);

            var savedProduct = await _productRepository.GetByCodeAsync(product.Code);

            if (savedProduct is not null)
                return ResultService.Fail<ProductDto>("Product code already exist!");

            var map = _mapper.Map<Product>(product);

            await _productRepository.CreateAsync(map);

            return ResultService.Ok(_mapper.Map<ProductDto>(product));
        }

        public async Task<ResultService> DeleteAsync(int code)
        {
            var savedProduct = await _productRepository.GetByCodeAsync(code);

            if (savedProduct is null)
                return ResultService.Fail("Produto não localizado!");

            await _productRepository.DeleteAsync(code);
            return ResultService.Ok("Produto inativo!");
        }

        public async Task<ResultService<ICollection<ProductDto>>> GetAllAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return ResultService.Ok(_mapper.Map<ICollection<ProductDto>>(products));
        }

        public async Task<ResultService<ProductDto>> GetByCodeAsync(int code)
        {
            var product = await _productRepository.GetByCodeAsync(code);

            if (product is null)
                return ResultService.Fail<ProductDto>("Produto não localizado!");

            return ResultService.Ok(_mapper.Map<ProductDto>(product));
        }

        public async Task<ResultService> UpdateAsync(ProductDto product)
        {
            if (product is null)
                return ResultService.Fail("Produto deve ser informado!");

            var validation = new ProductDtoValidator().Validate(product);

            if (product.ExpireDate is not null && (product.FabricationDate > product.ExpireDate || product.FabricationDate == product.ExpireDate))
                return ResultService.Fail<ProductDto>("Fabrication date must be less than Expire date");

            if (!validation.IsValid)
                return ResultService.RequestError("Problemas na validação!", validation);

            var productSaved = await _productRepository.GetByCodeAsync(product.Code);

            if (productSaved == null)
                return ResultService.Fail("Produto não encontrado!");

            if (productSaved.Code == product.Code)
            {
                productSaved = _mapper.Map<ProductDto, Product>(product, productSaved);
                await _productRepository.UpdateAsync(productSaved);

                return ResultService.Ok("Produto editado!");
            }
            else
            {
                return ResultService.Fail("Product code must be the same!");
            }
        }
    }
}
