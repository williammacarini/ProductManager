using FluentAssertions;
using Moq;
using ProductManager.Domain.Entities;
using ProductManager.Domain.Repositories;
using ProductManager.Service.Services;
using ProductManager.Test.Unit.Generator;
using ProductManger.Infra.CrossCutting.IoC;
using Xunit;

namespace ProductManager.Test.Unit.Service
{
    [Trait("Category", "Service Test")]
    public class ServiceTest
    {
        private readonly Mock<IProductRepository> _repository;
        private readonly ProductService _productService;

        public ServiceTest()
        {
            _repository = new Mock<IProductRepository>();

            var mapper = RegisterDependencies.GetMappers();

            _productService = new ProductService(_repository.Object, mapper);
        }

        [Fact(DisplayName = "Product Service - Create New Product Successfully")]
        public void CreateAsync_CreateNewProductSuccessfully()
        {
            // Arrange
            var productDto = ProductDtoGenarator.GenerateNewProductDto();

            _repository.Setup(x => x.GetByCodeAsync(It.IsAny<int>())).ReturnsAsync(value: null);

            // Act
            var result = _productService.CreateAsync(productDto);

            // Assert
            _repository.Verify(v => v.CreateAsync(It.IsAny<Product>()), Times.Once);
            result.IsCompletedSuccessfully.Should().BeTrue();
        }

        [Fact(DisplayName = "Product Service - Delete Product Successfully")]
        public void DeleteAsync_DeleteProductSuccessfully()
        {
            // Arrange
            var product = ProductGenarator.GenerateNewProduct();

            _repository.Setup(x => x.GetByCodeAsync(It.IsAny<int>())).ReturnsAsync(product);

            // Act
            var result = _productService.DeleteAsync(product.Code);

            // Assert
            _repository.Verify(v => v.DeleteAsync(It.IsAny<int>()), Times.Once);
            result.IsCompletedSuccessfully.Should().BeTrue();
        }

        [Fact(DisplayName = "Product Service - Get All Product Successfully")]
        public void GetAllAsync_GetAllProductSuccessfully()
        {
            // Arrange
            var products = ProductGenarator.GenerateNewProducts();

            _repository.Setup(x => x.GetAllAsync()).ReturnsAsync(products);

            // Act
            var result = _productService.GetAllAsync();

            // Assert
            _repository.Verify(v => v.GetAllAsync(), Times.Once);
            result.IsCompletedSuccessfully.Should().BeTrue();
        }

        [Fact(DisplayName = "Product Service - Get By Product Code Successfully")]
        public void GetByCodeAsync_GetByProductCodeSuccessfully()
        {
            // Arrange
            var product = ProductGenarator.GenerateNewProduct();

            _repository.Setup(x => x.GetByCodeAsync(It.IsAny<int>())).ReturnsAsync(product);

            // Act
            var result = _productService.GetByCodeAsync(product.Code);

            // Assert
            _repository.Verify(v => v.GetByCodeAsync(It.IsAny<int>()), Times.Once);
            result.IsCompletedSuccessfully.Should().BeTrue();
        }

        [Fact(DisplayName = "Product Service - Update Product Successfully")]
        public void UpdateAsync_UpdateProductSuccessfully()
        {
            // Arrange
            var productDto = ProductDtoGenarator.GenerateNewProductDto();
            var product = ProductGenarator.GenerateNewProduct(productDto.Code);

            _repository.Setup(x => x.GetByCodeAsync(It.IsAny<int>())).ReturnsAsync(product);

            // Act
            var result = _productService.UpdateAsync(productDto);

            // Assert
            _repository.Verify(v => v.UpdateAsync(It.IsAny<Product>()), Times.Once);
            result.IsCompletedSuccessfully.Should().BeTrue();
        }
    }
}