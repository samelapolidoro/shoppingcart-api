namespace KingShoppingCart.Domain.Entities
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public IList<ShoppingCartItem> Items { get; private set; } = new List<ShoppingCartItem>();
        public decimal TotalAmount { get; set; }


        public void AddItem(ShoppingCartItem item)
        {
            if (item.ProductId == default || item.Quantity <= 0)
                return;

            Items.Add(item);
        }
    }
}
