using KingShoppingCart.Domain.Contracts;
using KingShoppingCart.Domain.Entities;
using Microsoft.EntityFrameworkCore;

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

        public void Delete(ShoppingCart shoppingCart)
        {
            _context.ShoppingCarts.Remove(shoppingCart);
        }

        public async Task<ShoppingCart?> GetByIdAsync(int id)
        {
            return await _context.ShoppingCarts
                                 .Include(i => i.Items).ThenInclude(i => i.Product)
                                 .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(ShoppingCart shoppingCart)
        {
            _context.ShoppingCarts.Update(shoppingCart);
        }
    }
}
