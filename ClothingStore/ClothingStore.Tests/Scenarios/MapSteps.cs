using System;
using System.Threading;
using ClothingStore.Framework.PageObject.Elements;
using ClothingStore.Framework.PageObject.Pages;
using ClothingStore.Framework.Tools;
using TechTalk.SpecFlow;

namespace ClothingStore.Tests.Scenarios
{
    [Binding]
    public class MapSteps
    {
        private readonly Header _header;
        private readonly PointsOfIssues _pointsOfIssues;

        public MapSteps(WebDriverManager manager)
        {
            _header = new Header(manager);
            _pointsOfIssues = new PointsOfIssues(manager);
        }


        [When(@"I click show map")]
        public void WhenIClickShowMap()
        {
            _pointsOfIssues.ShowMap();
        }
        
        [Then(@"I zoom map")]
        public void ThenIZoomMap()
        {
            _pointsOfIssues.ZoomMap();
        }
    }
}
