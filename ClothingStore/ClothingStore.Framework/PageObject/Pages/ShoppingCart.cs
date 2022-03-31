using ClothingStore.Framework.Tools;
using OpenQA.Selenium;

namespace ClothingStore.Framework.PageObject.Pages
{
    public class ShoppingCart : BasePage
    {
        public ShoppingCart(IWebDriverManager manager) : base(manager)
        {

        }

        #region Maps of Elements

        private By _cardInShoppingCart = By.CssSelector(".multicart__item");
        private By _checkboxInCard = By.CssSelector(".multicart__item .ui-checkboxradio-icon");
        private By _deleteBtn = By.CssSelector(".multicart__items__manageLeftPanel [name='delete']");

        #endregion

        public bool IsGoodAdded(string name)
        {
            return Wrapper.VerifyExpectedTitleIsDisplayed(_cardInShoppingCart, name);
        }

        public void CleanShoppingCart()
        {
            if (Wrapper.IsElementExists(_cardInShoppingCart))
            {
                var checkboxes = Wrapper.FindElements(_checkboxInCard);

                foreach (var checkbox in checkboxes)
                {
                    checkbox.Click();
                }

                Wrapper.ClickElement(_deleteBtn);
            }
        }
    }
}