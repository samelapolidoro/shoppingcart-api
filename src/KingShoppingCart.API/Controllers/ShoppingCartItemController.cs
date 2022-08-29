using AutoMapper;
using KingShoppingCart.API.Extensions;
using KingShoppingCart.API.Models;
using KingShoppingCart.API.NotificationContracts;
using KingShoppingCart.Domain.Contracts;
using KingShoppingCart.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KingShoppingCart.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartItemController : ControllerBase
    {
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ShoppingCartItemController(IMapper mapper,
                                          IShoppingCartService shoppingCartService,
                                          IProductService productService)
        {
            _shoppingCartService = shoppingCartService;
            _productService = productService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> PostItem(AddItemToShoppingCartRequest request)
        {
            request.ShoppingCart = await _shoppingCartService.GetByIdAsync(request.ShoppingCartId);
            request.Product = await _productService.GetByIdAsync(request.ProductId);

            var contract = new AddItemToShoppingCartNotificationContract(request);
            if (!contract.IsValid)
                return ValidationProblem(ModelState.AddErrorsFromNofifications(contract.Notifications));

            request.ShoppingCart!.AddItem(request.Product!, request.Quantity);

            await _shoppingCartService.UpdateAsync(request.ShoppingCart!);

            return StatusCode(StatusCodes.Status201Created, _mapper.Map<ShoppingCartResponse>(request.ShoppingCart!));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteItem(RemoveItemFromShoppingCartRequest request)
        {
            var shoppingCart = await _shoppingCartService.GetByIdAsync(request.ShoppingCartId);
            if (shoppingCart == null)
                return NoContent();

            var contract = new RemoveItemFromShoppingCartNotificationContract(request);
            if (!contract.IsValid)
                return ValidationProblem(ModelState.AddErrorsFromNofifications(contract.Notifications));

            var item = shoppingCart.Items.FirstOrDefault(i => i.Product.Id == request.ProductId);
            if (item != null)
            {
                shoppingCart.RemoveItem(request.ProductId, request.Quantity);
                await _shoppingCartService.UpdateAsync(shoppingCart);
            }

            return NoContent();
        }
    }
}
