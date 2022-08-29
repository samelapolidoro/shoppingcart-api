using Flunt.Notifications;
using KingShoppingCart.Domain.Entities;

namespace KingShoppingCart.Domain.Contracts
{
    public interface IProductService
    {
        Task<(Product, IReadOnlyCollection<Notification>)> CreateAsync(Product product);
        Task DeleteAsync(Product product);
        Task<Product?> GetByIdAsync(int productId);
    }
}
