using ClothingStore.Framework.Tools;
using OpenQA.Selenium;

namespace ClothingStore.Framework.PageObject.Pages
{
    public class PersonalAreaPersonalDataPage : BasePage
    {
        public PersonalAreaPersonalDataPage(IWebDriverManager manager) : base(manager)
        {

        }

        #region Map of Elements

        private By _birthdayInput = By.Id("datepicker_birthday__ID");
        private By _birthdayInputCalendar = By.CssSelector(".js__icCalendar");
        private By _yearsInCalendar = By.CssSelector(".ui-datepicker-year");
        private By _monthsInCalendar = By.CssSelector("ui-datepicker-month");

        #endregion
    }
}