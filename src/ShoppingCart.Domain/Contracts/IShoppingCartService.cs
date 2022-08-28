using KingShoppingCart.Domain.Entities;

namespace KingShoppingCart.Domain.Contracts
{
    public interface IShoppingCartService
    {
        Task<ShoppingCart> CreateAsync(ShoppingCart shoppingCart);
    }
}
