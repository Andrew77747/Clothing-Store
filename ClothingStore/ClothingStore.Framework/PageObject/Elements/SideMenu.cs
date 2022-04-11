using System.Threading;
using ClothingStore.Framework.PageObject.Pages;
using ClothingStore.Framework.Tools;
using OpenQA.Selenium;

namespace ClothingStore.Framework.PageObject.Elements
{
    public class SideMenu : BaseElement
    {
        public SideMenu(IWebDriverManager manager) : base(manager)
        {

        }

        #region Maps of Elements

        //private By _blockName = By.XPath($"//div[text()='{name}']/..");
        private By _resultLink = By.CssSelector(".orange.js__filterResult_link");
        private By _resultFilter = By.CssSelector(".filterResult__sticker.active");

        #endregion

        public void ChooseBrand(string blockName, string itemName)
        {
            By _blockName = By.XPath($"//div[text()='{blockName}']/..//span[contains(text(), '{itemName}')]");
            Wrapper.FindElement(_blockName).Click();
        }

        public void ClickResulLink()
        {
            Wrapper.WaitElementDisplayed(_resultFilter);
            Wrapper.ClickElement(_resultLink);
        }
    }
}