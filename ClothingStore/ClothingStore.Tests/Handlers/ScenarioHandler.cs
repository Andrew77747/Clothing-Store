using System;
using BoDi;
using ClothingStore.Framework.Tools;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace ClothingStore.Tests.Handlers
{
    public class ScenarioHandler
    {
        [BeforeScenario]
        public void StartApp(IObjectContainer container)
        {
            container.RegisterTypeAs<WebDriverManager, IWebDriverManager>();
            container.RegisterFactoryAs(c => c.Resolve<IWebDriverManager>().GetDriver());
        }

        [AfterScenario]
        public void Error(ScenarioContext context, IWebDriver driver)
        {
            if (context.TestError != null)
            {
                var screenshot = new ScreenshotMaker(driver, TestContext.CurrentContext.Test.Name);
                Console.WriteLine("The screen shot was made into " + screenshot.Path);
                TestContext.AddTestAttachment(screenshot.Path);
            }
        }
    }
}