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
        [When(@"I clear bookmarks")]
        public void ThenIClearBookmarks()
        {
            //_header.ClickFavoriteBtn();
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

        [Given(@"I choose favorite good")]
        public void GivenIChooseFavoriteGood()
        {
            _catalogPage.AddBookmark();
            _catalogPage.AddBookmark();
            _catalogPage.AddBookmark();
            _catalogPage.AddBookmark();
        }

        [When(@"I delete bookmark")]
        public void WhenIDeleteBookmark()
        {
            _personalAreaBookmarksPage.DeleteBookmark();
        }

        [Then(@"I see message to cancel delete")]
        public void ThenISeeMessageToCancelDelete()
        {
            Assert.IsTrue(_personalAreaBookmarksPage.IsElementRemovedBookmarkExists(), "Element doesn't exist");
            Assert.IsTrue(_personalAreaBookmarksPage.IsRightElementWasRemoved(), "Wrong element was removed");
        }

        [When(@"I cancel deletion")]
        public void WhenICancelDeletion()
        {
            _personalAreaBookmarksPage.CancelDeletion();
        }

        [Then(@"I see bookmark I deleted a moment ago")]
        public void ThenISeeBookmarkIDeletedAMomentAgo()
        {
            Assert.IsTrue(_personalAreaBookmarksPage.IsBookmarkRestored(), "Bookmark is not restored");
        }

        //[When(@"I delete all bookmarks")]
        //public void WhenIDeleteAllBookmarks()
        //{
        //    _personalAreaBookmarksPage.ClearBookmarks();
        //}

        [Then(@"I don't see bookmarks")]
        public void ThenIDonTSeeBookmarks()
        {
            Assert.IsTrue(_personalAreaBookmarksPage.IsContentAfterRemovalBookmarksExists(), "Content doesn't exist");
            Assert.IsTrue(_personalAreaBookmarksPage.IsAllBookmarksWasDeleted(), "Element is displayed");
        }
    }
}
