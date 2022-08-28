using ShoppingCart.Domain.Entities;

namespace ShoppingCart.Domain.Contracts
{
    public interface IProductService
    {
        Task<Product> CreateAsync(Product product);
    }
}
