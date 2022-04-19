using System;
using System.Collections.Generic;
using ClothingStore.Framework.PageObject.Elements;
using ClothingStore.Framework.Tools;
using OpenQA.Selenium;

namespace ClothingStore.Framework.PageObject.Pages
{
    public class PersonalAreaViewedGoodsPage : BasePage
    {
        private readonly Header _header;

        public PersonalAreaViewedGoodsPage(IWebDriverManager manager) : base(manager)
        {
            _header = new Header(manager);
        }

        #region Map of Elements

        private By _clearBtn = By.CssSelector("[title='Очистить просмотренное']");
        private By _viewedGoodsList = By.CssSelector(".goods__items.minilisting");
        private By _clearModalBtn = By.CssSelector("[title='Очистить']");
        private By _goodTitle = By.CssSelector("[class='indexGoods__item__name']");

        #endregion

        public void ClearViewedGoods()
        {
            if (Wrapper.IsElementExists(_viewedGoodsList))
            {
                Wrapper.ClickElement(_clearBtn);
                Wrapper.ClickElement(_clearModalBtn);
            }
        }

        public List<string> GetGoodsList()
        {
            var titleList = Wrapper.GetElementsTextList(_goodTitle);
            titleList.Sort();
            return titleList;
        }
    }
}