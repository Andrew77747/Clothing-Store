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
    public class ViewedGoodsSteps
    {
        private readonly PersonalAreaViewedGoodsPage _personalAreaViewedGoods;
        private readonly PersonalArea _personalArea;
        private readonly CatalogPage _catalogPage;
        private readonly GoodPage _goodPage;
        private readonly Header _header;
        private List <string> _goodsListActual = new();

        public ViewedGoodsSteps(WebDriverManager manager)
        {
            _personalAreaViewedGoods = new PersonalAreaViewedGoodsPage(manager);
            _personalArea = new PersonalArea(manager);
            _catalogPage = new CatalogPage(manager);
            _goodPage = new GoodPage(manager);
            _header = new Header(manager);
        }

        [Then(@"I clean viewed goods")]
        public void GivenICleanViewedGoods()
        {
            _header.ClickLoginOrPersonalAreaBtn();
            _personalArea.ClickViewedGoodsLink();
            _personalAreaViewedGoods.ClearViewedGoods();
        }

        [Given(@"I click title product card with buy button and add good name to list")]
        public void GivenIClickTitleProductCardWithBuyButtonAndAddGoodNameToList()
        {
            _catalogPage.ClickTitleProductCard();
            _goodsListActual.Add(_goodPage.GetGoodName());
        }

        [When(@"I go to viewed goods page")]
        public void WhenIGoToViewedGoodsPage()
        {
            _personalArea.ClickViewedGoodsLink();
        }

        [Then(@"The goods I added are right")]
        public void ThenTheGoodsIAddedAreRight()
        {
            _goodsListActual.Sort();
            Assert.AreEqual(_personalAreaViewedGoods.GetGoodsList(), _goodsListActual, "Good lists are not equal");
        }
    }
}