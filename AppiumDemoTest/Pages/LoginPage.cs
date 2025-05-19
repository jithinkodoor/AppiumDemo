using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Support.UI;

namespace AppiumDemoTest.Pages
{
    public class LoginPage : BasePage
    {
        private new readonly AppiumDriver? Driver;

        public LoginPage(AppiumDriver _driver) : base(_driver) 
        {
            Driver = _driver ?? throw new ArgumentNullException("WebDriver not found");
        }

        private By UsernameField => Environment.GetEnvironmentVariable("PLATFORM")?.ToLower() == "ios"
            ? MobileBy.XPath("//XCUIElementTypeTextField[@name=\"Username input field\"]")
            : MobileBy.XPath("//android.widget.EditText[@content-desc=\"Username input field\"]");

        private By PasswordField => Environment.GetEnvironmentVariable("PLATFORM")?.ToLower() == "ios"
            ? MobileBy.XPath("//XCUIElementTypeSecureTextField[@name=\"Password input field\"]")
            : MobileBy.XPath("//android.widget.EditText[@content-desc=\"Password input field\"]");
           private By LoginButton => Environment.GetEnvironmentVariable("PLATFORM")?.ToLower() == "ios"
            ? MobileBy.XPath("//XCUIElementTypeOther[@name=\"Login button\"]")
            : MobileBy.XPath("//android.view.ViewGroup[@content-desc=\"Login button\"]");
         private By ProductsTitle => Environment.GetEnvironmentVariable("PLATFORM")?.ToLower() == "ios"
            ? MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"Products\"]")
            : MobileBy.XPath("//android.widget.TextView[@text=\"Products\"]");
           private By CatalogLink => Environment.GetEnvironmentVariable("PLATFORM")?.ToLower() == "ios"
            ? MobileBy.XPath("//XCUIElementTypeButton[@name=\"tab bar option catalog\"]")
            : MobileBy.XPath("//android.widget.TextView[@text=\"Products\"]");

     
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

            
            if (Environment.GetEnvironmentVariable("PLATFORM")?.ToLower() == "android")
            {
                var usernameField = (AppiumElement)wait.Until(driver => driver.FindElement(UsernameField));
                usernameField.SendKeys(username);
                Driver?.FindElement(PasswordField).SendKeys(password);
                Driver?.FindElement(LoginButton).Click();

            }
                       
            if (Environment.GetEnvironmentVariable("PLATFORM")?.ToLower() == "ios")
            {
                Driver?.FindElement(CatalogLink).Click();
                
            }
            var productsTitle = (AppiumElement)wait.Until(driver => driver.FindElement(ProductsTitle));
            return productsTitle;
        }
    }
}
