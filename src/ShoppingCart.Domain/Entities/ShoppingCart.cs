namespace KingShoppingCart.Domain.Entities
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public IList<ShoppingCartItem> Items { get; private set; } = new List<ShoppingCartItem>();
        public decimal TotalAmount { get; set; }


        public void AddItem(ShoppingCartItem item)
        {
            if (item.Product?.Id == 0 || item.Quantity <= 0)
                return;

            var itemInShoppingCart = GetItem(item.Product!.Id);
            if (itemInShoppingCart == null)
            {
                Items.Add(item);
                return;
            }

            itemInShoppingCart.IncreaseQuantity(item.Quantity);
        }

        public void RemoveItem(int productId, decimal quantity)
        {
            var itemInShoppingCart = GetItem(productId);
            if (itemInShoppingCart == null)
                return;

            itemInShoppingCart.DecreaseQuantity(quantity);

            if (itemInShoppingCart.Quantity == 0)
                Items.Remove(itemInShoppingCart);
        }

        private ShoppingCartItem? GetItem(int productId)
        {
            return Items.FirstOrDefault(x => x.Product.Id == productId);
        }
    }
}
