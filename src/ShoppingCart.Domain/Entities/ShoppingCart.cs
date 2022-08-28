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

            var itemInShoppingCart = GetItem(item.ProductId);
            if (itemInShoppingCart == null)
            {
                Items.Add(item);
                return;
            }

            IncreaseItemQuantity(itemInShoppingCart, item.Quantity);
        }

        private ShoppingCartItem? GetItem(int productId)
        {
            return Items.FirstOrDefault(x => x.ProductId == productId);
        }

        private void IncreaseItemQuantity(ShoppingCartItem item, decimal quantity)
        {
            item.Quantity += quantity;
        }
    }
}
