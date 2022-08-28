using KingShoppingCart.Domain.Contracts;
using KingShoppingCart.Domain.Entities;

namespace KingShoppingCart.Domain.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;

        public ShoppingCartService(IShoppingCartRepository shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
        }

        public async Task<ShoppingCart> CreateAsync(ShoppingCart shoppingCart)
        {
            if (shoppingCart.Id != default)
                return shoppingCart;

            return await _shoppingCartRepository.CreateAsync(shoppingCart);
        }
    }
}
