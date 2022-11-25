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
        private readonly IProductBrandRepository _repo;
        public ProductBrandController(IProductBrandRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("GetAllProductBrand")]
        public async Task<ActionResult<List<ProductBrand>>> GetAllProductBrands()
        {
            var productBrands = await _repo.GetAllProductBrandsAsync();
            return Ok(productBrands);
        }

        [HttpGet("GetAProductBrandById/{id}")]
        public async Task<ActionResult<List<ProductBrand>>> GetAProductBrandById(int id)
        {
            var productBrand = await _repo.GetProductBrandByIdAsync(id);
            return Ok(productBrand);
        }
    }
}
