using KingShoppingCart.Domain.Contracts;
using KingShoppingCart.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace KingShoppingCart.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly KingShoppingCartContext _context;

        public ProductRepository(KingShoppingCartContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Product product)
        {
           await _context.Products.AddAsync(product);
        }

        public void Delete(Product product)
        {
            _context.Products.Remove(product);
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
