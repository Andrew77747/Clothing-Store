using ClothingStore.Framework.PageObject.Pages;
using ClothingStore.Framework.Tools;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace ClothingStore.Tests
{
    [Binding]
    public class MainPageSteps
    {
        private readonly MainPage mainPage;

        public MainPageSteps(WebDriverManager manager, ConfigurationManager configuration)
        {
            mainPage = new MainPage(manager, configuration.GetSettings());
        }

        [Given(@"I'm on the main page")]
        public void GivenIMOnTheMainPage()
        {
            mainPage.OpenPage();
        }
        
        [Then(@"I check main page loaded")]
        public void ThenICheckMainPageLoaded()
        {
            Assert.IsTrue(mainPage.VerifyMainPage(), "Main page is not loaded!");
        }
    }
}
