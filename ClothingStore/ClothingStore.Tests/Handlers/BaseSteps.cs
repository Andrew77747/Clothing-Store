using ClothingStore.Framework.PageObject.Elements;
using ClothingStore.Framework.PageObject.Pages;
using ClothingStore.Framework.Tools;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ClothingStore.Tests.Handlers
{
    [Binding]
    public class BaseSteps
    {
        private readonly MainPage _mainPage;
        private readonly Header _header;
        private readonly AuthorizationPage _authorizationPage;
        private readonly ShoppingCart _shoppingCart;

        public BaseSteps(WebDriverManager manager, ConfigurationManager configuration)
        {
            _mainPage = new MainPage(manager, configuration.GetSettings());
            _authorizationPage = new AuthorizationPage(manager, configuration.GetSettings());
            _header = new Header(manager);
            _shoppingCart = new ShoppingCart(manager);
        }

        [Given(@"I'm on the main page")]
        public void GivenIMOnTheMainPage()
        {
            _mainPage.OpenPage();
        }

        [Then(@"I clean shopping cart")]
        public void GivenICleanShoppingCart()
        {
            _header.GoToShoppingCart();
            _shoppingCart.CleanShoppingCart();
        }

        [When(@"I choose '(.*)' in catalog")]
        public void WhenIChooseInCatalog(string name)
        {
            _header.ChooseCatalogItem(name);
        }

        [When(@"I go to shopping cart")]
        public void WhenIGoToShoppingCart()
        {
            _header.GoToShoppingCart();
        }

        [When(@"I hover on '(.*)' in side catalog menu")]
        public void WhenIHoverOnInSideCatalogMenu(string text)
        {
            _header.HoverMouseOnSideMenuElement(text);
        }

        [When(@"I click '(.*)' menu item")]
        [Given(@"I click '(.*)' menu item")]
        public void GivenIClickMenuItem(string item)
        {
            _header.ClickTopMenuItem(item);
        }

    }
}