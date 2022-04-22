using ClothingStore.Framework.Tools;
using OpenQA.Selenium;

namespace ClothingStore.Framework.PageObject.Pages
{
    public class PersonalArea: BasePage
    {
        public PersonalArea(IWebDriverManager manager) : base(manager)
        {

        }

        #region Map of Elements

        private By _viewedGoodsLink = By.CssSelector("[title='Вы смотрели']");
        private By _bookmarksLink = By.CssSelector("[title='Закладки']");

        #endregion

        public void ClickViewedGoodsLink()
        {
            Wrapper.ClickElement(_viewedGoodsLink);
        }

        public void ClickBookmarks()
        {
            Wrapper.ClickElement(_bookmarksLink);
        }
    }
}