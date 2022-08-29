using KingShoppingCart.Domain.Entities;

namespace KingShoppingCart.Domain.Contracts
{
    public interface IProductRepository
    {
        Task CreateAsync(Product product);
        void Delete(Product product);
        Task<Product?> GetByIdAsync(int productId);
        Task SaveChangesAsync();
    }
}
