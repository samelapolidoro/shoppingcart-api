using AutoMapper;
using KingShoppingCart.API.Extensions;
using KingShoppingCart.API.Models;
using KingShoppingCart.Domain.Contracts;
using KingShoppingCart.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KingShoppingCart.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IMapper _mapper;

        public ShoppingCartController(IShoppingCartService shoppingCartService, IMapper mapper)
        {
            _shoppingCartService = shoppingCartService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        { 
            var (shoppingCart, notifications) = await _shoppingCartService.CreateAsync(new ShoppingCart());

            if (notifications.Any())
                return ValidationProblem(ModelState.AddErrorsFromNofifications(notifications));

            return StatusCode(StatusCodes.Status201Created, _mapper.Map<CreateShoppingCartResponse>(shoppingCart));
        }
    }
}
