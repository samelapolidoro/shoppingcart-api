using KingShoppingCart.Domain.Entities;

namespace KingShoppingCart.Domain.Tests.Entities
{
    [TestClass]
    public class CalculateShoppingCartTotalAmountShould
    {
        [TestMethod]
        public void WhenAddAnItemThenTotalAmountShouldBeCalculated()
        {
            var productId = 1;
            var productPrice = 10.99m;
            var quantity = 1;

            var shoppingCart = CreateShoppingCart();
            var item = CreateShoppingCartItem(productId, productPrice, quantity);

            shoppingCart.AddItem(item);

            Assert.AreEqual(productPrice, shoppingCart.TotalAmount);
        }

        [TestMethod]
        public void WhenRemoveAnItemThenTotalAmountShouldBeCalculated()
        {
            var productId = 1;
            var productPrice = 10.99m;
            var quantity = 2;

            var shoppingCart = CreateShoppingCart();
            var item = CreateShoppingCartItem(productId, productPrice, quantity);
            shoppingCart.AddItem(item);

            shoppingCart.RemoveItem(productId, 1);

            Assert.AreEqual(productPrice, shoppingCart.TotalAmount);
        }

        [TestMethod]
        public void WhenRemoveAllItemsThenTotalAmountShouldBeZero()
        {
            var productId = 1;
            var productPrice = 10.99m;
            var quantity = 1;

            var shoppingCart = CreateShoppingCart();
            var item = CreateShoppingCartItem(productId, productPrice, quantity);
            shoppingCart.AddItem(item);

            shoppingCart.RemoveItem(productId, 1);

            Assert.AreEqual(0, shoppingCart.TotalAmount);
        }

        private ShoppingCart CreateShoppingCart(int id = 1)
        {
            return new ShoppingCart() { Id = id };
        }

        private ShoppingCartItem CreateShoppingCartItem(int productId, decimal productPrice, decimal quantity)
        {
            var item = new ShoppingCartItem() { Product = new Product() { Id = productId, Price = productPrice } };

            item.IncreaseQuantity(quantity);

            return item;
        }
    }
}
