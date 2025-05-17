using AppiumDemoTest.Config;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;
using Reqnroll.Configuration.JsonConfig;

namespace AppiumDemoTest.Pages
{
    public class LoginPage : BasePage
    {
        private new readonly AppiumDriver? Driver;

        public LoginPage(AppiumDriver _driver) : base(_driver) 
        {
            Driver = _driver ?? throw new ArgumentNullException("WebDriver not found");
        }


        private By UsernameField => MobileBy.XPath("//android.widget.EditText[@content-desc=\"Username input field\"]");
        private By PasswordField => MobileBy.XPath("//android.widget.EditText[@content-desc=\"Password input field\"]");
        private By LoginButton => MobileBy.XPath("//android.view.ViewGroup[@content-desc=\"Login button\"]");
        private By ProductsTitle => MobileBy.XPath("//android.widget.TextView[@text=\"Products\"]");
        private string username = ConfigReader.Settings.Username;
        private string password = ConfigReader.Settings.Password;


        public void EnterUsername(string username)
        {
            Driver?.FindElement(UsernameField).SendKeys(username);
        }

        public void EnterPassword(string password) => Driver?.FindElement(PasswordField).SendKeys(password);
        public void TapLogin() => Driver?.FindElement(LoginButton).Click();

   
        public AppiumElement Login()
        {
            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

            var usernameField = (AppiumElement)wait.Until(driver => driver.FindElement(UsernameField));
            usernameField.SendKeys(username);
            Driver?.FindElement(PasswordField).SendKeys(password);
            Driver?.FindElement(LoginButton).Click();
            var productsTitle = (AppiumElement)wait.Until(driver => driver.FindElement(ProductsTitle));
            return productsTitle;

        }
    }
}
