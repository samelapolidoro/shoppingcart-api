using KingShoppingCart.Domain.Entities;
using System.Text.Json.Serialization;

namespace KingShoppingCart.API.Models
{
    public class AddItemToShoppingCartRequest
    {
        public int ShoppingCartId { get; set; }
        public int ProductId { get; set; }
        public decimal Quantity { get; set; }

        [JsonIgnore]
        public Product? Product { get; set; }
        [JsonIgnore]
        public ShoppingCart? ShoppingCart { get; set; }
    }
}
