using System;
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
    }
}
