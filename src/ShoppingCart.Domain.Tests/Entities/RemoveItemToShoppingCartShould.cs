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

        private ShoppingCart CreateShoppingCart()
        {
            return new ShoppingCart() { Id = 1 };
        }

        private ShoppingCartItem CreateShoppingCartItem(int productId, decimal quantity)
        {
            return new ShoppingCartItem()
            {
                ProductId = productId,
                Quantity = quantity,
            };
        }
    }
}
