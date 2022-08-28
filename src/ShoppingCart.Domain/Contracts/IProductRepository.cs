using ShoppingCart.Domain.Entities;

namespace ShoppingCart.Domain.Contracts
{
    public interface IProductRepository
    {
        Task<Product> CreateAsync(Product product);
    }
}
