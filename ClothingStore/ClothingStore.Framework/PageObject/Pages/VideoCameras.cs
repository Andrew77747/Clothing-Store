using ClothingStore.Framework.Tools;
using OpenQA.Selenium;

namespace ClothingStore.Framework.PageObject.Pages
{
    public class VideoCameras : BasePage
    {
        public VideoCameras(IWebDriverManager manager) : base(manager)
        {

        }

        #region Maps of Elements

        private By _digitalVideoCameras = By.CssSelector("[title='Цифровые видеокамеры']");

        #endregion

        public void ClickDigitalVideoCameras()
        {
            Wrapper.ClickElement(_digitalVideoCameras);
        }
    }
}