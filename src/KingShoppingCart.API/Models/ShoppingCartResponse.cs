namespace KingShoppingCart.API.Models
{
    public class ShoppingCartResponse
    {
        public int Id { get; set; }
        public IList<Item> Items { get; set; } = new List<Item>();
        public decimal TotalAmount { get; set; }

        public class Item
        {
            public int Id { get; set; }
            public Product Product { get; set; } = new Product();
            public decimal Quantity { get; set; }
            public decimal TotalAmount { get; set; }
        }
        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; } = string.Empty;
            public decimal Price { get; set; }
        }
    }
}
