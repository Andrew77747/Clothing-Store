using System;
using ClothingStore.Framework.PageObject.Elements;
using ClothingStore.Framework.PageObject.Pages;
using ClothingStore.Framework.Tools;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ClothingStore.Tests.Scenarios
{
    [Binding]
    public class BuyingGoodsSteps
    {
        private readonly Header _header;
        private readonly GoodPage _goodPage;
        private readonly ShoppingCart _shoppingCart;

        public BuyingGoodsSteps(WebDriverManager manager)
        {
            _header = new Header(manager);
            _goodPage = new GoodPage(manager);
            _shoppingCart = new ShoppingCart(manager);
        }

        [Given(@"I find '(.*)'")]
        public void WhenIFind(string model)
        {
            _header.SelectGood(model);
        }
        
        [When(@"I add good to shopping cart")]
        public void WhenIAddToShoppingCart()
        {
            _goodPage.ClickBuyBtnAndCheckout();
        }
        
        [Then(@"'(.*)' is in shopping cart")]
        public void ThenIsInShoppingCart(string model)
        {
            Assert.IsTrue(_shoppingCart.IsGoodAdded(model), "Good is not found!");
            _shoppingCart.CleanShoppingCart();
        }
    }
}