using System;
using System.Collections.Generic;
using System.Threading;
using ClothingStore.Framework.Tools;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;

namespace ClothingStore.Framework.PageObject.Pages
{
    public class PersonalAreaBookmarksPage : BasePage
    {
        public PersonalAreaBookmarksPage(IWebDriverManager manager) : base(manager)
        {

        }

        #region Map of Elements

        private By _bookmark = By.CssSelector(".tableGoods__itemGroup");
        private By _closeBookmarkBtn = By.CssSelector(".ic__set.ic__set__close");
        private By _favoriteItemName = By.CssSelector(".tableGoods__item__name");

        #endregion

        public void ClearBookmarks()
        {
            if (Wrapper.IsElementExists(_bookmark))
            {
                var bookmarkCloseButtons = Wrapper.FindElements(_closeBookmarkBtn);

                foreach (var closeButton in bookmarkCloseButtons)
                {
                    closeButton.Click();
                    Thread.Sleep(1000);
                    //Wrapper.WaitElementInvisible(_closeBookmarkBtn);
                    //Wrapper.WaitElementInvisible(_closeBookmarkBtn);
                    //Wrapper.WaitForElementNotExist(closeButton);
                }

                //for (int i = 0; i < bookmarkCloseButtons.Count; i++)
                //{
                //    bookmarkCloseButtons[i].Click();
                //    Wrapper.WaitForElementNotExist(bookmarkCloseButtons[i]);
                //}
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