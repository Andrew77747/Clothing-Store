using System;
using System.Collections.Generic;
using System.Linq;
using ClothingStore.Framework.Tools;
using NUnit.Framework;
using OpenQA.Selenium;

namespace ClothingStore.Framework.PageObject.Pages
{
    public class DigitalVideoCameras : BasePage
    {
        public DigitalVideoCameras(IWebDriverManager manager) : base(manager)
        {

        }

        #region Maps of Elements

        private By _sorting = By.CssSelector(".ot_customSelector");
        private By _sortingByPriceAsc = By.CssSelector("[title='сначала подешевле']");
        private By _actualPriceElements = By.CssSelector(".price.js__actualPrice");
        private By _productCard = By.CssSelector(".indexGoods__item");

        #endregion

        public void ClickSorting()
        {
            Wrapper.ClickElement(_sorting);
        }

        public void ChooseSortingByPriceAsc()
        {
            Wrapper.ClickElement(_sortingByPriceAsc);
        }

        public string[] GetActualPriceArray()
        {

            return Wrapper.GetElementsTextArray(_productCard, _actualPriceElements);
        }

        public bool IsSortingPriceAskRight()
        {
            return Wrapper.IsSortingPriceAskRightStringToInt(GetActualPriceArray());
        }
    }
}