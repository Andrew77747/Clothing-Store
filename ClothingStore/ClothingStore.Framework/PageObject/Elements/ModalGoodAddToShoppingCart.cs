using System.Threading;
using ClothingStore.Framework.Tools;
using OpenQA.Selenium;

namespace ClothingStore.Framework.PageObject.Elements
{
    public class ModalGoodAddToShoppingCart : BaseElement
    {
        public ModalGoodAddToShoppingCart(IWebDriverManager manager) : base(manager)
        {

        }

        #region Maps of Elements

        private By _continueBuyingBtn = By.CssSelector(".js__usualSpoilerBlock .js__popup__close");
        private By _checkoutBtn = By.CssSelector(".js__usualSpoilerBlock .button.button__clearGray");

        #endregion

        public void ClickContinueBuyingBtn()
        {
            Wrapper.ClickElement(_continueBuyingBtn);
            Wrapper.RefreshPage();
        }

        public void ClickCheckoutBtn()
        {
            Wrapper.ClickElement(_checkoutBtn);
        }
    }
}