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

        //public bool IsSortingAscRight()
        //{
        //    var actualArray = Wrapper.GetElementsText(_actualPriceElements);

        //    //string[] expectedArray = new string[actualArray.Count];
        //    //actualArray.CopyTo(expectedArray, 0);

        //    //Array.Sort(expectedArray);

        //    //if (actualArray.SequenceEqual(expectedArray))
        //    //{
        //    //    Console.WriteLine(expectedArray);
        //    //    return true;
        //    //}
        //    //else
        //    //{
        //    //    Console.WriteLine(expectedArray);
        //    //    return false;
        //    //}

        //}

        public string[] GetActualPriceArray()
        {

            return Wrapper.GetElementsTextArray(_productCard, _actualPriceElements);
        }

        public bool IsSortingAskRight()
        {
            return Wrapper.IsSortingAskRight(GetActualPriceArray());
        }

        //public string[] GetPriceFromCards(By selector)
        //{
        //    return Wrapper.GetElementsText(selector);
        //}
    }
}