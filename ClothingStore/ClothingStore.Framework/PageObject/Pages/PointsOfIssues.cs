using System;
using System.Threading;
using ClothingStore.Framework.Tools;
using OpenQA.Selenium;

namespace ClothingStore.Framework.PageObject.Pages
{
    public class PointsOfIssues : BasePage
    {
        public PointsOfIssues(IWebDriverManager manager) : base(manager)
        {

        }

        #region Maps of Elements

        private By _showMapBtn = By.CssSelector("[title='Показать карту']");
        private By _map = By.CssSelector(".ymaps-2-1-79-events-pane.ymaps-2-1-79-user-selection-none");
        private By _zoomMapPlus = By.CssSelector(".ymaps-2-1-79-zoom__plus.ymaps-2-1-79-zoom__button");
        private By _zoomMapMinus = By.CssSelector(".ymaps-2-1-79-zoom__minus.ymaps-2-1-79-zoom__button");
        private By _zoomMapSlider = By.CssSelector(".ymaps-2-1-79-zoom__runner.ymaps-2-1-79-zoom__button");

        #endregion

        public void ShowMap()
        {
            Wrapper.ClickElement(_showMapBtn);
        }

        public void ZoomMap()
        {
            Wrapper.ClickElement(_zoomMapPlus);
            Wrapper.ClickElement(_zoomMapMinus);
            Wrapper.MoveElement(_map, 200, 200);
            Thread.Sleep(2000);
            Wrapper.MoveElement(_zoomMapSlider, 0, -20);
            Thread.Sleep(4000);


        }
    }
}