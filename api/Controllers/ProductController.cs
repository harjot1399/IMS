
using Microsoft.AspNetCore.Mvc;
using api.Dtos.Product;
using api.Mappers;
using api.Interfaces;


namespace api.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController(IProductRepository productRepository) : ControllerBase
    {
        private readonly IProductRepository _productRepository = productRepository;

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productRepository.GetProductsAsync();
            var productsDto = products.Select(x => x.ToProductDto());
            return Ok(productsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct([FromRoute] int id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product.ToProductDto());
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> CreateProduct([FromBody] CreateProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var new_product = productDto.ToProductFromCreateProductDto();
            var product = await _productRepository.CreateProductAsync(new_product);

             if (product == null)  // Handle cases where the product creation fails
            {
                return StatusCode(500, "A problem occurred while creating the product.");
            }

            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDto>> UpdateProduct(int id, UpdateProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = productDto.ToProductFromUpdateProductDto();

            var updated_product = await _productRepository.UpdateProductAsync(id, product);
            if (updated_product == null)
            {
                return NotFound();
            }
            return Ok(updated_product.ToProductDto());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var product = await _productRepository.DeleteProductAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return NoContent();
        }
        
    }
}