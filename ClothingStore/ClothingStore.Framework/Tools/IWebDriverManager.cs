using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace ClothingStore.Framework.Tools
{
    public interface IWebDriverManager : IDisposable
    {
        IWebDriver GetDriver();
        WebDriverWait GetWaiter();
    }
}