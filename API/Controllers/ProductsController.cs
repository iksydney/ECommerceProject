using Core.Entities;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repo;
        public ProductsController(IProductRepository repo)
        {
            _repo = repo;
        }
        [HttpGet("GetAllProducts")]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _repo.GetAllProductsAsync();
            return Ok(products);
        }

        //[ProducesResponseType(statusCode:StatusCode.Status200OK )]
        [HttpGet("GetAProduct/{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _repo.GetProductByIdAsync(id);
            return Ok(product);
        }

    }
}