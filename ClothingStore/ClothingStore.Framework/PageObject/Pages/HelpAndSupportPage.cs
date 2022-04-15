using System.Threading;
using ClothingStore.Framework.Tools;
using Infrastructure.Settings;
using OpenDialogWindowHandler;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ClothingStore.Framework.PageObject.Pages
{
    public class HelpAndSupportPage : BasePage
    {
        private string _individualClientTip = "Обращения обрабатываются ежедневно с 9 до 21 часа по московскому времени.";
        private string _message = "Привет! У меня к вам вопрос по заказу. Ответьте, пожалуйста.";
        private string _filePath = "C:/UploadSelenium/2022-04-13_153202.png";
        private string _fileName = "2022-04-13_153202.png";

        public HelpAndSupportPage(IWebDriverManager manager) : base(manager)
        {

        }

        #region Map of Elements

        private By _themeDropdown = By.CssSelector("[title='Тема обращения']");
        private By _clientTips = By.CssSelector(".note.note__dash");
        private By _textAreaMessage = By.CssSelector(".input__textarea");
        private By _feedbackFileOpen = By.CssSelector("[title='Загрузить файлы']");
        private By _uploadInput = By.CssSelector("[type='file']");
        private By _successUploadMessage = By.XPath("//*[contains(text(),'Документ загружен')]");
        private By _deleteUploadedFileBtn = By.CssSelector("[title='Удалить']");
        private By _uploadedFile = By.CssSelector("[title='Посмотреть']");

        #endregion

        public void ChooseTreatmentCategory(string category)
        {
            Wrapper.ClickElement(By.CssSelector($"[title='{category}']"));
        }

        public void SelectThemeDropdownItem(string item)
        {
            Wrapper.ClickElement(_themeDropdown);
            Wrapper.WaitElementDisplayed(By.XPath($"//select[@id='feedback_topic_ID']//option[normalize-space(.)='{item}']"));
            Wrapper.ClickElement(By.XPath($"//select[@id='feedback_topic_ID']//option[normalize-space(.)='{item}']"));
            Wrapper.WaitElementDisplayed(_clientTips);
        }

        public bool IsHintMessageElementExists()
        {
            return Wrapper.IsElementDisplayed(_clientTips);
        }

        public bool IsAppealThemeExists()
        {
            return Wrapper.VerifyExpectedTitleIsDisplayedFull(_clientTips, _individualClientTip);
        }

        public void TypeMessage()
        {
            Wrapper.TypeAndSend(_textAreaMessage, _message);
        }

        public void UploadFeedbackFile()
        {
            Wrapper.UploadFiles(_uploadInput, _filePath);
            Wrapper.WaitElementDisplayed(_successUploadMessage);
            Wrapper.WaitElementDisplayed(_deleteUploadedFileBtn);
            Wrapper.WaitElementDisplayed(_uploadedFile);
        }

        public bool IsFileUpload()
        {
            return Wrapper.VerifyExpectedElementsAreDisplayed(_successUploadMessage) &&
                   Wrapper.VerifyExpectedElementsAreDisplayed(_deleteUploadedFileBtn) &&
                   Wrapper.VerifyExpectedElementsAreDisplayed(_uploadedFile);
        }

        public bool IsRightFileUploaded()
        {
           return Wrapper.VerifyExpectedTitleIsDisplayedFull(_uploadedFile, _fileName);
        }
    }
}