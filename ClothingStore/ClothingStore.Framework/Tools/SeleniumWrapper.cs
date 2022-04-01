using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using NUnit.Framework;

namespace ClothingStore.Framework.Tools
{
    public class SeleniumWrapper
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;
        private WebDriverWait _customDriverWait;

        public SeleniumWrapper(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
            _customDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
        }

        #region Actions

        public void SwitchToAlertAccept()
        {
            //IAlert alert = _driver.SwitchTo().Alert();
            //alert.Accept();
            _driver.SwitchTo().Alert().Accept();
        }

        public void SwitchToAnotherTab(int numberOfTab)
        {
            var tabs = new List<String>(_driver.WindowHandles);
            _driver.SwitchTo().Window(tabs[numberOfTab]);
        }

        public void NavigateBack()
        {
            _driver.Navigate().Back();
        }

        public void NavigateToUrl(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public void TypeAndSend(By by, string text)
        {
            FindElement(by).SendKeys(text);
        }

        public void SendKeysWithEscape(By by, string text)
        {
            FindElement(by).SendKeys(text + Keys.Escape);
        }

        public void TypeAndSendWithEnter(By by, string text)
        {
            FindElement(by).SendKeys(text + Keys.Enter);
        }

        public void ClearTypeAndSend(By by, string text)
        {
            //_driver.FindElement(by).Clear();
            //_driver.FindElement(by).SendKeys(text);
            _driver.FindElement(by).SendKeys(Keys.Control + text);
        }

        public IWebElement FindElement(By by)
        {
            WaitElementDisplayed(by);
            return _driver.FindElement(by);
        }

        public List <IWebElement> FindElements(By by)
        {
            WaitElementDisplayed(by);
            return new List<IWebElement>(_driver.FindElements(by));
        }

        public void ClickElement(By by)
        {
            FindElement(by).Click();
        }

        public string GetUrl()
        {
            return _driver.Url;
        }

        public string GetUserName()
        {
            return _driver.PageSource;
        }

        public List<string> GetElementsTextList(By selector)
        {
            var allElementsWithText = _driver.FindElements(selector);
            List<string> names = new List<string>();

            foreach (var oneElementWithText in allElementsWithText)
            {
                names.Add(oneElementWithText.Text);
            }

            return names;
        }

        //public string[] GetElementsTextArray(By selector)
        //{
        //    var allElementsWithText = _driver.FindElements(selector);
        //    string[] names = new string[allElementsWithText.Count];

        //    for (int i = 0; i < names.Length; i++)
        //    {
        //        names[i] = allElementsWithText[i].FindElement(selector).Text;
        //        Console.WriteLine(names[i]);
        //    }

        //    //foreach (var oneElementWithText in allElementsWithText)
        //    //{
        //    //    names.Add(oneElementWithText.Text);
        //    //}

        //    return names;
        //}

        public string[] GetElementsTextArray(By selector, By selector2)
        {
            var allElementsWithText = GetElements(selector);
            string[] names = new string[allElementsWithText.Count];

            for (int i = 0; i < names.Length; i++)
            {
                names[i] = allElementsWithText[i].FindElement(selector2).Text;
                Console.WriteLine(names[i]);
            }

            return names;
        }

        //public string[] GetElementsText(By selector, By selector2)
        //{
        //    var listOfElements = GetElements(selector);
        //    string[] names = new string[listOfElements.Count];

        //    for (int i = 0; i < names.Length; i++)
        //    {
        //        names[i] = listOfElements[i].FindElement(selector2).Text;
        //        Console.WriteLine(names[i]);
        //    }

        //    return names;
        //}

        public void HoverMouseOnElement(string selector)
        {
            try
            {
                Actions action = new Actions(_driver);
                action.MoveToElement(FindElement(By.XPath(selector))).Build().Perform();
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("There is no such element! Error: " + e);
            }
        }

        public void PointToElement(By selector)
        {
            Actions action = new Actions(_driver);
            action.MoveToElement(FindElement(selector)).Build().Perform();
        }

        public List<IWebElement> GetElements(By selector)
        {
            return _driver.FindElements(selector).ToList();
        }

        #endregion

        #region Validation

        //public bool IsElementExists(By selector) //
        //{
        //    try
        //    {
        //        _driver.FindElement(selector);
        //        return true;
        //    }
        //    catch (NoSuchElementException)
        //    {
        //        return false;
        //    }
        //}

        //public bool IsElementDisplayed(By selector) //
        //{
        //    try
        //    {
        //        return _driver.FindElement(selector).Displayed;
        //    }
        //    catch (NoSuchElementException)
        //    {
        //        return false;
        //    }
        //}

        //public bool IsElementDisplayedWithWaiter(By selector) //
        //{
        //    try
        //    {
        //        //WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(3));
        //        _wait.Until(d => IsElementDisplayed(selector));
        //        return true;
        //    }
        //    catch (NoSuchElementException)
        //    {
        //        return false;
        //    }
        //    catch (WebDriverTimeoutException)
        //    {
        //        return false;
        //    }
        //}

        public bool IsTextExists(string text)
        {
            try
            {
                _driver.FindElement(By.XPath($"//*[contains(text(), '{text}')]"));
                Console.WriteLine($"Злобный Гурч злобно видит текст {text}");
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine($"Злобный Гурч не видит текст {text}. Выпускаем шмеля");
                return false;
            }
        }

        public string GetValuesOfAttribute(By by, string value)
        {
            return _driver.FindElement(by).GetAttribute(value);
        }

        //public bool IsElementVisible(By by) ////
        //{
        //    try
        //    {
        //        return _driver.FindElement(by).Displayed;
        //    }
        //    catch (NoSuchElementException)
        //    {
        //        Console.WriteLine("Здесь нет дропдауна");
        //        return false;
        //    }
        //}

        public bool IsSortingAskRight(string[] actualArray)
        {

            string[] expectedArray = new string[actualArray.Length];
            actualArray.CopyTo(expectedArray, 0);

            Array.Sort(expectedArray);

            if (actualArray.SequenceEqual(expectedArray))
            {
                Console.WriteLine(expectedArray);
                return true;
            }
            else
            {
                Console.WriteLine(expectedArray);
                return false;
            }
        }

        public bool IsSortingDescRight(string[] actualArray)
        {

            string[] expectedArray = new string[actualArray.Length];
            actualArray.CopyTo(expectedArray, 0);

            Array.Sort(expectedArray);
            Array.Reverse(expectedArray);

            if (actualArray.SequenceEqual(expectedArray))
            {
                Console.WriteLine(expectedArray);
                return true;
            }
            else
            {
                Console.WriteLine(expectedArray);
                return false;
            }
        }

        public bool IsPageLoaded(By selector1, By selector2, By selector3)
        {
            return VerifyExpectedElementsAreDisplayed(selector1) &&
                   VerifyExpectedElementsAreDisplayed(selector2) &&
                   VerifyExpectedElementsAreDisplayed(selector3);
        }

        public bool VerifyExpectedElementsAreDisplayed(By by)
        {
            return
                IsElementDisplayed(by) &&
                IsElementEnabled(by);
        }

        public bool IsElementEnabled(By by)
        {
            try
            {
                return _driver.FindElement(by).Enabled;
            }
            catch (NullReferenceException)
            {
                return false;
            }
        }

        public bool VerifyExpectedTitleIsDisplayed(By by, string text)
        {
            var textFromElement = _driver.FindElement(by).Text;
            return textFromElement.Contains(text);
        }


        #endregion

        #region Waiters

        public void WaitElementDisplayed(By by)
        {
            WaitElement(by);
            _wait.Until(d => IsElementDisplayed(by));
        }

        public void WaitElement(By by)
        {
            _wait.Until(d => IsElementExists(by));
        }

        public bool IsElementExists(By by)
        {
            try
            {
                _driver.FindElement(by);
                return true;
            }

            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool IsElementDisplayed(By by)
        {
            try
            {
                return _driver.FindElement(by).Displayed;
            }

            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool IsElementDisplayedWithWaiter(By selector)
        {
            try
            {
                //WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(3));
                _wait.Until(d => IsElementDisplayed(selector));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        public bool IsElementDisplayedWithCustomWait(By by)
        {
            try
            {
                _customDriverWait.Until(d => IsElementDisplayed(by));
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        #endregion

    }
}