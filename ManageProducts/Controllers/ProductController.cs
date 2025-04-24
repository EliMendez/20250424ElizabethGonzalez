using ManageProducts.Models;
using ManageProducts.Models.Dto;
using ManageProducts.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManageProducts.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
        {
            var products = await _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            var product = await _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound($"Product ID: {id} not found.");
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> PostProduct(CreateProductDto createProductDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid product data.");

            var productDto = await _productService.AddProduct(createProductDto);
            return CreatedAtAction(nameof(GetProduct), new { id = productDto.Id }, productDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, UpdateProductDto updateProductDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid product data.");

            if (id != updateProductDto.Id)
            {
                return BadRequest("The product ID in the URL doesn't match the ID in the request body.");
            }

            var productExists = await _productService.GetProductById(id);
            if (productExists == null)
            {
                return NotFound($"Product ID: {id} not found.");
            }

            await _productService.UpdateProduct(id, updateProductDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var productExists = await _productService.GetProductById(id);
            if (productExists == null)
            {
                return NotFound($"Product ID: {id} not found.");
            }

            await _productService.DeleteProduct(id);
            return NoContent();
        }
    }
}
