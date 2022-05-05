using System;
using System.Collections.Generic;
using ClothingStore.Framework.Tools;
using OpenQA.Selenium;

namespace ClothingStore.Framework.PageObject.Pages
{
    public class PromotionsPage : BasePage
    {
        public PromotionsPage(IWebDriverManager manager) : base(manager)
        {

        }

        #region Maps of Elements

        private By _paginator = By.CssSelector("paginator__links");
        private By _arrowNext = By.CssSelector(".js__paginator__linkNext");
        private By _promotioCard = By.CssSelector(".pageActions__item");
        private By _paginatorCount = By.CssSelector(".paginator__count");

        #endregion

        public void ClickArrowNext()
        {
            Wrapper.ClickElement(_arrowNext);
        }

        //public int SwitchPagesWithArrowNext()
        //{
        //    int totalCountElements = 0;

        //    while (Wrapper.IsElementExists(_arrowNext))
        //    {
        //        var listOfElements = Wrapper.GetElements(_promotioCard);
        //        totalCountElements += listOfElements.Count;

        //        ClickArrowNext();

        //        if (!Wrapper.IsElementExists(_arrowNext))
        //        {
        //            listOfElements = Wrapper.GetElements(_promotioCard);
        //            totalCountElements += listOfElements.Count;
        //        }
        //    }
        //    return totalCountElements;
        //}

        public int CountPromotions()
        {
            int totalCountElements = 0;

            while (Wrapper.IsElementExists(_arrowNext))
            {
                totalCountElements += Wrapper.GetElementCount(_promotioCard);

                ClickArrowNext();

                if (!Wrapper.IsElementExists(_arrowNext))
                {
                    totalCountElements += Wrapper.GetElementCount(_promotioCard);
                }
            }
            return totalCountElements;
        }

        public int GetPromotionsMaxCount()
        {
            string paginatorCountText = Wrapper.GetElementText(_paginatorCount);
            string textTotalAmonut = Wrapper.CutFirstPartTextWithAllTextValue(paginatorCountText, "из ");
            int intCutAmount = Convert.ToInt32(textTotalAmonut);

            return intCutAmount;
        }
    }
}