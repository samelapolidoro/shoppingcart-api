using KingShoppingCart.Domain.Entities;

namespace KingShoppingCart.Domain.Tests.Entities
{
    [TestClass]
    public class RemoveItemToShoppingCartShould
    {
        [TestMethod]
        public void WhenItemAlreadyExistsInTheShoppingCartThenShouldBeRemoved()
        {
            var shoppingCart = CreateShoppingCart();
            var item = CreateShoppingCartItem(1, 1);
            shoppingCart.AddItem(item);

            shoppingCart.RemoveItem(1, 1);

            Assert.AreEqual(0, shoppingCart.Items.Count());
        }

        [TestMethod]
        public void WhenQuantityToRemoveIsLessThanItemQuantityThenShouldDecreaseQuantity()
        {
            var shoppingCart = CreateShoppingCart();
            var item = CreateShoppingCartItem(1, 2);
            shoppingCart.AddItem(item);

            shoppingCart.RemoveItem(1, 1);

            Assert.AreEqual(1, shoppingCart.Items.Count());
            Assert.AreEqual(1, shoppingCart.Items.First().Quantity);
        }

        private ShoppingCart CreateShoppingCart(int id = 1)
        {
            return new ShoppingCart() { Id = id };
        }

        private ShoppingCartItem CreateShoppingCartItem(int productId, decimal quantity)
        {
            return new ShoppingCartItem()
            {
                Product = new Product() { Id = productId },
                Quantity = quantity,
            };
        }
    }
}
