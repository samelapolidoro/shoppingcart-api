using Flunt.Validations;
using KingShoppingCart.Domain.Entities;

namespace KingShoppingCart.Domain.NotificationContracts
{
    public class CreateShoppingCartNotificationContract : Contract<ShoppingCart>
    {
        public CreateShoppingCartNotificationContract(ShoppingCart shoppingCart)
        {
            Requires()

                .AreEquals(shoppingCart.Id, (int)default, nameof(shoppingCart.Id));
        }
    }
}
