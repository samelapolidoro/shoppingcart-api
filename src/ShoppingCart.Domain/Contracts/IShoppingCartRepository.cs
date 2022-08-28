using KingShoppingCart.Domain.Entities;

namespace KingShoppingCart.Domain.Contracts
{
    public interface IShoppingCartRepository
    {
        Task<ShoppingCart> CreateAsync(ShoppingCart shoppingCart);
    }
}
