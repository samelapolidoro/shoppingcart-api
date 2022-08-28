using ShoppingCart.Domain.Contracts;
using ShoppingCart.Domain.Entities;

namespace ShoppingCart.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        public async Task<Product> CreateAsync(Product product)
        {
            if (string.IsNullOrWhiteSpace(product?.Name))
                return product;

            return await _productRepository.CreateAsync(product);
        }
    }
}
