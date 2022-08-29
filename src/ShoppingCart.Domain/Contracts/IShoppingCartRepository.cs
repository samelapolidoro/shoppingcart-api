using KingShoppingCart.Domain.Entities;

namespace KingShoppingCart.Domain.Contracts
{
    public interface IShoppingCartRepository
    {
        Task CreateAsync(ShoppingCart shoppingCart);
        Task<ShoppingCart?> GetByIdAsync(int id);
        Task DeleteAsync(ShoppingCart shoppingCart);
        Task SaveChangesAsync();
    }
}
