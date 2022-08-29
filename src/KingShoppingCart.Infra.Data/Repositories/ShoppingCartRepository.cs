using KingShoppingCart.Domain.Contracts;
using KingShoppingCart.Domain.Entities;

namespace KingShoppingCart.Infra.Data.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly KingShoppingCartContext _context;

        public ShoppingCartRepository(KingShoppingCartContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(ShoppingCart shoppingCart)
        {
            await _context.ShoppingCarts.AddAsync(shoppingCart);
        }

        public Task DeleteAsync(ShoppingCart shoppingCart)
        {
            throw new NotImplementedException();
        }

        public Task<ShoppingCart?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
