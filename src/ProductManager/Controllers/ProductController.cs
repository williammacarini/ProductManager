using Microsoft.AspNetCore.Mvc;
using ProductManager.Service.DTOs;
using ProductManager.Service.Services.Interfaces;
using System.Threading.Tasks;

namespace ProductManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateProductAsync([FromBody] ProductDto product)
        {
            var result = await _productService.CreateAsync(product);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllProductsAsync()
        {
            var result = await _productService.GetAllAsync();
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]
        [Route("{code}")]
        public async Task<ActionResult> GetProductByIdAsync(int code)
        {
            var result = await _productService.GetByCodeAsync(code);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateProductAsync([FromBody] ProductDto product)
        {
            var result = await _productService.UpdateAsync(product);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete]
        [Route("{code}")]
        public async Task<ActionResult> DeleteProductAsync(int code)
        {
            var result = await _productService.DeleteAsync(code);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
