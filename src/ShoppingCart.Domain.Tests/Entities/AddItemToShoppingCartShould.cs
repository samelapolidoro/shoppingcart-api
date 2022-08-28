using KingShoppingCart.Domain.Entities;

namespace KingShoppingCart.Domain.Tests.Entities
{
    [TestClass]
    public class AddItemToShoppingCartShould
    {
        private readonly ShoppingCart _shoppingCart;

        public AddItemToShoppingCartShould()
        {
            _shoppingCart = new ShoppingCart() { Id = 1 };
        }

        [TestMethod]
        public void WhenItemIsValidThenItShouldBeAdded()
        {
            var item = new ShoppingCartItem()
            {
                ProductId = 1,
                Quantity = 1,
            };

            _shoppingCart.AddItem(item);

            Assert.AreEqual(1, _shoppingCart.Items.Count());
        }

        [TestMethod]
        [DataRow(0, 1, DisplayName = "ProductId is invalid")]
        [DataRow(1, 0, DisplayName = "Quantity is invalid")]
        public void WhenItemIsInvalidThenItShouldNotBeAdded(int productId, double quantity)
        {
            var item = new ShoppingCartItem()
            {
                ProductId = productId,
                Quantity = (decimal)quantity,
            };

            _shoppingCart.AddItem(item);

            Assert.AreEqual(0, _shoppingCart.Items.Count());
        }
    }
}
