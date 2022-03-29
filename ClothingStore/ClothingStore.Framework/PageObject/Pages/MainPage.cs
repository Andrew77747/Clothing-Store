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

        private By _logo = By.CssSelector(".logo");
        private By _headerMenu = By.CssSelector(".header__mainlinks");
        private By _banners = By.CssSelector(".indexHat");
        private By _loginBtn = By.CssSelector(".login");

        #endregion

        public void OpenPage()
        {
            Wrapper.NavigateToUrl(_settings.Url);
        }

        public bool VerifyMainPage()
        {
            return Wrapper.IsPageLoaded(_logo, _headerMenu, _banners);
        }

        public void ClickLogin()
        {
            Wrapper.ClickElement(_loginBtn);
        }
    }
}