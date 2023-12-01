using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace Lab11_12.Pages
{
    public class A1SmallPriceProductPage
    {
        private WebDriverWait _wait;
        private readonly IWebDriver _driver;

        [FindsBy(How = How.ClassName, Using = "quantity-selector-button--plus")]
        private IWebElement buttonPlusOne;

        [FindsBy(How = How.XPath, Using = "//div[@class='price-block-button']/button")]
        private IWebElement buttonAddToCart;


        [FindsBy(How = How.ClassName, Using = "quantity-selector-input")]
        private IWebElement quantityInput;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"page-content\"]/div[2]/div[2]/div/div/div/div/span[2]/h1")]
        private IWebElement productNameElement;


        public A1SmallPriceProductPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(_driver, this);
        }

        public A1SmallPriceProductPage GoToPage()
        {
            _driver.Navigate().GoToUrl("https://www.a1.by/ru/shop/accessories/covers/Atomic/Atomic-SENSE-Galaxy-A12-Cover/sense-galaxy-a12-red/p/14.1014064");
            return this;
        }

        public A1SmallPriceProductPage CloseCookieBanner()
        {
            IWebElement cookieCloseButton = _driver.FindElement(By.XPath("//*[@id=\"command\"]/div[3]/button[3]"));
            cookieCloseButton.Click();
            return this;
        }

        public float GetInitialProductPrice()
        {
            IWebElement productPrice = _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"final-price-id-for-ajax\"]/p/span")));
            string priceText = productPrice.Text;
            priceText = priceText.Replace("руб", "").Replace("&nbsp;", "").Replace(",", ".").Trim();
            return float.Parse(priceText);
        }

        public string GetIntialProductName()
        {
            return productNameElement.Text;
        }

        public int GetInitialProductQuantity()
        {
            string quantity = quantityInput.GetAttribute("value");
            return int.Parse(quantity);
        }

        public A1SmallPriceProductPage IncreaseQuantity(int times)
        {
            for (int i = 0; i < times - 1; i++)
            {
                buttonPlusOne.Click();
                Thread.Sleep(100);
            }
            return this;
        }


        public A1SmallPriceProductPage AddToCart()
        {
            buttonAddToCart.Click();
            return this;
        }

        public A1SmallPriceProductPage DeleteFromCart()
        {
            IWebElement buttonDeleteFromCart = _wait.Until(ExpectedConditions.ElementExists(By.XPath("//button[@aria-label='Удалить']")));
            IWebElement buttonDeleteConfirm = _wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"modal-remove-product-0\"]/div[3]/div/button[1]")));
            buttonDeleteFromCart.Click();
            buttonDeleteConfirm.Click();
            return this;
        }


        public bool IsPriceChangedCorrectly(float initalPrice, int times)
        {
            Thread.Sleep(1000);
            IWebElement productPrice = _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"final-price-id-for-ajax\"]/p/span")));
            string priceText = productPrice.Text;
            priceText = priceText.Replace("руб", "").Replace("&nbsp;", "").Trim();
            float currentPrice = float.Parse(priceText.Replace(",", "."));

            return initalPrice * times == currentPrice;
        }

        public bool IsProductInCart(string name, int quantity, float price)
        {
            string pName = _wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@class='review-item-main-info-card']/a/span"))).Text;
            int pQuantity = int.Parse(_wait.Until(ExpectedConditions.ElementExists(By.Id("i-qty0"))).GetAttribute("value"));
            float pPrice = float.Parse(_wait.Until(ExpectedConditions.ElementExists(By.Id("full-price_0_0"))).Text.Replace(",", "."));

            return name == pName && pQuantity == quantity && pPrice == (price * quantity);
        }

        public bool IsCartEmpty()
        {
            try
            {
                IWebElement cartEmptyEl = _wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"page-content\"]/div[2]/div/div/div/div/section/div/p")));
                return true;
            }
            catch (WebDriverTimeoutException e)
            {
                return false;
            }
        }
    }
}
