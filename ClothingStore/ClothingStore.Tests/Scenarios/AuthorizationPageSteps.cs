using System;
using ClothingStore.Framework.PageObject.Pages;
using ClothingStore.Framework.Tools;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ClothingStore.Tests.Scenarios
{
    [Binding]
    public class AuthorizationPageSteps
    {
        private readonly MainPage _mainPage;
        private readonly AuthorizationPage _authorizationPage;

        public AuthorizationPageSteps(WebDriverManager manager, ConfigurationManager configuration)
        {
            _authorizationPage = new AuthorizationPage(manager, configuration.GetSettings());
            _mainPage = new MainPage(manager, configuration.GetSettings());
        }

        [Given(@"I go to the authorization page")]
        public void GivenIGoToTheAuthorizationPage()
        {
            _mainPage.ClickLogin();
        }
        
        [When(@"I login")]
        public void WhenILogin()
        {
            _authorizationPage.Login();
        }

        [When(@"I go to personal area")]
        public void WhenIGoToPersonalArea()
        {
            _authorizationPage.GoToPersonalArea();
        }


        [Then(@"I'm in my account")]
        public void ThenIMInMyAccount()
        {
            Assert.IsTrue(_authorizationPage.IsUserLogin(), "User is not Login!");
        }
    }
}
