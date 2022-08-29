namespace KingShoppingCart.API.Models
{
    public class RemoveItemFromShoppingCartRequest
    {
        public int ShoppingCartId { get; set; }
        public int ProductId { get; set; }
        public decimal Quantity { get; set; }
    }
}
