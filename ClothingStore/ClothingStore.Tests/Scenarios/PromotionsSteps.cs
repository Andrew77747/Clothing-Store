using System;
using ClothingStore.Framework.PageObject.Elements;
using ClothingStore.Framework.PageObject.Pages;
using ClothingStore.Framework.Tools;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ClothingStore.Tests.Scenarios
{
    [Binding]
    public class PromotionsSteps
    {
        private readonly Header _header;
        private readonly PromotionsPage _promotionsPage;

        public PromotionsSteps(WebDriverManager manager)
        {
            _header = new Header(manager);
            _promotionsPage = new PromotionsPage(manager);
        }

        [Given(@"I click promotions button")]
        public void GivenIClickPromotionsButton()
        {
            _header.ClickPromotions();
        }
        
        [When(@"I switch paginator on promotion pages")]
        public void WhenISwitchPaginatorOnPromotionPages()
        {
            _promotionsPage.CountPromotions();
        }
        
        [Then(@"Amount of prmotions is correct")]
        public void ThenAmountOfPrmotionsIsCorrect()
        {
            Assert.AreEqual(_promotionsPage.GetPromotionsMaxCount(), _promotionsPage.CountPromotions(), "Promotion amounts must be equal");
        }
    }
}
