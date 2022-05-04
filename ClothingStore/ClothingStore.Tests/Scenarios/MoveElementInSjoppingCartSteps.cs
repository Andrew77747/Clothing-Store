using System;
using System.Threading;
using ClothingStore.Framework.PageObject.Pages;
using ClothingStore.Framework.Tools;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ClothingStore.Tests.Scenarios
{
    [Binding]
    public class MoveElementInStoppingCartSteps
    {

        private readonly CatalogPage _catalogPage;
        private readonly ShoppingCart _shoppingCart;

        public MoveElementInStoppingCartSteps(IWebDriverManager manager)
        {
            _catalogPage = new CatalogPage(manager);
            _shoppingCart = new ShoppingCart(manager);
        }

        [When(@"I click buy button in catalog")]
        public void WhenIClickBuyButtonInCatalog()
        {
            _catalogPage.ClickBuyBtn();
        }

        [When(@"I move the first card below")]
        public void WhenIMoveTheFirstCardBelow()
        {
            _shoppingCart.MoveElementBelow();
            Thread.Sleep(3000);
        }

    }
}
