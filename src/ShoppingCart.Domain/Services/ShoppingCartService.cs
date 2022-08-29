using Flunt.Notifications;
using KingShoppingCart.Domain.Contracts;
using KingShoppingCart.Domain.Entities;
using KingShoppingCart.Domain.NotificationContracts;

namespace KingShoppingCart.Domain.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;

        public ShoppingCartService(IShoppingCartRepository shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
        }

        public async Task<(ShoppingCart, IReadOnlyCollection<Notification>)> CreateAsync(ShoppingCart shoppingCart)
        {
            var contract = new CreateShoppingCartNotificationContract(shoppingCart);
            if (!contract.IsValid) return (shoppingCart, contract.Notifications);

            await _shoppingCartRepository.CreateAsync(shoppingCart);
            await _shoppingCartRepository.SaveChangesAsync();

            return (shoppingCart, new List<Notification>());
        }

        public async Task DeleteByIdAsync(int shoppingCartId)
        {
            var shoppingCart = await _shoppingCartRepository.GetByIdAsync(shoppingCartId);

            if (shoppingCart == null)
                return;

            _shoppingCartRepository.Delete(shoppingCart);
            await _shoppingCartRepository.SaveChangesAsync();
        }

        public async Task<ShoppingCart?> GetByIdAsync(int shoppingCartId)
        {
            return await _shoppingCartRepository.GetByIdAsync(shoppingCartId);
        }

        public async Task UpdateAsync(ShoppingCart shoppingCart)
        {
            _shoppingCartRepository.Update(shoppingCart);
            await _shoppingCartRepository.SaveChangesAsync();
        }
    }
}
