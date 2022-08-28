using KingShoppingCart.Domain.Entities;

namespace KingShoppingCart.Domain.Tests.Entities
{
    [TestClass]
    public class CalculateShoppingCartItemTotalAmountShould
    {
        [TestMethod]
        public void WhenIncreaseQuantityThenTotalAmountShouldBeCalculated()
        {
            var productId = 1;
            var productPrice = 10.99m;
            var quantity = 0;
            
            var item = CreateShoppingCartItem(productId, productPrice, quantity);

            item.IncreaseQuantity(1);

            Assert.AreEqual(productPrice, item.TotalAmount);
        }

        [TestMethod]
        public void WhenDecreaseQuantityThenTotalAmountShouldBeCalculated()
        {
            var productId = 1;
            var productPrice = 10.99m;
            var quantity = 2;

            var item = CreateShoppingCartItem(productId, productPrice, quantity);

            item.DecreaseQuantity(1);

            Assert.AreEqual(productPrice, item.TotalAmount);
        }

        private ShoppingCartItem CreateShoppingCartItem(int productId, decimal productPrice, decimal quantity)
        {
            return new ShoppingCartItem()
            {
                Product = new Product() { Id = productId, Price = productPrice },
                Quantity = quantity,
            };
        }
    }
}
