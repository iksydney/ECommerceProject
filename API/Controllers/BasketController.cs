using API.DTO;
using AutoMapper;
using Core.Entities;
using Core.Interface;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : BaseApiController
    {
        private readonly IBasketRepository _repo;
        private readonly IMapper _map;
        public BasketController(IBasketRepository repo, IMapper map)
        {
            _repo = repo;
            _map = map;
        }
        [HttpGet]
        public async Task<ActionResult<CustomerBasket>> GetCustomerBasketById(string id)
        {
            var basket = await _repo.GetBasketsAsync(id);
            return Ok(basket ?? new CustomerBasket(id));
        }
        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasketDto basket)
        {
            var customerBasket = _map.Map<CustomerBasketDto, CustomerBasket>(basket);
            var updatedBasket = await _repo.CreateUpdateBasketAsync(customerBasket);
            return Ok(updatedBasket);
        }
        [HttpDelete]
        public async Task DeleteBasket(string basketId)
        {
            await _repo.DeleteBasketAsync(basketId);

        }
    }
}
