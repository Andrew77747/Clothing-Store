using ClothingStore.Framework.Tools;
using OpenQA.Selenium;

namespace ClothingStore.Framework.PageObject.Pages
{
    public class GoodPage : BasePage
    {
        public GoodPage(IWebDriverManager manager) : base(manager)
        {

        }

        #region Maps of Elements

        private By _buyBtn = By.CssSelector(".catalog__displayedItem__button .button.button__orange");
        private By _checkoutBtn = By.CssSelector(".js__usualSpoilerBlock .button.button__clearGray");

        #endregion

        public void ClickBuyButton()
        {
            Wrapper.ClickElement(_buyBtn);
        }

        public void ClickBuyBtnAndCheckout()
        {
            Wrapper.ClickElement(_buyBtn);
            Wrapper.ClickElement(_checkoutBtn);
        }
    }
}