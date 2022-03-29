using ClothingStore.Framework.Tools;
using Infrastructure.Settings;
using OpenQA.Selenium;

namespace ClothingStore.Framework.PageObject.Pages
{
    public class AuthorizationPage : BasePage
    {
        private Appsettings _settings;
        private string user = "Andrew Walker";

        public AuthorizationPage(IWebDriverManager manager, Appsettings settings) : base(manager)
        {
            _settings = settings;
        }

        #region Maps of Elements

        private By _userInputEmail = By.CssSelector("#email");
        private By _userInputPassword = By.CssSelector("#passwd");
        private By _logginBtn = By.CssSelector("#SubmitLogin");
        private By _accountName = By.CssSelector(".account");
        private By _homeIcon = By.CssSelector(".home");
        private By _accountInfo = By.CssSelector(".info-account");
        private By _personalUserMenu = By.CssSelector(".row.addresses-lists");

        #endregion

        public void Login()
        {
            Wrapper.TypeAndSend(_userInputEmail, _settings.Login);
            Wrapper.TypeAndSend(_userInputPassword, _settings.Password);
            Wrapper.ClickElement(_logginBtn);
        }

        public bool IsUserLogin()
        {
            return Wrapper.VerifyExpectedTitleIsDisplayed(_accountName, user) &&
                   Wrapper.IsPageLoaded(_homeIcon, _accountInfo, _personalUserMenu);
        }
    }
}