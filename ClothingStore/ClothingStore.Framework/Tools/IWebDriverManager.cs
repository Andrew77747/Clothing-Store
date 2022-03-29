using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace WebShop.Tricentis.Framework.Tools
{
    public interface IWebDriverManager : IDisposable
    {
        IWebDriver GetDriver();
        WebDriverWait GetWaiter();
    }
}