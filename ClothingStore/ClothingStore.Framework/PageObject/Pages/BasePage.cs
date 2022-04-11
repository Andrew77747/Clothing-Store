using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using ClothingStore.Framework.PageObject.Elements;
using ClothingStore.Framework.Tools;
using OpenQA.Selenium;

namespace ClothingStore.Framework.PageObject.Pages
{
    public class BasePage : BaseElement

    {
        protected BasePage(IWebDriverManager manager) : base(manager)
        {

        }
    }
}