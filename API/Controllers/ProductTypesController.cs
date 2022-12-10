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
        private readonly IGenericRepository<ProductType> _repository;
        public ProductTypesController(IGenericRepository<ProductType> repository)
        {
            _repository = repository;
        }

        [HttpGet("GetAllProductTypes")]
        public async Task<ActionResult<List<ProductType>>> GetAllProductTypes()
        {
            var productTypes = await _repository.ListAllAsync();
            return Ok(productTypes);
        }

        [HttpGet("GetProductType/{id}")]
        public async Task<ActionResult<ProductType>> GetAllProductTypes(int id)
        {
            var productType = await _repository.GetByIdAsync(id);
            return Ok(productType);
        }

    }
}
