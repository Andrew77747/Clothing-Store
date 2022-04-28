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

        private By _personalAreaBtn = By.CssSelector(".huab__cell.huab__cell__member");
        private By _searchInput = By.CssSelector(".header__search__inputText.js__header__search__inputText");
        private By _searchResultList = By.CssSelector(".fastResult__listItem__link");
        private By _searchingPhone = By.CssSelector("[data-cattitle='Смартфон Apple iPhone 11 128 GB Чёрный']");
        private By _shoppingCartBtn = By.CssSelector(".huab__cell.huab__cell__multicart");
        private By _searchFastResult = By.CssSelector(".header__searchFastResult");
        private By _catalogBtn = By.CssSelector(".header__button.header__buttonCatalog");
        private By _videocamerasLinkInCatalog = By.CssSelector("[title='Перейти в категорию «Видеокамеры»']");
        private By _catalogPanel = By.CssSelector(".catalogLine__panel");
        private By _promotionsBtn = By.CssSelector(".header__button.header__buttonActions");
        private By _cityLink = By.CssSelector("[title='Выбрать город']");
        private By _logo = By.CssSelector(".logo");
        private By _favoriteCount = By.CssSelector(".huab__cell__text.js__bookmarksCount");
        private By _favoriteBtn = By.CssSelector(".huab__cell.huab__cell__bookmark");
        private By _shoppingCartNameInBasketSticker = 
            By.XPath("//*[contains(@class, 'huab__cell huab__cell__multicart')]//*[contains(@title, 'Перейти в корзину')]");

        #endregion


        public void ClickLoginOrPersonalAreaBtn()
        {
            Wrapper.ClickElement(_personalAreaBtn);
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

        public void ClickCityLink()
        {
            Wrapper.ClickElement(_cityLink);
        }

        public void ChooseCity(string cityName)
        {
            Wrapper.ClickElement(_cityLink);
            Wrapper.ClickElement(By.CssSelector($"[title='{cityName}']"));
        }

        public string GetCityName()
        {
            return Wrapper.GetElementText(_cityLink);
        }

        public void ClickTopMenuItem(string menuItem)
        {
            Wrapper.ClickElement(By.CssSelector($"[title='{menuItem}']"));
        }

        public void ClickLogo()
        {
            Wrapper.ClickElement(_logo);
        }

        public int GetFavoriteCount()
        {
            string favoriteCountStr = Wrapper.GetElementText(_favoriteCount);
            int favoriteCountInt = Convert.ToInt32(favoriteCountStr);
            Console.WriteLine(favoriteCountInt);
            return favoriteCountInt;
        }

        public void ClickFavoriteBtn()
        {
            Wrapper.ClickElement(_favoriteBtn);
        }

        public string GetSecondShoppingCartNameFromBasketSticker()
        {
            Wrapper.PointToElement(_shoppingCartBtn);
            Wrapper.WaitElementDisplayed(_shoppingCartBtn);
            var shoppingCartNames = Wrapper.FindElements(_shoppingCartNameInBasketSticker);
            string secondShoppingCartName = shoppingCartNames[1].GetAttribute("title");
            return Wrapper.CutPartTextFromMiddleWithAllTextValue(secondShoppingCartName, "«", "»");
        }

        public void ChooseShoppingCartInBasketSticker(int x)
        {
            Wrapper.PointToElement(_shoppingCartBtn);
            Wrapper.WaitElementDisplayed(_shoppingCartBtn);
            var shoppingCartNames = Wrapper.FindElements(_shoppingCartNameInBasketSticker);
            shoppingCartNames[x].Click();
        }
    }
}