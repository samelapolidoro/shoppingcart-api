using KingShoppingCart.Domain.Entities;

namespace KingShoppingCart.Domain.Contracts
{
    public interface IProductService
    {
        Task<Product> CreateAsync(Product product);
    }
}
