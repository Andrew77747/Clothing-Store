using ClothingStore.Framework.PageObject.Pages;
using ClothingStore.Framework.Tools;
using TechTalk.SpecFlow;

namespace ClothingStore.Tests.Handlers
{
    [Binding]
    public class BaseSteps
    {
        private readonly MainPage _mainPage;

        public BaseSteps(WebDriverManager manager, ConfigurationManager configuration)
        {
            _mainPage = new MainPage(manager, configuration.GetSettings());
        }

        [Given(@"I'm on the main page")]
        public void GivenIMOnTheMainPage()
        {
            _mainPage.OpenPage();
        }
    }
}