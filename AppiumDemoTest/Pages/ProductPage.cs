using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppiumDemoTest.Pages
{
    internal class ProductPage : BasePage
    {
        private new readonly AppiumDriver? Driver;

        public ProductPage(AppiumDriver _driver) : base(_driver)
        {
            Driver = _driver ?? throw new ArgumentNullException("WebDriver not found");
        }

        private By FirstProduct => MobileBy.XPath("(//android.view.ViewGroup[@content-desc=\"store item\"])[1]/android.view.ViewGroup[1]/android.widget.ImageView");
        private By AddToCartButton => MobileBy.XPath("//android.view.ViewGroup[@content-desc=\"Add To Cart button\"]");
        private By cartCount => MobileBy.XPath("//android.widget.TextView[@text=\"1\"]");

        public void AddFirstProductToCart()
        {
            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

            var firstProduct = (AppiumElement)wait.Until(driver => driver.FindElement(FirstProduct));
            firstProduct.Click();
            var addToCartButton = (AppiumElement)wait.Until(driver => driver.FindElement(AddToCartButton));            
            addToCartButton.Click();
           
        }
        public AppiumElement VerifyCartCount()
        {
           return Driver!.FindElement(cartCount);           

        }
    }
}
