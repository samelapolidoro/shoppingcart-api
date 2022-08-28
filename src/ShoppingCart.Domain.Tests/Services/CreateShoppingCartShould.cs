using KingShoppingCart.Domain.Contracts;
using KingShoppingCart.Domain.Entities;
using KingShoppingCart.Domain.Services;
using Moq;

namespace KingShoppingCart.Domain.Tests.Services
{
    [TestClass]
    public class CreateShoppingCartShould
    {
        private readonly IShoppingCartService _shoppingCartService;
        private readonly Mock<IShoppingCartRepository> _shoppingCartRepositoryMock;

        public CreateShoppingCartShould()
        {
            _shoppingCartRepositoryMock = new Mock<IShoppingCartRepository>();
            _shoppingCartService = new ShoppingCartService(_shoppingCartRepositoryMock.Object);
        }

        [TestMethod]
        public async Task WhenShoppingCartIsValidThenItShouldBeCreated()
        {
            var shoppingCart = new ShoppingCart();

            await _shoppingCartService.CreateAsync(shoppingCart);

            _shoppingCartRepositoryMock.Verify(i => i.CreateAsync(It.IsAny<ShoppingCart>()), Times.Once);
        }

        [TestMethod]
        public async Task WhenShoppingCartIsInvalidThenItShouldNotBeCreated()
        {
            var shoppingCart = new ShoppingCart() { Id = 1 };

            await _shoppingCartService.CreateAsync(shoppingCart);

            _shoppingCartRepositoryMock.Verify(i => i.CreateAsync(It.IsAny<ShoppingCart>()), Times.Never);
        }
    }
}
