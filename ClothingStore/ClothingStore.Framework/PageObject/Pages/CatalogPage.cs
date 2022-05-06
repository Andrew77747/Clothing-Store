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
        private By _productCardWithBuyBtn = By.XPath("//a[text()= 'Купить']/../../..");
        private By _bookmarkIcon = By.CssSelector(".ic__hasSet.ic__hasSet__bookmark");
        private By _bookmarkIconInCard = By.CssSelector("[title='В закладки']");
        private By _titleProductCard = By.CssSelector(".indexGoods__item__name");
        private By _titleProductCardInCard = By.CssSelector(" h1[itemprop='name']");
        private By _productCard = By.CssSelector(".indexGoods__item");
        private By _productCardTitle = By.CssSelector(".indexGoods__item__name");
        private By _productCardFrame = By.CssSelector(".goods__items.minilisting.borderedTiles");
        private By _showMoreBtn = By.CssSelector(".js__ajaxExchange.js__ajaxListingMore");
        private By _paginatorCount = By.CssSelector(".paginator__count");
        private By _paginatorActive = By.CssSelector(".js__paginator__linkActive");
        private By _allPaginators = By.XPath("//*[contains(@class, 'js__paginator__link')]");
        private By _compareItem = By.CssSelector(".columnUpperBlock__content .thinImaginedList__item");
        private By _inactiveCompareIconInCard = By.CssSelector(".ic__hasSet.ic__hasSet__compare");
        private By _deleteCompareIconInCard = By.CssSelector(".content__mainColumn [title='Удалить из сравнения']");
        private By _deleteCompareIconInSideMenu = By.CssSelector(".thinImaginedList__item [title='Удалить из сравнения']");

        #endregion

        public string ClickBuyBtnAndReturnGoodName()
        {
            var buyButtonsInCards = Wrapper.FindElements(_productCardWithBuyBtn);
            string goodName = buyButtonsInCards[0].FindElement(_titleProductCard).Text;
            buyButtonsInCards[0].FindElement(_buyBtn).Click();

            return goodName;
        }

        public string ClickCompareIconAndGetGoodName()
        {
            var cardList = Wrapper.FindElements(_productCard);
            cardList[0].FindElement(_inactiveCompareIconInCard).Click();
            //Thread.Sleep(1000);
            //Wrapper.WaitElementDisplayed(_deleteCompareIconInCard);
            Wrapper.WaitForAttributeContains(cardList[0].FindElement(_inactiveCompareIconInCard), "class", "active");
            return cardList[0].FindElement(_productCardTitle).Text;
        }

        public void DeleteGoodsFromComparingInSideMenu()
        {
            var deleteIconInCards = Wrapper.FindElements(_deleteCompareIconInSideMenu);

            if (deleteIconInCards.Count != 0)
            {
                foreach (var x in deleteIconInCards)
                {
                    x.Click();
                }

                Wrapper.WaitForElementNotExistsOrDisplayed(_deleteCompareIconInSideMenu);
            }
        }

        public bool IsSideMenuGoodNameContainsAddedGoodName(string text)
        {
            return Wrapper.FindElement(_compareItem).Text.Contains(text);
        }

        public void DeleteGoodFromComparing()
        {
            var deleteIconInCards = Wrapper.FindElements(_deleteCompareIconInCard);
            deleteIconInCards[0].Click();
            Wrapper.WaitForElementNotDisplayed(deleteIconInCards[0]);
        }

        public bool IsCompareIconActiveAndDeleteIconVisible()
        {
            var compareIconList = Wrapper.FindElements(_inactiveCompareIconInCard);
            var deleteCompareIconList = Wrapper.FindElements(_deleteCompareIconInCard);

            return Wrapper.IsAttributeContains(compareIconList[0], "class", "active") &&
             Wrapper.IsAttributeNotContains(deleteCompareIconList[0], "class", "noDisplay");
        }

        public bool IsCompareIconActiveAndDeleteIconInvisible()
        {
            var compareIconList = Wrapper.FindElements(_inactiveCompareIconInCard);
            var deleteCompareIconList = Wrapper.FindElements(_deleteCompareIconInCard);

            return Wrapper.IsAttributeNotContains(compareIconList[0], "class", "active") &&
                   Wrapper.IsAttributeContains(deleteCompareIconList[0], "class", "noDisplay");
        }

        public void RefreshCurrentPage()
        {
            Wrapper.RefreshPage();
        }

        public bool IsCompareListEmpty()
        {
            return Wrapper.IsElementsNotExistOrDisplayed(_compareItem);
        }

        public void ClickBuyBtn()
        {
            var buyButtonsInCards = Wrapper.FindElements(_productCardWithBuyBtn);
            buyButtonsInCards[0].FindElement(_buyBtn).Click();
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

        public void AddBookmark()
        {
            var listOfCards = Wrapper.FindElements(_bookmarkIcon);

            for (int i = 0; i < listOfCards.Count; i++)
            {
                var x = Wrapper.GetValuesOfAttribute(listOfCards[i], "class");
                if (!x.Contains("active"))
                {
                    listOfCards[i].Click();
                    Wrapper.WaitForAttributeContains(listOfCards[i], "class", "active");
                    break;
                }
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

        public void ClickShowMoreBtn()
        {
            Wrapper.ClickElement(_showMoreBtn);
        }

        public void SwitchCountCards(int count)
        {
            Wrapper.ClickElement(By.CssSelector($".percount [title='{count}']"));
        }

        public void ShowAllCardsViaShowMoreBtn()
        {


            while (Wrapper.IsElementDisplayed(_showMoreBtn))
            {
                //var activePaginator = Wrapper.FindElements(_productCard).Count;
                ClickShowMoreBtn();

                //var productCardsListHere = Wrapper.FindElements(_productCard);
                //productCardsList.InsertRange(productCardsList.Count, productCardsListHere);
                Thread.Sleep(3000);


                //Wrapper.WaitForMoreElements(activePaginator, _productCard);

                //Wrapper.WaitForAttributeContains(activePaginator, "class", "Active");
            }
        }

        public int GetProductCardsCount()
        {
            //List<IWebElement> productCardsList = Wrapper.FindElements(_productCard);
            //return productCardsList.Count;

            List<IWebElement> productCardsList = Wrapper.FindElements(_productCard);
            return productCardsList.Count;
        }

        public int GetValuePaginatorCount()
        {
            string paginatorCount = Wrapper.CutFirstPartTextWithAllTextValue(Wrapper.GetElementText(_paginatorCount), "из ");
            int paginatorCountInt = Convert.ToInt32(paginatorCount);
            return paginatorCountInt;
        }
    }
}