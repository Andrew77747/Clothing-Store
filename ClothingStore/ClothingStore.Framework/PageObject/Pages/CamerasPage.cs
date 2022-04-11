using ClothingStore.Framework.Tools;
using OpenQA.Selenium;

namespace ClothingStore.Framework.PageObject.Pages
{
    public class CamerasPage : BasePage
    {
        public CamerasPage(IWebDriverManager manager) : base(manager)
        {

        }

        #region Maps of Elements

        private By _digitalSlrCameras = By.CssSelector("[title='Цифровые зеркальные фотоаппараты']");

        #endregion

        public void ClickDigitalSlrCameras()
        {
            Wrapper.ClickElement(_digitalSlrCameras);
        }

    }
}