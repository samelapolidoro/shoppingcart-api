using Flunt.Notifications;
using Flunt.Validations;
using KingShoppingCart.API.Models;

namespace KingShoppingCart.API.NotificationContracts
{
    public class AddItemToShoppingCartNotificationContract : Contract<Notification>
    {
        private readonly string _notFoundResource = "Not found";

        public AddItemToShoppingCartNotificationContract(AddItemToShoppingCartRequest request)
        {
            Requires()

                .IsGreaterThan(request.Quantity, 0, nameof(request.Quantity))
                .IsNotNull(request.ShoppingCart, nameof(request.ShoppingCartId), _notFoundResource)
                .IsNotNull(request.Product, nameof(request.ProductId), _notFoundResource);
        }
    }
}
