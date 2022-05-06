using System;
using System.Threading;
using ClothingStore.Framework.PageObject.Pages;
using ClothingStore.Framework.Tools;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace ClothingStore.Tests.Scenarios
{
    [Binding]
    public class CatalogPageTestSteps
    {
        private readonly CatalogPage _catalogPage;
        private string _goodNameAddingCart;

        public CatalogPageTestSteps(WebDriverManager manager)
        {
            _catalogPage = new CatalogPage(manager);
        }

        [When(@"I switch count of cards to '(.*)'")]
        public void WhenISwitchCountOfCardsTo(int count)
        {
            _catalogPage.SwitchCountCards(count);
        }


        [When(@"I unfold all cards")]
        public void WhenIUnfoldAllCards()
        {
            _catalogPage.ShowAllCardsViaShowMoreBtn();
        }
        
        [Then(@"I see that amount of cards is equal to value")]
        public void ThenISeeThatAmountOfCardsIsEqualToValue()
        {
            Assert.AreEqual(_catalogPage.GetValuePaginatorCount(), _catalogPage.GetProductCardsCount(), "Product cards counts are not equal");
        }

        [Then(@"I see compare list is empty")]
        public void ThenISeeCompareListIsEmpty()
        {
            Assert.IsTrue(_catalogPage.IsCompareListEmpty(), "Compare list is not empty");
        }

        [When(@"I add one good to compare")]
        public void WhenIAddOneGoodToCompare()
        {
            _goodNameAddingCart = _catalogPage.ClickCompareIconAndGetGoodName();
        }

        [Then(@"I see icon compare is active and i see delete icon from comparing")]
        public void ThenISeeIconCompareIsActiveAndISeeDeleteIconFromComparing()
        {
            Assert.IsTrue(_catalogPage.IsCompareIconActiveAndDeleteIconVisible(), "Compare icon is not active or delete icon is not visible");
        }

        [Then(@"I see the good I added in side menu In comparing")]
        public void ThenISeeTheGoodIAddedInSideMenuInComparing()
        {
            Assert.IsTrue(_catalogPage.IsSideMenuGoodNameContainsAddedGoodName(_goodNameAddingCart), "Goods names are not equal");
        }

        [When(@"I delete from comparing with delete button in cards")]
        public void WhenIDeleteFromComparingWithDeleteButtonInCards()
        {
            _catalogPage.DeleteGoodFromComparing();
        }

        [When(@"I clear comparing")]
        public void WhenIClearComparing()
        {
            _catalogPage.DeleteGoodsFromComparingInSideMenu();
        }

        [Then(@"I see icon compare is inactive and i don't see delete icon from comparing")]
        public void ThenISeeIconCompareIsInactiveAndIDonTSeeDeleteIconFromComparing()
        {
            Assert.IsTrue(_catalogPage.IsCompareIconActiveAndDeleteIconInvisible(), "Compare icon is active or delete icon is visible"); 
        }

        [When(@"I refresh page")]
        public void WhenIRefreshPage()
        {
            _catalogPage.RefreshCurrentPage();
        }

    }
}
