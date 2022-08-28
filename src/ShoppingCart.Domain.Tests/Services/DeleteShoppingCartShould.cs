using KingShoppingCart.Domain.Contracts;
using KingShoppingCart.Domain.Entities;
using KingShoppingCart.Domain.Services;
using Moq;

namespace KingShoppingCart.Domain.Tests.Services
{
    [TestClass]
    public class DeleteShoppingCartShould
    {
        private readonly IShoppingCartService _shoppingCartService;
        private readonly Mock<IShoppingCartRepository> _shoppingCartRepositoryMock;

        public DeleteShoppingCartShould()
        {
            _shoppingCartRepositoryMock = new Mock<IShoppingCartRepository>();
            _shoppingCartService = new ShoppingCartService(_shoppingCartRepositoryMock.Object);
        }

        [TestMethod]
        public async Task WhenShoppingCartExistsThenItShouldBeDeleted()
        {
            var shoppingCart = CreateShoppingCart(1);
            _shoppingCartRepositoryMock.Setup(i => i.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(shoppingCart);

            await _shoppingCartService.DeleteAsync(shoppingCart.Id);

            _shoppingCartRepositoryMock.Verify(i => i.DeleteAsync(It.IsAny<ShoppingCart>()), Times.Once);
        }

        [TestMethod]
        public async Task WhenShoppingCartDoesNotExistThenShouldNotTryToDelete()
        {
            ShoppingCart? shoppingCart = null;
            _shoppingCartRepositoryMock.Setup(i => i.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(() => shoppingCart);

            await _shoppingCartService.DeleteAsync(1);

            _shoppingCartRepositoryMock.Verify(i => i.DeleteAsync(It.IsAny<ShoppingCart>()), Times.Never);
        }

        private ShoppingCart CreateShoppingCart(int id = 1)
        {
            return new ShoppingCart() { Id = id };
        }
    }
}
