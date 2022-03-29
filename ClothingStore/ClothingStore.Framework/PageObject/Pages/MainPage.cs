using System;
using ClothingStore.Framework.Tools;
using Infrastructure.Settings;
using OpenQA.Selenium;

namespace ClothingStore.Framework.PageObject.Pages
{
    public class MainPage : BasePage
    {
        private Appsettings _settings;

        public MainPage(IWebDriverManager manager, Appsettings settings) : base(manager)
        {
            _settings = settings;
        }

        #region Maps of Elements

        private By _logo = By.CssSelector(".logo.img-responsive");
        private By _menu = By.CssSelector(".sf-menu");
        private By _navigationTabs = By.CssSelector(".nav.nav-tabs");

        #endregion

        public void OpenPage()
        {
            Wrapper.NavigateToUrl(_settings.Url);
        }

        public bool VerifyMainPage()
        {
            return Wrapper.IsPageLoaded(_logo, _menu, _navigationTabs);
        }
    }
}