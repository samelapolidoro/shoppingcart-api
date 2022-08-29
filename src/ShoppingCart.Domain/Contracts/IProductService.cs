using Flunt.Notifications;
using KingShoppingCart.Domain.Entities;

namespace KingShoppingCart.Domain.Contracts
{
    public interface IProductService
    {
        Task<(Product, IReadOnlyCollection<Notification>)> CreateAsync(Product product);
        Task DeleteByIdAsync(int productId);
        Task<Product?> GetByIdAsync(int productId);
    }
}
