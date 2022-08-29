using Flunt.Notifications;
using KingShoppingCart.Domain.Contracts;
using KingShoppingCart.Domain.Entities;
using KingShoppingCart.Domain.NotificationContracts;

namespace KingShoppingCart.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<(Product, IReadOnlyCollection<Notification>)> CreateAsync(Product product)
        {
            var contract = new CreateProductNotificationContract(product);
            if (!contract.IsValid) return (product, contract.Notifications);

            await _productRepository.CreateAsync(product);
            await _productRepository.SaveChangesAsync();

            return (product, new List<Notification>());
        }

        public async Task<Product?> GetByIdAsync(int productId)
        {
            return await _productRepository.GetByIdAsync(productId);
        }
    }
}
