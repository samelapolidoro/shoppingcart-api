using KingShoppingCart.Domain.Contracts;
using KingShoppingCart.Domain.Entities;
using KingShoppingCart.Domain.Services;
using Moq;

namespace KingShoppingCart.Domain.Tests.Services
{
    [TestClass]
    public class CreateProductShould
    {
        private readonly IProductService _productService;
        private readonly Mock<IProductRepository> _productRepositoryMock;

        public CreateProductShould()
        {
            _productRepositoryMock = new Mock<IProductRepository>();

            _productService = new ProductService(_productRepositoryMock.Object);
        }

        [TestMethod]
        public async Task WhenProductIsValidThenProductShouldBeCreated()
        {
            var product = new Product() { Name = "Product A", Price = 10.99m };

            await _productService.CreateAsync(product);

            _productRepositoryMock.Verify(i => i.CreateAsync(It.IsAny<Product>()), Times.Once());
        }

        [TestMethod]
        [DataRow("", DisplayName = "Product name is empty")]
        [DataRow(null, DisplayName = "Product name is null")]
        public async Task WhenProductNameIsInValidThenProductShouldNotBeCreated(string productName)
        {
            var product = new Product() { Name = productName, Price = 10.99m };

            await _productService.CreateAsync(product);

            _productRepositoryMock.Verify(i => i.CreateAsync(It.IsAny<Product>()), Times.Never());
        }
    }
}
