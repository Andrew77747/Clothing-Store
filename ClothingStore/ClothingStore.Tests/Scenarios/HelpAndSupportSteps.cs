using System.Threading;
using ClothingStore.Framework.PageObject.Elements;
using ClothingStore.Framework.PageObject.Pages;
using ClothingStore.Framework.Tools;
using Infrastructure.Settings;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ClothingStore.Tests.Scenarios
{
    [Binding]
    public class HelpAndSupportSteps
    {
        private readonly Header _header;
        private readonly HelpAndSupportPage _helpAndSupportPage;

        public HelpAndSupportSteps(WebDriverManager manager, ConfigurationManager configuration)
        {
            _header = new Header(manager);
            _helpAndSupportPage = new HelpAndSupportPage(manager);
        }

        [When(@"I click '(.*)'")]
        public void WhenIClick(string categoryName)
        {
            _helpAndSupportPage.ChooseTreatmentCategory(categoryName);
        }

        [When(@"I select dropdown Theme '(.*)'")]
        public void WhenISelectDropdownTheme(string theme)
        {
            _helpAndSupportPage.SelectThemeDropdownItem(theme);
        }

        [When(@"I type message")]
        public void WhenITypeMessage()
        {
            _helpAndSupportPage.TypeMessage();
        }

        [When(@"I upload picture")]
        public void WhenIUploadPicture()
        {
            _helpAndSupportPage.UploadFeedbackFile();
        }

        [Then(@"I see hint message")]
        public void ThenISeeHintMessage()
        {
            Assert.IsTrue(_helpAndSupportPage.IsHintMessageElementExists(), "Hint message element doesn't exist");
            Assert.IsTrue(_helpAndSupportPage.IsAppealThemeExists(), "Hint message is not right");
        }

        [Then(@"The picture is uploaded successfully")]
        public void ThenThePictureIsUploadedSuccessfully()
        {
            Assert.IsTrue(_helpAndSupportPage.IsFileUpload(), "File wasn't uploaded");
            Assert.IsTrue(_helpAndSupportPage.IsRightFileUploaded(), "Wrong file");
        }
    }
}
