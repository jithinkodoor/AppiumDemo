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
            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
        }

        private By FirstProduct => Environment.GetEnvironmentVariable("PLATFORM")?.ToLower() == "ios"
           ? MobileBy.XPath("//XCUIElementTypeOther[@name=\"Sauce Labs Backpack\"]")
           : MobileBy.XPath("(//android.view.ViewGroup[@content-desc=\"store item\"])[1]/android.view.ViewGroup[1]/android.widget.ImageView");

        private By AddToCartButton => Environment.GetEnvironmentVariable("PLATFORM")?.ToLower() == "ios"
          ? MobileBy.XPath("//XCUIElementTypeOther[@name=\"Add To Cart button\"]")
          : MobileBy.XPath("//android.view.ViewGroup[@content-desc=\"Add To Cart button\"]");
        private String cartCount => Environment.GetEnvironmentVariable("PLATFORM")?.ToLower() == "ios"
            ? "//XCUIElementTypeOther[@name='Add To Cart button']"
            : "//android.widget.TextView[@text=\"{0}\"]";


        public void AddProductToCart(int number)
        {
            var firstProduct = (AppiumElement)wait.Until(driver => driver.FindElement(FirstProduct));
            firstProduct.Click();

            var addToCartButton = (AppiumElement)wait.Until(driver => driver.FindElement(AddToCartButton));

            for (int i = 0; i < number; i++)
            {
                addToCartButton.Click();
                Thread.Sleep(500); // Optional: wait a bit for UI to update between clicks
            }
        }
        public AppiumElement VerifyCartCount(int number)
        {
            By cartElemCount = MobileBy.XPath(String.Format(cartCount, number.ToString()));
            return (AppiumElement)wait.Until(driver => driver.FindElement(cartElemCount));
        }
    }
}
