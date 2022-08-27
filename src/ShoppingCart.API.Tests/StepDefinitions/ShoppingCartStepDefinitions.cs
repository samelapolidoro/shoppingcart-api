using System;
using TechTalk.SpecFlow;

namespace ShoppingCart.API.Tests.StepDefinitions
{
    [Binding]
    public class ShoppingCartStepDefinitions
    {
        [Given(@"there are products with the following data")]
        public void GivenThereAreProductsWithTheFollowingData(Table table)
        {
            throw new PendingStepException();
        }

        [Given(@"a new shopping cart is created")]
        public void GivenANewShoppingCartIsCreated()
        {
            throw new PendingStepException();
        }

        [When(@"add (.*) item of product (.*) to the shopping cart")]
        public void WhenAddItemOfProductToTheShoppingCart(decimal quantity, int productId)
        {
            throw new PendingStepException();
        }

        [Then(@"the shopping cart total amount should be (.*)")]
        public void ThenTheShoppingCartTotalAmountShouldBe(decimal expectedTotalAmount)
        {
            throw new PendingStepException();
        }

        [Given(@"a new shopping cart is created with the following data")]
        public void GivenANewShoppingCartIsCreatedWithTheFollowingData(Table table)
        {
            throw new PendingStepException();
        }

        [When(@"remove (.*) item of product (.*) from the shopping cart")]
        public void WhenRemoveItemOfProductFromTheShoppingCart(decimal quantity, int productId)
        {
            throw new PendingStepException();
        }

        [When(@"delete the shopping cart")]
        public void WhenDeleteTheShoppingCart()
        {
            throw new PendingStepException();
        }

        [Then(@"the shopping cart should not exist")]
        public void ThenTheShoppingCartShouldNotExist()
        {
            throw new PendingStepException();
        }
    }
}
