﻿using KingShoppingCart.Domain.Entities;

namespace KingShoppingCart.Domain.Tests.Entities
{
    [TestClass]
    public class AddItemToShoppingCartShould
    {
        [TestMethod]
        public void WhenItemIsValidThenItShouldBeAdded()
        {
            var shoppingCart = CreateShoppingCart();
            var item = CreateShoppingCartItem(1, 1);

            shoppingCart.AddItem(item);

            Assert.AreEqual(1, shoppingCart.Items.Count());
        }

        [TestMethod]
        [DataRow(0, 1, DisplayName = "ProductId is invalid")]
        [DataRow(1, 0, DisplayName = "Quantity is invalid")]
        public void WhenItemIsInvalidThenItShouldNotBeAdded(int productId, double quantity)
        {
            var shoppingCart = CreateShoppingCart();
            var item = CreateShoppingCartItem(productId, (decimal)quantity);

            shoppingCart.AddItem(item);

            Assert.AreEqual(0, shoppingCart.Items.Count());
        }

        [TestMethod]
        public void WhenItemAlreadyExistsInTheShoppingCartThenIncreaseQuantity()
        {
            var shoppingCart = CreateShoppingCart();
            var item = CreateShoppingCartItem(1, 1);
            shoppingCart.AddItem(item);

            var itemWithSameProductId = CreateShoppingCartItem(1, 1);
            shoppingCart.AddItem(itemWithSameProductId);

            Assert.AreEqual(1, shoppingCart.Items.Count());
            Assert.AreEqual(2, shoppingCart.Items.First().Quantity);
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
