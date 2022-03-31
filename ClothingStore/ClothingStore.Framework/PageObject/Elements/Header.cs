using System.Collections.Generic;
using System.Threading;
using ClothingStore.Framework.Tools;
using OpenQA.Selenium;

namespace ClothingStore.Framework.PageObject.Elements
{
    public class Header : BaseElement

    {
        public Header(IWebDriverManager manager) : base(manager)
        {

        }

        #region Maps of Elements

        private By _loginBtn = By.CssSelector(".huab__cell.huab__cell__member");
        private By _searchInput = By.CssSelector(".header__search__inputText.js__header__search__inputText");
        private By _searchResultList = By.CssSelector(".fastResult__listItem__link");
        private By _searchingPhone = By.CssSelector("[data-cattitle='Смартфон Apple iPhone 11 128 GB Чёрный']");
        private By _shoppingCartBtn = By.CssSelector(".huab__cell.huab__cell__multicart");

        #endregion


        public void ClickLogin()
        {
            Wrapper.ClickElement(_loginBtn);
        }

        public void SelectGood(string text)
        {
            Wrapper.TypeAndSend(_searchInput, text);

            Thread.Sleep(2000);

            var good = By.CssSelector($"[data-cattitle='{text}']");

            if (Wrapper.IsElementExists(good) == true)
            {
                Wrapper.ClickElement(good);
            }
        }

        public void GoToShoppingCart()
        {
            Wrapper.ClickElement(_shoppingCartBtn);
        }
    }
}