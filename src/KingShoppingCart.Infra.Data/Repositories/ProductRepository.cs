using KingShoppingCart.Domain.Contracts;
using KingShoppingCart.Domain.Entities;

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
    }
}
