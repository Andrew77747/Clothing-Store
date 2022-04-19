using System;
using System.Collections.Generic;
using ClothingStore.Framework.PageObject.Elements;
using ClothingStore.Framework.PageObject.Pages;
using ClothingStore.Framework.Tools;
using Infrastructure.Settings;
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
        private readonly CatalogPage _catalogPage;
        private readonly ModalGoodAddToShoppingCart _goodAddToShoppingCart;
        private readonly CamerasPage _camerasPage;
        private readonly CheckoutPage _checkoutPage;
        private readonly ModalGoodAddToShoppingCart _modalGoodAddToShoppingCart;
        public List<string> ListOfAddedGoods = new List<string>();
        private int _sumGoodPrice;
        private int _sumBonus;
        private string _deliveryMethod;
        private string _paymentMethod;

        public BuyingGoodsSteps(WebDriverManager manager, ConfigurationManager configuration)
        {
            _header = new Header(manager);
            _goodPage = new GoodPage(manager);
            _shoppingCart = new ShoppingCart(manager);
            _catalogPage = new CatalogPage(manager);
            _goodAddToShoppingCart = new ModalGoodAddToShoppingCart(manager);
            _checkoutPage = new CheckoutPage(manager, configuration.GetSettings());
            _camerasPage = new CamerasPage(manager);
            _modalGoodAddToShoppingCart = new ModalGoodAddToShoppingCart(manager);
        }

        [Given(@"I find '(.*)'")]
        public void WhenIFind(string model)
        {
            _header.SelectGood(model);
        }
        
        [When(@"I add good to shopping cart")]
        public void WhenIAddToShoppingCart()
        {
            _goodPage.ClickBuyBtn();
            _modalGoodAddToShoppingCart.ClickCheckoutBtn();
        }
        
        [Then(@"'(.*)' is in shopping cart")]
        public void ThenIsInShoppingCart(string model)
        {
            Assert.IsTrue(_shoppingCart.IsGoodAdded(model), "Good is not found!");
        }

        [Given(@"I click title product card with buy button")]
        [When(@"I click title product card with buy button")]
        public void WhenIClickTitleProductCardWithBuyButton()
        {
            _catalogPage.ClickTitleProductCard();
        }

        [When(@"I click buy button on good page")]
        public void WhenIClickBuyButtonOnGoodPage()
        {
            ListOfAddedGoods.Add(_goodPage.GetGoodName());
            _goodPage.ClickBuyBtn();
        }

        [When(@"I click checkout in good modal")]
        public void WhenIClickCheckoutInGoodModal()
        {
            _modalGoodAddToShoppingCart.ClickCheckoutBtn();
        }

        [When(@"I click buy button")]
        public void WhenIClickBuyButton()
        {
            _catalogPage.ClickBuyBtn();
        }

        [When(@"I click continue buying in modal")]
        public void WhenIClickContinueBuyingInModal()
        {   
            _goodAddToShoppingCart.ClickContinueBuyingBtn();
        }

        [When(@"I click digital SLR cameras")]
        public void WhenIClickDigitalSLRCameras()
        {
            _camerasPage.ClickDigitalSlrCameras();
        }

        [Then(@"I check that all goods are added")]
        public void ThenICheckThatAllGoodsAreAdded()
        {
            Assert.AreEqual(_shoppingCart.GetTitleAddedGoods(), ListOfAddedGoods, "Lists are not equal");
        }

        [When(@"I choose delivery, payment method and click submit")]
        public void WhenIChooseDeliveryPaymentMethodAndClickSubmit()
        {
            _sumBonus = _shoppingCart.GetTotalBonus();
            _sumGoodPrice = _shoppingCart.GetTotalOrderAmount();
            _shoppingCart.ChooseDeliveryAndPaymentMethods();
            _deliveryMethod = _shoppingCart.GetDeliveryMethod();
            _paymentMethod = _shoppingCart.GetPaymentMethod();
            _shoppingCart.ClickCheckoutBtn();
        }

        [Then(@"I check user data")]
        public void ThenICheckUserData()
        {
            Assert.IsTrue(_checkoutPage.IsNameCorrect(), "Names are not equal");
            Assert.IsTrue(_checkoutPage.IsPhoneCorrect(), "Phones are not equal");
            Assert.IsTrue(_checkoutPage.IsEmailCorrect(), "Emails are not equal");
        }

        [Then(@"I check order data")]
        public void ThenICheckOrderData()
        {
            Assert.IsTrue(_checkoutPage.IsTextContainsPaymentsAndDeliveryMethods(_paymentMethod), "There is no the delivery method");
            Assert.IsTrue(_checkoutPage.IsTextContainsPaymentsAndDeliveryMethods(_deliveryMethod), "There is no the delivery method");
            Assert.AreEqual(_sumGoodPrice, _checkoutPage.GetFullPrice(), "Prices are not equal");
            Assert.AreEqual(_sumBonus, _checkoutPage.GetFullBonus(), "Bonuses are not equal");
        }
    }
}