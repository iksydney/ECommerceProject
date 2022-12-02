using API.DTO;
using API.Errors;
using API.Helpers;
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
        public async Task<ActionResult<IReadOnlyList<Pagination<ProductViewModel>>>> GetProducts([FromQuery]ProductSpecParams productParams)
        {
            var spec = new ProductsWithTypesAndBrandSpecification(productParams);
            var countSpec = new ProductWithFiltersForCountSpecification(productParams);
            var totalItems = await _repository.CountAsync(countSpec);
            var products = await _repository.ListAsync(spec);

            var data = _map.Map<IReadOnlyList<Product>, IReadOnlyList<ProductViewModel>>(products);

            return Ok(new Pagination<ProductViewModel>(productParams.PageIndex, productParams.PageSize, totalItems, data));
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