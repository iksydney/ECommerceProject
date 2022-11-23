using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _store;
        public ProductsController(ApplicationDbContext store)
        {
            _store = store;
        }
        [HttpGet("GetAllProducts")]
        public async Task<ActionResult<List<Product>>> GetProducts(){
            var products  = await _store.Products.ToListAsync();
            return products;
        }

        //[ProducesResponseType(statusCode:StatusCode.Status200OK )]
        [HttpGet("GetAProduct/{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id){
            var product = await _store.Products.FindAsync(id);
            return Ok(product);
        }
        
    }
}