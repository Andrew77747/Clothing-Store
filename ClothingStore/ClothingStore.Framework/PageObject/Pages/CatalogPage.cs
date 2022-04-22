using System;
using System.Collections.Generic;
using System.Threading;
using ClothingStore.Framework.Tools;
using NUnit.Framework;
using OpenQA.Selenium;

namespace ClothingStore.Framework.PageObject.Pages
{
    public class CatalogPage : BasePage
    {
        private GoodPage _goodPage;
        List<string> favoriteGoodNames = new();

        public CatalogPage(IWebDriverManager manager) : base(manager)
        {
            _goodPage = new GoodPage(manager);
        }

        #region Maps of Elements

        private By _buyBtn = By.XPath("//div[@class='indexGoods__item']//*[text()='Купить']");
        private By _titleProductCardWithBuyBtn = By.XPath("//a[text()= 'Купить']/../../..//a[contains(@class, 'indexGoods__item__name') ]");
        private By _bookmarkIcon = By.CssSelector(".ic__hasSet.ic__hasSet__bookmark");
        private By _bookmarkIconInCard = By.CssSelector("[title='В закладки']");
        private By _titleProductCard = By.CssSelector(".indexGoods__item__name");
        private By _titleProductCardInCard = By.CssSelector(" h1[itemprop='name']");
        private By _productCard = By.CssSelector(".indexGoods__item");
        private By _productCardTitle = By.CssSelector(".indexGoods__item__name");
        private By _productCardFrame = By.CssSelector(".goods__items.minilisting.borderedTiles");

        #endregion

        public void ClickBuyBtn()
        {
            Wrapper.ClickElement(_buyBtn);
            //Thread.Sleep(3000);
        }

        public void ClickTitleProductCard()
        {
            Wrapper.ClickElement(_titleProductCardWithBuyBtn);
        }

        public void AddBookmarks()
        {
            var productCardsList = Wrapper.FindElements(_productCard);

            for (int i = 0; i < 4; i++)
            {
                productCardsList[i].FindElement(_productCardTitle).Click();
                Wrapper.FindElement(_bookmarkIconInCard).Click();
                favoriteGoodNames.Add(_goodPage.GetGoodName());
                Wrapper.NavigateBack();
                Wrapper.WaitElementDisplayed(_productCardFrame);
                //Thread.Sleep(500);
                productCardsList = Wrapper.FindElements(_productCard);
            }
        }

        public List<string> GetSortFavoriteList()
        {
            favoriteGoodNames.Sort();
            foreach (var goodName in favoriteGoodNames)
            {
                Console.WriteLine(goodName);
            }
            return favoriteGoodNames;
        }

        public int GetActualFavoriteCount()
        {
            int count = favoriteGoodNames.Count;
            Console.WriteLine(count);
            return count;
        }
    }
}