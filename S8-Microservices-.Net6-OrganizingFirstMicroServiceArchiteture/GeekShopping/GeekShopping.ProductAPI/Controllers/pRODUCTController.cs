using GeekShopping.ProductAPI.Model.Data.DTOs;
using GeekShopping.ProductAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProductAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository ?? throw new
                ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> FindAll()
        {
            var products = await _repository.FindAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> FindById(Guid id)
        {
            var product = await _repository.FindById(id);

            if (product == null)
                return NotFound();
            else
                return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDTO>> Create(ProductDTO productDTO)
        {
            if (productDTO == null)
                return BadRequest();

            var product = await _repository.Create(productDTO);
            return Ok(product);
        }
        
        [HttpPut]
        public async Task<ActionResult<ProductDTO>> Update(ProductDTO productDTO)
        {
            if (productDTO == null)
                return BadRequest();

            var product = await _repository.Update(productDTO);
            return Ok(product);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid id)
        {
            var status = await _repository.Delete(id);

            if (!status)
                return BadRequest();
            else
                return Ok(status);
        }
    }
}
