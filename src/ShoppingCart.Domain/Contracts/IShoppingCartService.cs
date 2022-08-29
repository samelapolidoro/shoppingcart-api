using Flunt.Notifications;
using KingShoppingCart.Domain.Entities;

namespace KingShoppingCart.Domain.Contracts
{
    public interface IShoppingCartService
    {
        Task<(ShoppingCart, IReadOnlyCollection<Notification>)> CreateAsync(ShoppingCart shoppingCart);
        Task DeleteByIdAsync(int shoppingCartId);
        Task<ShoppingCart?> GetByIdAsync(int shoppingCartId);
        Task UpdateAsync(ShoppingCart shoppingCart);
    }
}
