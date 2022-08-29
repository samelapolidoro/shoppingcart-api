using KingShoppingCart.Domain.Entities;

namespace KingShoppingCart.Domain.Contracts
{
    public interface IProductRepository
    {
        Task CreateAsync(Product product);
        Task<Product?> GetByIdAsync(int productId);
        Task SaveChangesAsync();
    }
}
