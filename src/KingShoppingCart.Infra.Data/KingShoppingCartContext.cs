using KingShoppingCart.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace KingShoppingCart.Infra.Data
{
    public class KingShoppingCartContext : DbContext
    {
        public KingShoppingCartContext(DbContextOptions options) : base(options)
        {
        }

        internal DbSet<Product> Products => Set<Product>();
        internal DbSet<ShoppingCart> ShoppingCarts => Set<ShoppingCart>();
    }
}
