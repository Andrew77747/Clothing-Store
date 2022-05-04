using System;
using System.Collections.Generic;
using System.Threading;
using ClothingStore.Framework.PageObject.Elements;
using ClothingStore.Framework.Tools;
using OpenQA.Selenium;

namespace ClothingStore.Framework.PageObject.Pages
{
    public class ShoppingCart : BasePage
    {

        private readonly Header _header;

        public ShoppingCart(IWebDriverManager manager) : base(manager)
        {
            _header = new Header(manager);
        }

        #region Maps of Elements

        private By _cardInShoppingCart = By.CssSelector(".multicart__item");
        private By _replcaeBtn = By.CssSelector(".multicart__items__manageLine [title='Переместить в другую корзину']");
        private By _newShoppingCartNameInputInModal = By.CssSelector("[title='Название новой корзины']");
        private By _buyLaterBtn = By.CssSelector("[value='Купить позже']");
        private By _createAndReplaceBtnInModal = By.CssSelector("[title='Создать']");
        private By _newShoppingCartModal = By.Id("popup_basketedit");
        private By _replaceIcon = By.CssSelector(".ic__set.ic__set__multicartShift");
        private By _recoveryBtn = By.CssSelector("[title='Восстановить в корзине']");
        private By _postponeIcon = By.CssSelector("[title='Отложить покупку этого товара']");
        private By _shoppingCartTabCounter = By.CssSelector(".multicart__header .itemCount");
        private By _shoppingCartInReplaceModal = By.CssSelector(".button.button__asLink");
        private By _createNewShoppingCartBtn = By.CssSelector("[title='Создать новую корзину']");
        private By _newShoppingCartNameInput = By.CssSelector("[title='Название новой корзины']");
        private By _createNewShoppingCartBtnInModal = By.Id("basketnew_button");
        private By _deleteShoppingCartBtn = By.CssSelector("[title='Удалить корзину']");
        private By _deleteShoppingCartBtnInModal = By.CssSelector(".popup [title='Удалить корзину']");
        private By _shoppingCartTabName = By.CssSelector(".multicart__header__itemName");
        private By _checkboxInCard = By.CssSelector(".multicart__item .ui-checkboxradio-icon");
        private By _deleteBtn = By.CssSelector(".multicart__items__manageLeftPanel [name='delete']");
        private By _goodCardTitile = By.CssSelector(".multicart__item__description .semibold");
        private By _basicCheckbox = By.CssSelector(".multicart__items__manageLeftPanel .ui-checkboxradio-label");
        private By _deliveryWithinMKAD =
            By.XPath("//td[@class='js__linkAsLabel'][contains(text(), 'Доставка в пределах МКАД')]/..//*[contains(@class, 'ui-checkboxradio-label')]");
        private By _sbpPayRadioBtn =
            By.XPath(
                "//td[@class='js__linkAsLabel']//*[contains(text(), 'Онлайн-оплата через СБП')]/../..//*[contains(@class, 'ui-checkboxradio-label')]");
        private By _checkoutBtn = By.CssSelector(".button.button__orange.semibold");
        private By _goodPrice = By.CssSelector(".descriptionLine .nowrap");
        private By _goodBonus = By.CssSelector("[title='ON-бонус']");
        private By _activePaymentMethod =
            By.XPath("//div[@id='basket_paymenttypes__ID']//*[contains(@class, 'ui-state-active')]/../.. //div[@class='descriptionLine']");
        private By _activeDeliveryMethod =
            By.XPath("//div[@id='basket_delivery__ID']//*[contains(@class, 'ui-state-active')]/../.. //td[@class='js__linkAsLabel']");
        private By _shoppingCartTab = By.XPath("//*[contains(@class, 'multicart__header__item multicart__header__item__color')]");
        private By _activeShoppingCartName = 
            By.XPath("//*[@class='multicart__header']//*[contains(@class, 'active')]//*[@class='multicart__header__itemName']");
        private By _moveBelowElement = By.CssSelector("[title='Ниже в списке']");
        private By _shoppingCartHeader = By.XPath("//h1[normalize-space(.)='Корзина']");

        #endregion

        public void MoveElementBelow()
        {
            var elements = Wrapper.FindElements(_moveBelowElement);
            Wrapper.HoverMouseOnElement(elements[0]);
            elements[0].Click();
        }

        public bool IsGoodAdded(string name)
        {
            return Wrapper.VerifyExpectedTitleIsDisplayed(_cardInShoppingCart, name);
        }

        public void CleanShoppingCart()
        {
            if (Wrapper.IsElementsNotExistOrDisplayed(_shoppingCartHeader))
                _header.GoToShoppingCart();

            if (Wrapper.IsElementExists(_cardInShoppingCart))
            {
                var checkboxes = Wrapper.FindElements(_checkboxInCard);

                foreach (var checkbox in checkboxes)
                {
                    checkbox.Click();
                }

                Wrapper.ClickElement(_deleteBtn);
            }
        }

        public List<string> GetTitleAddedGoods()
        {
            return Wrapper.GetElementsTextList(_goodCardTitile);
        }

        public void ChooseDeliveryAndPaymentMethods()
        {
            Wrapper.ClickCheckbox(_deliveryWithinMKAD);
            Wrapper.ClickCheckbox(_sbpPayRadioBtn);
        }

        public void ClickCheckoutBtn()
        {
            Wrapper.ClickElement(_checkoutBtn);
        }

        public int GetTotalOrderAmount()
        {
            return Wrapper.TotalAmount(Wrapper.GetElementsTextArray(_goodPrice));
        }

