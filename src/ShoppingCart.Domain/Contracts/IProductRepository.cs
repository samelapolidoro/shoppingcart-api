using KingShoppingCart.Domain.Entities;

namespace KingShoppingCart.Domain.Contracts
{
    public interface IProductRepository
    {
        Task<Product> CreateAsync(Product product);
    }
}
