using System;
using System.Net.Mime;
using System.Text.RegularExpressions;
using ClothingStore.Framework.Tools;
using Infrastructure.Settings;
using OpenQA.Selenium;

namespace ClothingStore.Framework.PageObject.Pages
{
    public class CheckoutPage : BasePage
    {
        private Appsettings _settings;
        //private string text = "Доставка в пределах МКАД";
        public CheckoutPage(IWebDriverManager manager, Appsettings settings) : base(manager)
        {
            _settings = settings;
        }

        private By _nameInput = By.CssSelector("[title='Контактное лицо']");
        private By _phoneInput = By.CssSelector("[title='Мобильный телефон']");
        private By _emailInput = By.CssSelector("[title='E-mail']");
        private By _totalPrice = By.XPath("//*[contains(text(), 'Стоимость товаров')]");
        private By _totalBonus = By.XPath("//*[contains(text(), 'Вы получите ON-бонусов')]");
        private By _paymentAndDeliveryMethod = By.CssSelector(".note.note__blue");

        public bool IsNameCorrect()
        {
            return Wrapper.IsAttributeValueEqual(_nameInput, _settings.Name);
        }

        public bool IsPhoneCorrect()
        {
            return Wrapper.IsAttributeValueEqual(_phoneInput, _settings.Phone);
        }

        public bool IsEmailCorrect()
        {
            return Wrapper.IsAttributeValueEqual(_emailInput, _settings.Email);
        }

        public int GetFullPrice()
        {
            string textTotalPrice = Wrapper.GetElementText(_totalPrice);
            string cutPrice = Wrapper.CutPartTextFromMiddle(textTotalPrice, ":", "₽");
            string priceWithoutSpaces = cutPrice.Replace(" ", string.Empty);
            int intPrice = Convert.ToInt32(priceWithoutSpaces);

            return intPrice;
        }

        public int GetFullBonus()
        {
            string textTotalBonus = Wrapper.GetElementText(_totalBonus);
            string cutBonus = Wrapper.CutPartTextFromMiddle(textTotalBonus, ":", "₽");
            string priceWithoutSpaces = cutBonus.Replace(" ", string.Empty);
            int intBonus = Convert.ToInt32(priceWithoutSpaces);

            return intBonus;
        }

        //public string GetPaymentMethod()
        //{
        //    string textDeliveryAndPayment = Wrapper.GetElementText(_paymentAndDeliveryMethod);
        //    string cutPaymentMethod =
        //        Wrapper.CutPartTextFromMiddle(textDeliveryAndPayment, ": ", "\r\n");
        //    //string paymentMethodwithoutSpaces = cutPaymentMethod.Replace(" ", string.Empty);
        //    return cutPaymentMethod;

        //}

        //public string GetPaymentsAndDeliveryMethods()
        //{
        //    string textDeliveryAndPayment = Wrapper.GetElementText(_paymentAndDeliveryMethod);
        //    string cutDeliveryMethod =
        //        Wrapper.CutPartTextFromMiddle(textDeliveryAndPayment, "Москва, ", "Д");
        //    return cutDeliveryMethod;
        //}

        //public string GetPaymentsAndDeliveryMethods()
        //{
        //    string textDeliveryAndPayment = Wrapper.GetElementText(_paymentAndDeliveryMethod);
        //    return textDeliveryAndPayment;
        //}

        //public bool IsTextContains(string text) 
        //{
        //    if (GetPaymentsAndDeliveryMethods().Contains(text))
        //    {
        //        return true;
        //    }

        //    return false;
        //}

        public bool IsTextContainsPaymentsAndDeliveryMethods(string text)
        {
            return Wrapper.IsTextContains(_paymentAndDeliveryMethod, text);
        }
    }
}