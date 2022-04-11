using System.Threading;
using ClothingStore.Framework.Tools;
using OpenQA.Selenium;

namespace ClothingStore.Framework.PageObject.Pages
{
    public class CatalogPage : BasePage
    {
        public CatalogPage(IWebDriverManager manager) : base(manager)
        {

        }

        #region Maps of Elements

        private By _buyBtn = By.XPath("//div[@class='indexGoods__item']//*[text()='Купить']");
        private By _titleProductCard = By.XPath("//a[text()= 'Купить']/../../..//a[contains(@class, 'indexGoods__item__name') ]");

        #endregion

        public void ClickBuyBtn()
        {
            Wrapper.ClickElement(_buyBtn);
            //Thread.Sleep(3000);
        }

        public void ClickTitleProductCard()
        {
            Wrapper.ClickElement(_titleProductCard);
        }
    }
}