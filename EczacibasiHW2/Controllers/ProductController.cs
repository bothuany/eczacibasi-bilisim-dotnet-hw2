using EczacibasiHW2.Models;
using EczacibasiHW2.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace EczacibasiHW2.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly ProductRepository _productRepository;

        public ProductController(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult GetAllProducts(int page, int pageSize)
        {
            return Ok(_productRepository.GetAll(page, pageSize));
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            Product product = _productRepository.GetById(id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpGet("search")]
        public IActionResult Search(string name, int? categoryId, double? minPrice)
        {
            return Ok(_productRepository.Search(name, categoryId, minPrice));
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody] Product product)
        {
             _productRepository.Add(product);

            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] Product product)
        {
            _productRepository.Update(id, product);
            
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            _productRepository.Delete(id);
            return NoContent();
        }
    }
}
