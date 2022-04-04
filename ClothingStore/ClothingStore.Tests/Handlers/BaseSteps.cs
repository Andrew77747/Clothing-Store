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

        [Given(@"I go to the authorization page")]
        public void GivenIGoToTheAuthorizationPage()
        {
            _header.ClickLogin();
        }

        [Given(@"I login")]
        [When(@"I login")]
        [Then(@"I login")]
        public void WhenILogin()
        {
            //_authorizationPage.Login();
            Assert.IsTrue(_authorizationPage.Login(), "User is not logged!");
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
    }
}