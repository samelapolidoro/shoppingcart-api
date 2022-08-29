namespace KingShoppingCart.Domain.Entities
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public IList<ShoppingCartItem> Items { get; private set; } = new List<ShoppingCartItem>();
        public decimal TotalAmount { get; private set; }


        public void AddItem(ShoppingCartItem item)
        {
            if (item.Product?.Id == 0 || item.Quantity <= 0)
                return;

            var itemInShoppingCart = GetItem(item.Product!.Id);

            if (itemInShoppingCart == null)
                Items.Add(item);
            else
                itemInShoppingCart.IncreaseQuantity(item.Quantity);

            CalculateTotalAmount();
        }

        public void AddItem(Product product, decimal quantity)
        {
            var shoppingCartItem = new ShoppingCartItem() { Product = product };

            shoppingCartItem.IncreaseQuantity(quantity);

            this.AddItem(shoppingCartItem);
        }

        public void RemoveItem(int productId, decimal quantity)
        {
            var itemInShoppingCart = GetItem(productId);
            if (itemInShoppingCart == null)
                return;

            itemInShoppingCart.DecreaseQuantity(quantity);

            if (itemInShoppingCart.Quantity == 0)
                Items.Remove(itemInShoppingCart);

            CalculateTotalAmount();
        }

        private void CalculateTotalAmount()
        {
            TotalAmount = Items.Sum(i => i.TotalAmount);
        }

        private ShoppingCartItem? GetItem(int productId)
        {
            return Items.FirstOrDefault(x => x.Product.Id == productId);
        }
    }
}
