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
        private string _filePath = "C:/UploadSelenium/2022-04-13_153202.png";  //"C:/UploadSelenium/2022-04-13_153202.png"

        public HelpAndSupportPage(IWebDriverManager manager) : base(manager)
        {

        }

        #region Map of Elements

        private By _themeDropdown = By.CssSelector("[title='Тема обращения']");
        private By _clientTips = By.CssSelector(".note.note__dash");
        private By _textAreaMessage = By.CssSelector(".input__textarea");
        private By _feedbackFileOpen = By.CssSelector("[title='Загрузить файлы']");
        private By _hiddenFilesInput = By.CssSelector("[type='file']");

        #endregion

        public void ChooseTreatmentCategory(string category)
        {
            Wrapper.ClickElement(By.CssSelector($"[title='{category}']"));
        }

        public void SelectThemeDropdownItem(string item)
        {
            Wrapper.ClickElement(_themeDropdown);
            Thread.Sleep(1000);
            Wrapper.ClickElement(By.XPath($"//select[@id='feedback_topic_ID']//option[normalize-space(.)='{item}']"));
            Thread.Sleep(1000);
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
            Thread.Sleep(3000);
        }

        public void UploadFile(string filepath, string filename)
        {
            HandleOpenDialog hndOpen = new HandleOpenDialog();
            hndOpen.fileOpenDialog(filepath, filename);
        }


        //public void UploadFeedbackFile()
        //{
        //    Wrapper.ClickElement(_feedbackFileOpen);
        //    //UploadFile("C:/UploadSelenium", "2022-04-13_153202.png");
        //    ////Wrapper.TypeAndSend(_feedbackFileOpen, _filePath);
        //    //Thread.Sleep(3000);



        //    Wrapper.AttachFile(driver: new ChromeDriver(), _hiddenFilesInput, "C:/UploadSelenium/2022-04-13_153202.png");
        //}
    }
}