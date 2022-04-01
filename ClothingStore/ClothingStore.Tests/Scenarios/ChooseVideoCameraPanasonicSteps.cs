using System;
using System.Threading;
using ClothingStore.Framework.PageObject.Elements;
using ClothingStore.Framework.PageObject.Pages;
using ClothingStore.Framework.Tools;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ClothingStore.Tests.Scenarios
{
    [Binding]
    public class ChooseVideoCameraPanasonicSteps
    {

        private readonly Header _header;
        private readonly VideoCameras _videoCameras;
        private readonly SideMenu _sideMenu;
        private readonly DigitalVideoCameras _digitalVideoCameras;

        public ChooseVideoCameraPanasonicSteps(WebDriverManager manager)
        {
            _header = new Header(manager);
            _videoCameras = new VideoCameras(manager);
            _sideMenu = new SideMenu(manager);
            _digitalVideoCameras = new DigitalVideoCameras(manager);
        }

        [When(@"I click catalog")]
        public void WhenIClickCatalog()
        {
            _header.ClickCatalog();
        }

        [When(@"I click digital videocameras")]
        public void WhenIClickDigitalVideocameras()
        {
            _videoCameras.ClickDigitalVideoCameras();
        }

        [When(@"I choose Panasonic")]
        public void WhenIChoosePanasonic()
        {
            _sideMenu.ChooseBrand("Производитель", "PANASONIC");
            _sideMenu.ClickResulLink();
        }

        [When(@"I choose sorting by price asc")]
        public void WhenIChooseSortingByPriceAsc()
        {
            _digitalVideoCameras.ClickSorting();
            _digitalVideoCameras.ChooseSortingByPriceAsc();
            Thread.Sleep(3000);
        }

        [Then(@"I see only Panasonic videocameras sorting by price asc")]
        public void ThenISeeOnlyPanasonicVideoamerasSortingByPriceAsc()
        {
            Assert.IsTrue(_digitalVideoCameras.IsSortingAskRight(), "Sorting is not correct!");
        }
    }
}
