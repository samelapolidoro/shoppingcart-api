using Flunt.Notifications;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace KingShoppingCart.API.Extensions
{
    public static class ModelStateDictionaryExtensions
    {
        public static ModelStateDictionary AddErrorsFromNofifications(this ModelStateDictionary modelState, 
                                                                     IEnumerable<Notification> notifications)
        {
            foreach (var item in notifications)
            {
                modelState.AddModelError(item.Key, item.Message);
            }

            return modelState;
        }
    }
}
