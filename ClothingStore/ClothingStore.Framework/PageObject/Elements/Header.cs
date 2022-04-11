using System;
using System.IO;
using System.Threading;
using ClothingStore.Framework.Tools;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

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
        private By _searchFastResult = By.CssSelector(".header__searchFastResult");
        private By _catalogBtn = By.CssSelector(".header__button.header__buttonCatalog");
        private By _videocamerasLinkInCatalog = By.CssSelector("[title='Перейти в категорию «Видеокамеры»']");
        private By _catalogPanel = By.CssSelector(".catalogLine__panel");
        private By _promotionsBtn = By.CssSelector(".header__button.header__buttonActions");

        #endregion


        public void ClickLogin()
        {
            Wrapper.ClickElement(_loginBtn);
        }

        public void SelectGood(string text)
        {
            Wrapper.TypeAndSend(_searchInput, text);

            Wrapper.WaitElementDisplayed(_searchFastResult);

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

        public void ClickCatalog()
        {
            Wrapper.ClickElement(_catalogBtn);
            Wrapper.WaitElementDisplayed(_catalogPanel);
        }

        public void ChooseCatalogItem(string itemName)
        {
            Thread.Sleep(1000);
            Wrapper.WaitElementDisplayed(By.XPath($"//a[text()= '{itemName}']"));
            Wrapper.ClickElement(By.XPath($"//a[text()= '{itemName}']"));
        }

        public void HoverMouseOnSideMenuElement(string nameOfItem)
        {
            var selector = $"//a[@class='mCM__item__link mCM__item__icon']//span[text()= '{nameOfItem}']";
            Wrapper.HoverMouseOnElement(selector);
        }

        public void ClickPromotions()
        {
            Wrapper.ClickElement(_promotionsBtn);
        }
    }
}