        public int GetTotalBonus()
        {
            return Wrapper.TotalAmount(Wrapper.GetElementsTextArray(_goodBonus));
        }

        public string GetDeliveryMethod()
        {
            string textDeliveryMethod = Wrapper.GetElementText(_activeDeliveryMethod);
            string parttextDeliveryMethod = Wrapper.CutLastPartTextWithAllTextValue(textDeliveryMethod, ",");
            return parttextDeliveryMethod;
        }

        public string GetPaymentMethod()
        {
            string textPaymentMethod = Wrapper.GetElementText(_activePaymentMethod);
            string parttexPaymentMethod = Wrapper.CutLastPartTextWithAllTextValue(textPaymentMethod, ",");
            return parttexPaymentMethod;
        }

        public void AddNewShoppingCart(string name)
        {
            Wrapper.ClickElement(_createNewShoppingCartBtn);
            Wrapper.WaitElementDisplayed(_newShoppingCartModal);
            Wrapper.TypeAndSend(_newShoppingCartNameInput, name);
            Wrapper.ClickElement(_createNewShoppingCartBtnInModal);
        }

        public void DeleteAllAddedShoppingCarts()
        {

            if (Wrapper.IsElementsNotExistOrDisplayed(_shoppingCartHeader))
                _header.GoToShoppingCart();

            var shoppingCartCount = Wrapper.FindElements(_shoppingCartTab);

                while (shoppingCartCount.Count > 1)
                {
                    shoppingCartCount[1].Click();
                    Wrapper.ClickElement(_deleteShoppingCartBtn);
                    Wrapper.ClickElement(_deleteShoppingCartBtnInModal);
                    shoppingCartCount = Wrapper.FindElements(_shoppingCartTab);
                }
        }

        public void ChooseBasicShoppingCart()
        {
            var shoppingCartCount = Wrapper.FindElements(_shoppingCartTab);
            shoppingCartCount[0].Click();
        }

        public bool IsSecondShoppingCartCreated()
        {
            var shoppingCartCount = Wrapper.FindElements(_shoppingCartTab);

            if (shoppingCartCount.Count.Equals(2))
            {
                return true;
            }

            return false;
        }

        public string GetSecondShoppingCartName()
        {
            //var shoppingCartTabName = Wrapper.FindElements(_shoppingCartTabName);
            //return shoppingCartTabName[1].Text;

            var shoppingCartCount = Wrapper.FindElements(_shoppingCartTab);
            return shoppingCartCount[1].FindElement(_shoppingCartTabName).Text;
        }

        public bool IsShoppingCartNamesAreEqual()
        {
            return GetSecondShoppingCartName().Equals(_header.GetSecondShoppingCartNameFromBasketSticker());
        }

        public void ClearShoppingCartWithBasicCheckbox()
        {
            if (Wrapper.IsElementExists(_cardInShoppingCart))
            {
                Wrapper.FindElement(_basicCheckbox).Click();
                Wrapper.FindElement(_deleteBtn).Click();
            }
        }

        public void ChooseSecondShoppingCart()
        {
            var shoppingCartCount = Wrapper.FindElements(_shoppingCartTab);
            shoppingCartCount[1].Click();
        }

        public string GetActiveShoppingCartName()
        {
            return Wrapper.FindElement(_activeShoppingCartName).Text;
        }

        public bool IsAddedShoppingCartAreDeleted()
        {
            var shoppingCartCount = Wrapper.FindElements(_shoppingCartTab);

            if (shoppingCartCount.Count.Equals(1))
            {
                return true;
            }

            return false;
        }

        public void CheckCheckbox()
        {
            Wrapper.ClickCheckbox(_checkboxInCard);
        }

        public void ReplaceGoodWithButton()
        {
            Wrapper.ClickElement(_replcaeBtn);
            Wrapper.ClickElement(_shoppingCartInReplaceModal);
        }

        public void ReplaceGoodWithIcon()
        {
            Wrapper.ClickElement(_replaceIcon);
            Wrapper.ClickElement(_shoppingCartInReplaceModal);
        }

        public string GetGoodName()
        {
            return Wrapper.GetElementText(_goodCardTitile);
        }

        public int GetNumberFromCounter(int x)
        {
            var counterList = Wrapper.FindElements(_shoppingCartTabCounter);
            string counterText = counterList[x].Text;
            int counterNumber = Convert.ToInt32(counterText);
            return counterNumber;
        }

        public bool IsGoodPresents(string text)
        {
            return Wrapper.VerifyExpectedTitleIsDisplayed(_goodCardTitile, text);
        }

        public bool IsCardNotExistsInShoppingCart()
        {
            return Wrapper.IsElementsNotExistOrDisplayed(_cardInShoppingCart);
        }

        public void BuyLaterBtn()
        {
            Wrapper.ClickElement(_buyLaterBtn);
        }

        public bool IsRecoveryBtnExists()
        {
            return Wrapper.IsElementExists(_recoveryBtn);
        }

        public bool IsPostponeButtonExists()
        {
            return Wrapper.IsElementExists(_postponeIcon);
        }

        public void RecoveryGood()
        {
            Wrapper.ClickElement(_recoveryBtn);
        }

        public void PostponeGood()
        {
            Wrapper.ClickElement(_postponeIcon);
        }

        public void ClickReplaceBtn()
        {
            Wrapper.ClickElement(_replcaeBtn);
        }

        public void CreateNewShoppingCartWhileReplacing(string text)
        {
            Wrapper.TypeAndSend(_newShoppingCartNameInputInModal, text);
            Wrapper.ClickElement(_createAndReplaceBtnInModal);
        }
    }
}