using System;
using System.Collections.Generic;
using System.Threading;
using ClothingStore.Framework.PageObject.Elements;
using ClothingStore.Framework.Tools;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;

namespace ClothingStore.Framework.PageObject.Pages
{
    public class PersonalAreaBookmarksPage : BasePage
    {

        private string _deletedGoodTitle;
        private readonly Header _header;

        public PersonalAreaBookmarksPage(IWebDriverManager manager) : base(manager)
        {
            _header = new Header(manager);
        }

        #region Map of Elements

        private By _bookmarkTable = By.CssSelector(".tableGoods__itemGroup");
        private By _myBookmarksHeader = By.XPath("//h1[normalize-space(.)='Мои закладки']");
        private By _bookmark = By.CssSelector(".tableGoods__itemGroup");
        private By _clearBookmarkBtn = By.CssSelector(".ic__set.ic__set__close");
        private By _favoriteItemName = By.CssSelector(".tableGoods__item__name");
        private By _removedBookmark = By.CssSelector(".removedBookmark__restore");
        private By _goodCardTitle = By.CssSelector(".tableGoods__item__name");
        private By _cancelDeletionTitle = By.CssSelector(".removedBookmark__restore [data-handlermode='add']");
        private By _contentAfterRemovalBookmarks = By.CssSelector(".oldContent");

        #endregion

        public bool IsContentAfterRemovalBookmarksExists()
        {
            return Wrapper.IsElementDisplayed(_contentAfterRemovalBookmarks);
        }

        public void DeleteBookmark()
        {
            _deletedGoodTitle = Wrapper.GetElementText(_goodCardTitle);
            Wrapper.ClickElement(_clearBookmarkBtn);
            Wrapper.WaitForElementNotExistsOrDisplayed(_clearBookmarkBtn);
            //Thread.Sleep(1000);
        }

        public bool IsRightElementWasRemoved()
        {
            return Wrapper.VerifyExpectedTitleIsDisplayed(_removedBookmark, _deletedGoodTitle);
        }

        public bool IsElementRemovedBookmarkExists()
        {
            return Wrapper.IsElementExists(_removedBookmark);
        }

        public void CancelDeletion()
        {
            Wrapper.ClickElement(_cancelDeletionTitle);
            Wrapper.WaitForElementNotExistsOrDisplayed(_cancelDeletionTitle);
        }

        public bool IsBookmarkRestored()
        {
            List<string> cardTitleList = Wrapper.GetElementsTextList(_goodCardTitle);
            return cardTitleList.Contains(_deletedGoodTitle);
        }

        public bool IsAllBookmarksWasDeleted()
        {
            return Wrapper.IsElementNotDisplayed2(_bookmarkTable);
            //return Wrapper.IsElementsNotExistOrDisplayed(_bookmarkTable);
        }

        public void ClearBookmarks()
        {
            if (Wrapper.IsElementsNotExistOrDisplayed(_myBookmarksHeader))
                _header.ClickFavoriteBtn();

            if (Wrapper.IsElementExists(_bookmarkTable))
            {
                var bookmarkCloseButtons = Wrapper.FindElements(_clearBookmarkBtn);

                foreach (var closeButton in bookmarkCloseButtons)
                {

                    closeButton.Click();
                    Wrapper.WaitForElementNotDisplayed(closeButton);
                }
            }
        }

        public List<string> GetFavoriteNames()
        {
            var names = Wrapper.GetElementsTextList(_favoriteItemName);
            names.Sort();
            foreach (var goodName in names)
            {
                Console.WriteLine(goodName);
            }

            return names;
        }
    }
}