using System.Collections.Generic;
using System.Threading;
using ClothingStore.Framework.Tools;
using OpenQA.Selenium;

namespace ClothingStore.Framework.PageObject.Pages
{
    public class ShoppingCart : BasePage
    {
        public ShoppingCart(IWebDriverManager manager) : base(manager)
        {

        }

        #region Maps of Elements

        private By _cardInShoppingCart = By.CssSelector(".multicart__item");
        private By _checkboxInCard = By.CssSelector(".multicart__item .ui-checkboxradio-icon");
        private By _deleteBtn = By.CssSelector(".multicart__items__manageLeftPanel [name='delete']");
        private By _goodCardTitile = By.CssSelector(".multicart__item__description .semibold");
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

        #endregion

        public bool IsGoodAdded(string name)
        {
            return Wrapper.VerifyExpectedTitleIsDisplayed(_cardInShoppingCart, name);
        }

        public void CleanShoppingCart()
        {
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
            string parttextDeliveryMethod = Wrapper.CutLastPartText(textDeliveryMethod, ",");
            return parttextDeliveryMethod;
        }

        public string GetPaymentMethod()
        {
            string textPaymentMethod = Wrapper.GetElementText(_activePaymentMethod);
            string parttexPaymentMethod = Wrapper.CutLastPartText(textPaymentMethod, ",");
            return parttexPaymentMethod;
        }
    }
}