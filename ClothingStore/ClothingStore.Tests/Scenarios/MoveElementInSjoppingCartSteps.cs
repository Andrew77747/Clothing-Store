using System;
using System.Collections.Generic;
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
        private List<string> _listOfGoodsBeforeMoving = new();

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

        [When(@"I add current location of cards")]
        public void WhenIAddCurrentLocationOfCards()
        {
            _listOfGoodsBeforeMoving = _shoppingCart.ListOfElementsMoving();
        }


        [When(@"I move the first card below")]
        public void WhenIMoveTheFirstCardBelow()
        {
            _shoppingCart.MoveElementBelow();
        }

        [Then(@"I see two cards in shopping cart")]
        public void ThenISeeTwoCardsInShoppingCart()
        {
            Assert.AreEqual(2, _shoppingCart.GetElementsCount(), "Counts must be equal");
        }


        [Then(@"I see cards changed places")]
        public void ThenISeeCardsChangedPlaces()
        {
            Assert.AreNotEqual(_listOfGoodsBeforeMoving, _shoppingCart.ListOfElementsMoving(), "Lists of cards are equal");
        }

        [When(@"I move the second card higher")]
        public void ThenIMoveTheSecondCardHigher()
        {
            _shoppingCart.MoveElementHigher();
        }
    }
}