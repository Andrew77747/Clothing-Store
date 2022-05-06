using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using SeleniumExtras.WaitHelpers;

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
            //_wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //_wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
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

        public void ScrollIntoViewElement(By by)
        {
            //IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            //js.ExecuteScript("arguments[0].scrollIntoView();", element);

            var e = _driver.FindElement(by);
            // JavaScript Executor to scroll to element
            ((IJavaScriptExecutor)_driver)
                .ExecuteScript("arguments[0].scrollIntoView(true);", e);
            //Console.WriteLine(e.Text);
        }

        public void RefreshPage()
        {
            _driver.Navigate().Refresh();
        }

        public void NavigateToUrl(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public void TypeAndSend(By by, string text)
        {
            FindElement(by).SendKeys(text);
        }

        public void UploadFiles(By selector, string path)
        {
            _driver.FindElement(selector).SendKeys(path);
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

        public List<IWebElement> FindElements(By by)
        {
            //WaitElementDisplayed(by);
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
            var allElementsWithText = FindElements(selector);
            List<string> names = new();

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

        public string[] GetElementsTextArray(By selector)
        {
            var allElementsWithText = FindElements(selector);
            string[] names = new string[allElementsWithText.Count];

            for (int i = 0; i < names.Length; i++)
            {
                names[i] = allElementsWithText[i].Text;
                Console.WriteLine(names[i]);
            }

            return names;
        }

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

        public string GetElementText(By selector)
        {
            string name = FindElement(selector).Text;
            return name;
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

        public void HoverMouseOnElement(IWebElement element)
        {
            try
            {
                Actions action = new Actions(_driver);
                action.MoveToElement(element).Build().Perform();
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("There is no such element! Error: " + e);
            }
        }

        public void PointToElement(By selector)
        {
            Actions action = new Actions(_driver);
            //action.MoveToElement(FindElement(By.CssSelector(selector))).Build().Perform();
            action.MoveToElement(FindElement(selector)).Build().Perform();
        }

        public void MoveElement(By selector, int x, int y)
        {
            try
            {
                Actions action = new Actions(_driver);
                action.MoveToElement(FindElement(selector)).ClickAndHold().MoveByOffset(x, y).Release().Perform();
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("There is no such element! Error: " + e);
            }
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
                FindElement(By.XPath($"//*[contains(text(), '{text}')]"));
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

        public string GetValuesOfAttribute(IWebElement element, string value)
        {
            return element.GetAttribute(value);
        }

        public string[] GetValuesOfAttributeList(By selector, string value, By selector2)
        {
            //var allElementsWithText = GetElements(selector);
            //string[] names = new string[allElementsWithText.Count];
            List<IWebElement> ElementsWithNamesAttribute = GetElements(selector);
            string[] names = new string[ElementsWithNamesAttribute.Count];
            //List<string> names = new List<string>();

            for (int i = 0; i < names.Length; i++)
            {
                names[i] = GetValuesOfAttribute(selector2, value);
                Console.WriteLine(names[i]);
            }

            //foreach (var name in names)
            //{
            //    name = GetValuesOfAttribute(selector, value);
            //}

            return names;
        }

        public bool IsAttributeValueEqual(By selector, string text)
        {
            if (GetValuesOfAttribute(selector, "value") == text)
                return true;
            return false;
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

        public string CutPartTextFromMiddleWithAllTextValue(string actualText, string deleteTextBefore, string deleteTextAfter) // Лучше метод. Работает по целым словам
        {
            Match match = Regex.Match(actualText, $@"{deleteTextBefore}(.*?){deleteTextAfter}");

            string x = match.Groups[1].Value;
            return x;
        }

        public string CutFirstPartTextWithAllTextValue(string actualText, string deleteTextBefore)
        {
            Match match = Regex.Match(actualText, $@"{deleteTextBefore}(.*)");
            return match.Groups[1].Value;
        }

        public string CutLastPartTextWithAllTextValue(string actualText, string deleteTextAfter)
        {
            Match match = Regex.Match(actualText, $@"(.*){deleteTextAfter}");
            return match.Groups[1].Value;
        }

        public string CutPartTextFromMiddle(string actualText, string deleteBefore, string deleteAfter) // Работает только по символам
        {
            Match match = Regex.Match(actualText, $@"(?<={deleteBefore})[^{deleteAfter}]*");
            return match.Value;
        }

        public int TotalAmount(string[] actualArray)
        {
            for (int i = 0; i < actualArray.Length; i++)
            {
                actualArray[i] = actualArray[i].Replace(" ", string.Empty);
                actualArray[i] = actualArray[i].Replace("₽", string.Empty);
            }

            int[] intActualArray = new int[actualArray.Length];

            for (int i = 0; i < actualArray.Length; i++)
            {
                intActualArray[i] = Int32.Parse(actualArray[i]);
            }

            int totalAmount = 0;

            for (int i = 0; i < actualArray.Length; i++)
            {
                totalAmount += intActualArray[i];
            }

            return totalAmount;
        }

        public bool IsSortingPriceAskRightStringToInt(string[] actualArray)
        {
            for (int i = 0; i < actualArray.Length; i++)
            {
                actualArray[i] = actualArray[i].Replace(" ", string.Empty);
                actualArray[i] = actualArray[i].Replace("₽", string.Empty);
            }

            int[] expectedArray = new int[actualArray.Length];

            int[] intActualArray = new int[actualArray.Length];

            for (int i = 0; i < actualArray.Length; i++)
            {
                intActualArray[i] = Int32.Parse(actualArray[i]);
            }

            intActualArray.CopyTo(expectedArray, 0);

            Array.Sort(expectedArray);

            if (intActualArray.SequenceEqual(expectedArray))
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

        public void ClickCheckbox(By selector)
        {
            string value = "class";

            var x = GetValuesOfAttribute(selector, value);
            if (!x.Contains("active"))
            {
                ClickElement(selector);
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
            var textFromElement = FindElement(by).Text;
            return textFromElement.Contains(text);
        }

        public bool VerifyExpectedTitleIsDisplayedFull(By by, string text)
        {
            var textFromElement = FindElement(by).Text;
            if (textFromElement.Equals(text))
            {
                return true;
            }
            return false;
        }


        #endregion

        #region Waiters

        public void WaitPageLoaded(By by1, By by2, By by3)
        {
            _wait.Until(d => IsPageLoaded(by1, by2, by3));
        }

        // ждем, что элемент исчезнет из дом
        public void WaitElementNotExists()
        {

        }

        // ждем, что элемент не видимый
        public void WaitElementDisappear(By by)  //// какой правильный?
        {
            _wait.Until(d => !d.FindElement(by).Displayed);
            _wait.Until(d => IsElementNotDisplayed2(by));
        }

        // bool ждем, что нескольких элементов не будет в доме
        public void WaitElementNotExists(By by)
        {
            _wait.Until(d => d.FindElements(by).Count == 0);
        }


        // bool ждем, что нескольких элементов не будут видимыми
        public void WaitElementsNotVisible(By by)
        {
            _wait.Until(d => IsElementsNotExistOrDisplayed(by));
        }

        public void WaitElementDisplayed(By by)
        {
            WaitElement(by);
            _wait.Until(d => IsElementDisplayed(by));
        }

        // Можно ли так использовать?
        public void WaitElementInvisible(By by)
        {
            //WaitElement(by);
            ////_wait.Until(d => IsElementNotDisplayed(by));
            //_wait.Until(ExpectedConditions.StalenessOf(FindElement(By.CssSelector(by))));
            _wait.Until(ExpectedConditions.InvisibilityOfElementLocated(by));
        }

        //public void WaitElementInvisible2(By by) //
        //{
        //    //WaitElement(by);
        //    //_wait.Until(d => IsElementNotDisplayed(by));
        //    _wait.Until(d => IsElementNotDisplayed(by));
        //}

        // как эти два метода ожидания плюс и минус элемент?
        public void WaitElementMinus(List<IWebElement> realCount, List<IWebElement> elem)
        {
            //var listOfElement = FindElements(by);
            //_wait.Until(d => FindElements(by).Count == listOfElement.Count - 1);
            //var x = FindElements(By.CssSelector(".ic__set.ic__set__close"));
            //_wait.Until(d => x.Count.Equals(elem.Count - 1));
            _wait.Until(d => xxx(realCount, elem));
        }

        public bool xxx(List<IWebElement> realCount, List<IWebElement> elem)
        {
            var real = realCount;
            return real.Count.Equals(elem.Count - 1);
        }

        public void WaitElementMinusInList(List<IWebElement> list)
        {

            _wait.Until(d => list.Count == list.Count - 1);
        }

        public void WaitElementPlus(By by)
        {
            var listOfElement = FindElements(by);
            _wait.Until(d => d.FindElements(by).Count == listOfElement.Count + 1);
        }

        public bool IsElementElementPlus(By by)
        {
            var listOfElement = FindElements(by);

            return _wait.Until(d => FindElements(by).Count == listOfElement.Count + 1);
        }

        //public void WaitForElementNotExist(IWebElement element)
        //{
        //    //var wait = new WebDriverWait(browser.WebDriver, TimeSpan.FromSeconds(timeout));
        //    //wait.PollingInterval = TimeSpan.FromMilliseconds(DefaultPollingValue);
        //    _wait.Until(d => IsElementNotDisplayedElem(element));
        //}

        public void WaitElement(By by)
        {
            _wait.Until(d => IsElementExists(by));
        }

        public bool IsTextContains(By fullTextSelector, string searchedText)
        {
            if (GetElementText(fullTextSelector).Contains(searchedText))
            {
                return true;
            }

            return false;
        }

        public bool IsTextContains(By fullTextSelector, By searchedTextSelector)
        {
            if (GetElementText(fullTextSelector).Contains(GetElementText(searchedTextSelector)))
            {
                return true;
            }

            return false;
        }

        public int GetElementCount(By selector)
        {
            int totalCountElements = 0;

            var listOfElements = GetElements(selector);
            totalCountElements += listOfElements.Count;

            return totalCountElements;
        }

        public int GetElementCount2(By by)
        {
            var countOfElements = GetElements(by).Count;
            return countOfElements;
        }

        public int GetElementCount3(By selector)
        {
            return _driver.FindElements(selector).Count;
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

        //public bool IsElementNotDisplayed(By by) //
        //{
        //    try
        //    {
        //        return _driver.FindElement(by).Displayed;
        //    }
        //    catch (NoSuchElementException)
        //    {
        //        // Returns true because the element is not present in DOM. The
        //        // try block checks if the element is present but is invisible.
        //        return true;
        //    }
        //    catch (StaleElementReferenceException)
        //    {
        //        // Returns true because stale element reference implies that element
        //        // is no longer visible.
        //        return true;
        //    }
        //}

        // 2 bool
        public bool IsElementsNotExistOrDisplayed(By by)  /////////  Хороший метод, что нескольких элементов нет. Может разбить на NotExist и NotDisplayed
        {
            ReadOnlyCollection<IWebElement> elements = _driver.FindElements(by);
            if (elements.Count == 0 || !elements[0].Displayed)
            {
                return true;
            }
            return false;
        }

        public void WaitForElementNotExistsOrDisplayed(By by)
        {
            _wait.Until(d => IsElementsNotExistOrDisplayed(by));
        }

        public bool IsElementsNotDisplayed(IWebElement elem)  /////////  Хороший метод, что элемент не виден, когда у нас уже есть список элементов
        {
            if (!elem.Displayed)
            {
                return true;
            }
            return false;
        }

        public void WaitForElementNotDisplayed(IWebElement elem) /////////  Хороший вэйтер, что элемент не виден, когда у нас уже есть список элементов
        {
            _wait.Until(d => IsElementsNotDisplayed(elem));
        }




        public bool IsElementsNotDisplayed(By by)  /////////  Хороший метод, что элемент не виден
        {
            IWebElement element = _driver.FindElement(by);
            if (!element.Displayed)
            {
                return true;
            }
            return false;
        }

        public void WaitForElementNotDisplayed(By by) /////////  Хороший вэйтер, что элемент не виден
        {
            _wait.Until(d => IsElementsNotDisplayed(by));
        }

        public bool IsAttributeContains(IWebElement element, string attribute, string value)
        {
            var x = GetValuesOfAttribute(element, attribute);
            return x.Contains(value);
        }

        public bool IsAttributeNotContains(IWebElement element, string attribute, string value)
        {
            var x = GetValuesOfAttribute(element, attribute);
            if (x.Contains(value))
                return false;
            return true;
        }

        public void WaitForAttributeContains(IWebElement element, string attribute, string value)
        {
            _wait.Until(d => IsAttributeContains(element, attribute, value));
        }

        public void WaitForMoreElements(int countBefore, By by)
        {
            _wait.Until(d => IsElementsGetMore(countBefore, by));
        }

        public bool IsElementsGetMore(int countBefore, By by)
        {
            var listOfElements = FindElements(by).Count;
            if (listOfElements > countBefore)
            {
                return true;
            }

            return false;
        }

        //public bool IsElementNotDisplayedElem(IWebElement element) //
        //{
        //    try
        //    {
        //        return element.Displayed;
        //    }
        //    catch (NoSuchElementException e)
        //    {
        //        // Returns true because the element is not present in DOM. The
        //        // try block checks if the element is present but is invisible.
        //        return true;
        //    }
        //    catch (StaleElementReferenceException e)
        //    {
        //        // Returns true because stale element reference implies that element
        //        // is no longer visible.
        //        return true;
        //    }
        //}

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

        // 1 bool может try catch
        public bool IsElementNotDisplayed2(By selector)   //////////////////// Хороший метод для проверки, что элемент не видим
        {
            if (!_driver.FindElement(selector).Displayed)
            {
                return true;
            }

            return false;
        }

        // 0 bool как сделать bool метод, что элемента нет в доме
        public bool IsElementNotExists(By selector)   //////////////////// 
        {
            //if (_driver.FindElement(selector))
            {
                return true;
            }

            return false;
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