using System;
using System.Collections.Generic;
using System.Threading;
using ClothingStore.Framework.PageObject.Elements;
using ClothingStore.Framework.PageObject.Pages;
using ClothingStore.Framework.Tools;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ClothingStore.Tests.Scenarios
{
    [Binding]
    public class BookmarksSteps
    {
        private readonly Header _header;
        private readonly PersonalArea _personalArea;
        private readonly PersonalAreaBookmarksPage _personalAreaBookmarksPage;
        private readonly CatalogPage _catalogPage;

        public BookmarksSteps(WebDriverManager manager)
        {
            _header = new Header(manager);
            _personalArea = new PersonalArea(manager);
            _personalAreaBookmarksPage = new PersonalAreaBookmarksPage(manager);
            _catalogPage = new CatalogPage(manager);
        }

        [Then(@"I clear bookmarks")]
        public void ThenIClearBookmarks()
        {
            _header.ClickFavoriteBtn();
            _personalAreaBookmarksPage.ClearBookmarks();
        }

        [Given(@"I choose favorite goods")]
        public void GivenIChooseFavoriteGoods()
        {

            _catalogPage.AddBookmarks();
        }

        [When(@"I go to bookmarks page")]
        public void WhenIGoToBookmarksPage()
        {
            _header.ClickFavoriteBtn();
        }

        [Then(@"The goods I added to favorite are right")]
        public void ThenTheGoodsIAddedToFavoriteAreRight()
        {
            Assert.AreEqual(_personalAreaBookmarksPage.GetFavoriteNames(), _catalogPage.GetSortFavoriteList(), "Favorite lists are not equal");
            Assert.AreEqual(_header.GetFavoriteCount(), _catalogPage.GetActualFavoriteCount(), "Favorite counts are not equal");
        }
    }
}
