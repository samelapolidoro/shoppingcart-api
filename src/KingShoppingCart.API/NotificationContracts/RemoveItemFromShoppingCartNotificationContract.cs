using Flunt.Notifications;
using Flunt.Validations;
using KingShoppingCart.API.Models;

namespace KingShoppingCart.API.NotificationContracts
{
    public class RemoveItemFromShoppingCartNotificationContract : Contract<Notification>
    {
        public RemoveItemFromShoppingCartNotificationContract(RemoveItemFromShoppingCartRequest request)
        {
            Requires()

                .IsGreaterThan(request.Quantity, 0, nameof(request.Quantity));
        }
    }
}
