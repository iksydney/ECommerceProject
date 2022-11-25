using Core.Entities;
using Core.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypesController : ControllerBase
    {
        private readonly IProductTypeRepository _repo;
        public ProductTypesController(IProductTypeRepository repo)
        {
            _repo = repo;
        }
        [HttpGet("GetAllProductTypes")]
        public async Task<ActionResult<List<ProductType>>> GetAllProductTypes()
        {
            var productTypes = await _repo.GetAllProductTypesAsync();
            return Ok(productTypes);
        }

        [HttpGet("GetProductType/{id}")]
        public async Task<ActionResult<ProductType>> GetAllProductTypes(int id)
        {
            var productType = await _repo.GetProductTypeById(id);
            return Ok(productType);
        }

    }
}
