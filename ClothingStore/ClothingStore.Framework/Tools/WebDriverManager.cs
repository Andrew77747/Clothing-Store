using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace ClothingStore.Framework.Tools
{
    public class WebDriverManager : IWebDriverManager

    {
        public IWebDriver Driver;
        //public WebDriverWait Wait;

        //public WebDriverManager()
        //{
        //}

        //public IWebDriver Driver;
        //public WebDriverWait Wait;
        //public Appsettings Settings;

        //public WebDriverManager()
        //{
        //    Driver = GetDriver();
        //    Settings = new Appsettings();
        //    Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(Settings.Timeout));
        //    Driver.Manage().Window.Maximize();
        //}

        public IWebDriver GetDriver()
        {
            if (Driver != null)
            {
                return Driver;
            }

            Driver = new ChromeDriver();
            //Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            //object p = Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            Driver.Manage().Window.Maximize();
            return Driver;
        }

        //public WebDriverWait GetWaiter()
        //{
        //    Wait = new WebDriverWait(GetDriver(), TimeSpan.FromSeconds(3));
        //    return Wait;
        //}

        public WebDriverWait GetWaiter()
        {
            return new WebDriverWait(GetDriver(), TimeSpan.FromSeconds(3));
        }

        public void Dispose()
        {
            if (Driver == null) return;

            Driver.Close();
            Driver.Quit();
            Driver = null;
        }
    }
}