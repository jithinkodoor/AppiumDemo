using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace AppiumDemoTest.Pages
{
    public class LandingPage : BasePage
    {
        private new readonly AppiumDriver? Driver;

        public LandingPage(AppiumDriver _driver) : base(_driver)
        {
            Driver = _driver ?? throw new ArgumentNullException("WebDriver not found");
        }

        private By MenuElement => Environment.GetEnvironmentVariable("PLATFORM")?.ToLower() == "ios"
    ?   MobileBy.XPath("//XCUIElementTypeButton[@name=\"tab bar option menu\"]")
    :   MobileBy.XPath("//android.view.ViewGroup[@content-desc=\"open menu\"]/android.widget.ImageView");

        private By LoginElement => Environment.GetEnvironmentVariable("PLATFORM")?.ToLower() == "ios"
        ? MobileBy.XPath("//XCUIElementTypeOther[@name=\"menu item log in\"]")
        : MobileBy.XPath("//android.view.ViewGroup[@content-desc=\"menu item log in\"]");


        public void NavigateToLoginPage()
        {

            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            var menuButton = wait.Until(Driver => Driver.FindElement(MenuElement));
            menuButton.Click();
            var loginButton = wait.Until(Driver => Driver.FindElement(LoginElement));
            loginButton.Click();

        }
        public void VerifyTitle()
        {
            var element = Driver?.FindElement(MobileBy.XPath("//android.view.ViewGroup[@content-desc=\"open menu\"]/android.widget.ImageView"));
            element?.Click();
            var loginLink = Driver?.FindElement(MobileBy.XPath("//android.view.ViewGroup[@content-desc=\"menu item log in\"]"));            
            loginLink?.Click();
            //Assert.Equals("Welcome", element.Text);
        }
    }
}


