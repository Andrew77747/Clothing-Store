using System.Threading;
using ClothingStore.Framework.Tools;
using Infrastructure.Settings;
using OpenQA.Selenium;

namespace ClothingStore.Framework.PageObject.Pages
{
    public class AuthorizationPage : BasePage
    {
        private Appsettings _settings;
        private string userEmail = "andrew-walker@yandex.ru";
        private string userInitialInIcon = "AN";

        public AuthorizationPage(IWebDriverManager manager, Appsettings settings) : base(manager)
        {
            _settings = settings;
        }

        #region Maps of Elements

        private By _userInputEmail = By.Name("login");
        private By _userInputPassword = By.Name("password");
        private By _logginBtn = By.Name("submit");
        private By _personalAreaBtn = By.CssSelector(".huab__cell.huab__cell__member");
        private By _personalAreaHeader = By.CssSelector(".content__header");
        private By _userAccountInfo = By.CssSelector(".userInfo");
        private By _sideUserMenu = By.CssSelector(".content__leftColumn");
        private By _userIcon = By.CssSelector(".huab__cell__text.orange");
        private By _accountEmail = By.XPath("//*[contains(text(), 'E-mail:')]/..");
        //private By _loginBtn = By.CssSelector(".huab__cell.huab__cell__member");

        #endregion

        public bool Login()
        {
            //Wrapper.ClickElement(_loginBtn);
            Wrapper.TypeAndSend(_userInputEmail, _settings.Email);
            Wrapper.TypeAndSend(_userInputPassword, _settings.Password);
            Wrapper.ClickElement(_logginBtn);
            return Wrapper.VerifyExpectedTitleIsDisplayed(_userIcon, userInitialInIcon);
        }

        public void GoToPersonalArea()
        {
            Wrapper.ClickElement(_personalAreaBtn);
        }

        public bool IsUserLogin()
        {
            return Wrapper.VerifyExpectedTitleIsDisplayed(_accountEmail, userEmail) &&
                   Wrapper.IsPageLoaded(_personalAreaHeader, _userAccountInfo, _sideUserMenu);
        }
    }
}