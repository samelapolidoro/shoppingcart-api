using KingShoppingCart.Domain.Contracts;
using KingShoppingCart.Domain.Entities;

namespace KingShoppingCart.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> CreateAsync(Product product)
        {
            if (string.IsNullOrWhiteSpace(product?.Name))
                return product;

            return await _productRepository.CreateAsync(product);
        }
    }
}
