using Core.Entities;
using Core.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductBrandController : ControllerBase
    {
        private readonly IGenericRepository<ProductBrand> _repo;
        public ProductBrandController(IGenericRepository<ProductBrand> repo)
        {
            _repo = repo;
        }

        [HttpGet("GetAllProductBrand")]
        public async Task<ActionResult<List<ProductBrand>>> GetAllProductBrands()
        {
            var productBrands = await _repo.ListAllAsync();
            return Ok(productBrands);
        }

        [HttpGet("GetAProductBrandById/{id}")]
        public async Task<ActionResult<List<ProductBrand>>> GetAProductBrandById(int id)
        {
            var productBrand = await _repo.GetByIdAsync(id);
            return Ok(productBrand);
        }
    }
}
