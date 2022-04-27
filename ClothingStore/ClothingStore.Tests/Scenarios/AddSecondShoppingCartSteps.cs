using System;
using ClothingStore.Framework.PageObject.Elements;
using ClothingStore.Framework.PageObject.Pages;
using ClothingStore.Framework.Tools;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ClothingStore.Tests.Scenarios
{
    [Binding]
    public class AddSecondShoppingCartSteps
    {
        private readonly ShoppingCart _shoppingCart;
        private readonly Header _header;
        private readonly CatalogPage _catalogPage;
        private string _actualShoppingCartName;

        public AddSecondShoppingCartSteps(WebDriverManager manager)
        {
            _shoppingCart = new ShoppingCart(manager);
            _header = new Header(manager);
            _catalogPage = new CatalogPage(manager);
        }

        [Then(@"I delete all added shopping carts")]
        public void ThenIDeleteAllAddedShoppingCarts()
        {
            _header.GoToShoppingCart();
            _shoppingCart.DeleteAllAddedShoppingCarts();
        }

        [Given(@"I create new shopping cart '(.*)'")]
        public void GivenICreateNewShoppingCart(string name)
        {
            _actualShoppingCartName = name;
            _shoppingCart.AddNewShoppingCart(name);
        }


        [When(@"I choose basic shopping cart")]
        public void WhenIChooseBasicShoppingCart()
        {
            _shoppingCart.ChooseBasicShoppingCart();
        }
        
        [When(@"I click buy button in cart on catalog page")]
        public void WhenIClickBuyButtonInCartOnCatalogPage()
        {
            _catalogPage.ClickBuyBtn();
        }
        
        [When(@"I clear basic shopping cart")]
        public void WhenIClearBasicShoppingCart()
        {

        }
        
        [When(@"I switch on second shopping cart")]
        public void WhenISwitchOnSecondShoppingCart()
        {

        }
        
        [When(@"I delete second shopping cart")]
        public void WhenIDeleteSecondShoppingCart()
        {

        }
        
        [Then(@"I see shopping cart I created")]
        public void ThenISeeShoppingCartICreated()
        {
            Assert.IsTrue(_shoppingCart.IsSecondShoppingCartCreated(), "Second shopping cart is not created");
            Assert.AreEqual(_actualShoppingCartName, _shoppingCart.GetSecondShoppingCartName(), "Names of shopping carts are not equal");
            Assert.IsTrue(_shoppingCart.IsShoppingCartNamesAreEqual(), "Names of shopping carts are not equal");
        }
        
        [Then(@"I see good I added in basic shopping cart")]
        public void ThenISeeGoodIAddedInBasicShoppingCart()
        {

        }
        
        [Then(@"I see good I added in second shopping cart")]
        public void ThenISeeGoodIAddedInSecondShoppingCart()
        {

        }
        
        [Then(@"I see only one basic shopping cart")]
        public void ThenISeeOnlyOneBasicShoppingCart()
        {

        }
    }
}
