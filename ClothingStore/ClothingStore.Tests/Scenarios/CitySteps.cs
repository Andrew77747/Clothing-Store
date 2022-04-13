using System;
using System.Threading;
using ClothingStore.Framework.PageObject.Elements;
using ClothingStore.Framework.PageObject.Pages;
using ClothingStore.Framework.Tools;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ClothingStore.Tests.Scenarios
{
    [Binding]
    public class CitySteps
    {
        private readonly Header _header;
        private string _cityIChoose;

        public CitySteps(WebDriverManager manager)
        {
            _header = new Header(manager);
        }

        [When(@"I choose '(.*)' city")]
        public void WhenIChooseCity(string city)
        {
            _cityIChoose = city;
            _header.ChooseCity(city);
        }

        [Then(@"I see city I chose")]
        public void ThenISeeCityIChose()
        {
            Assert.AreEqual(_cityIChoose, _header.GetCityName(), "Names should be equal");
        }
    }
}
