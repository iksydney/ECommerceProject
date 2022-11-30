using API.DTO;
using API.Errors;
using AutoMapper;
using Core.Entities;
using Core.Interface;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> _repository;
        private readonly IMapper _map;

        public ProductsController(IGenericRepository<Product> repository, IMapper map)
        {
            _repository = repository;
            _map = map;
        }

        [HttpGet("GetAllProducts")]
        public async Task<ActionResult<IReadOnlyList<ProductViewModel>>> GetProducts()
        {
            var spec = new ProductsWithTypesAndBrandSpecification();

            var products = await _repository.LIstAsync(spec);
            return Ok(_map.Map<IReadOnlyList<Product>, IReadOnlyList<ProductViewModel>>(products));
        }

        //[ProducesResponseType(statusCode:StatusCode.Status200OK )]
        [HttpGet("GetAProduct/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductViewModel>> GetProduct(int id)
        {
            var spec = new ProductsWithTypesAndBrandSpecification(id);

            var product = await _repository.GetEntityWithSpec(spec);

            if(product == null)
            {
                return NotFound(new ApiResponse(404));
            }
            return _map.Map<Product, ProductViewModel>(product);
        }

    }
}