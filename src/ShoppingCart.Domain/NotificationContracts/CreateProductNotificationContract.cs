using Flunt.Validations;
using KingShoppingCart.Domain.Entities;

namespace KingShoppingCart.Domain.NotificationContracts
{
    public class CreateProductNotificationContract : Contract<Product>
    {
        public CreateProductNotificationContract(Product product)
        {
            Requires()
                
                .IsNotNullOrWhiteSpace(product.Name, nameof(product.Name));
        }
    }
}
