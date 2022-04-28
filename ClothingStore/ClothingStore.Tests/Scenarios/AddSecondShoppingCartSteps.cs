using System;
using System.Threading;
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
        private string _newCreatedShoppingCartName;
        private string _actualGoodName;
        private string _basicShoppingCartName = "Основная";

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
            _newCreatedShoppingCartName = name;
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
            _actualGoodName = _catalogPage.ClickBuyBtnAndReturnGoodName();
        }
        
        [When(@"I clear basic shopping cart")]
        public void WhenIClearBasicShoppingCart()
        {
            _shoppingCart.ClearShoppingCartWithBasicCheckbox();
        }
        
        [When(@"I switch on second shopping cart")]
        public void WhenISwitchOnSecondShoppingCart()
        {
            _shoppingCart.ChooseSecondShoppingCart();
        }
        
        [When(@"I delete second shopping cart")]
        public void WhenIDeleteSecondShoppingCart()
        {
            _shoppingCart.DeleteAllAddedShoppingCarts();
        }
        
        [Then(@"I see shopping cart I created")]
        public void ThenISeeShoppingCartICreated()
        {
            Assert.IsTrue(_shoppingCart.IsSecondShoppingCartCreated(), "Second shopping cart is not created");
            Assert.AreEqual(_newCreatedShoppingCartName, _shoppingCart.GetSecondShoppingCartName(), "Names of shopping carts are not equal");
            Assert.IsTrue(_shoppingCart.IsShoppingCartNamesAreEqual(), "Names of shopping carts are not equal");
        }
        
        [Then(@"I see good I added in basic shopping cart")]
        public void ThenISeeGoodIAddedInBasicShoppingCart()
        {
            Assert.IsTrue(_shoppingCart.IsGoodAdded(_actualGoodName), "Names are not equal");
            Assert.AreEqual(_basicShoppingCartName, _shoppingCart.GetActiveShoppingCartName(), "Names of shopping carts are not equal");
        }
        
        [Then(@"I see good I added in second shopping cart")]
        public void ThenISeeGoodIAddedInSecondShoppingCart()
        {
            Assert.IsTrue(_shoppingCart.IsGoodAdded(_actualGoodName), "Names are not equal");
            Assert.AreEqual(_newCreatedShoppingCartName, _shoppingCart.GetActiveShoppingCartName(), "Names of shopping carts are not equal");
        }
        
        [Then(@"I see only one basic shopping cart")]
        public void ThenISeeOnlyOneBasicShoppingCart()
        {
            Assert.IsTrue(_shoppingCart.IsAddedShoppingCartAreDeleted(), "Added shopping cart is not deleted");
        }

        [When(@"I choose added shopping cart in basket sticker")]
        public void WhenIChooseAddedShoppingCartInBasketSticker()
        {
            _header.ChooseShoppingCartInBasketSticker(1);
        }

        [Then(@"I see added shopping is active")]
        public void ThenISeeAddedShoppingIsActive()
        {
            Assert.AreEqual(_newCreatedShoppingCartName, _shoppingCart.GetActiveShoppingCartName(), "Names of shopping carts are not equal");
        }

        [When(@"I choose basic shopping cart in basket sticker")]
        public void WhenIChooseBasicShoppingCartInBasketSticker()
        {
            _header.ChooseShoppingCartInBasketSticker(0);
        }

        [Then(@"I see basic shopping is active")]
        public void ThenISeeBasicShoppingIsActive()
        {
            Assert.AreEqual(_basicShoppingCartName, _shoppingCart.GetActiveShoppingCartName(), "Names of shopping carts are not equal");
        }
    }
}
