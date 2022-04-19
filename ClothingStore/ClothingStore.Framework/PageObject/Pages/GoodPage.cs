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
        private By _goodProductTitle = By.CssSelector(".productPage__card [itemprop='name']");

        #endregion

        public void ClickBuyBtn()
        {
            Wrapper.ClickElement(_buyBtn);
        }

        public string GetGoodName()
        {
            return Wrapper.GetElementText(_goodProductTitle);
        }
    }
}