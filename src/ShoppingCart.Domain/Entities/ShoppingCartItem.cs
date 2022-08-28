namespace KingShoppingCart.Domain.Entities
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }
        public Product Product { get; set; } = new Product();
        public decimal Quantity { get; set; }
        public decimal TotalAmount { get; private set; }

        public void IncreaseQuantity(decimal quantity)
        {
            Quantity += quantity;

            CalculateTotalAmount();
        }

        public void DecreaseQuantity(decimal quantity)
        {
            Quantity -= quantity;

            if (Quantity < 0) Quantity = 0;

            CalculateTotalAmount();
        }

        private void CalculateTotalAmount()
        {
            TotalAmount = Product.Price * Quantity;
        }
    }
}
