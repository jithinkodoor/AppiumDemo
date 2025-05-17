using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Support.UI;
using System;

namespace AppiumDemoTest.Pages
{
    public class BasePage
    {
        protected AppiumDriver Driver;
        protected WebDriverWait wait;

        public BasePage(AppiumDriver driver)
        {
            Driver = driver ?? throw new ArgumentNullException(nameof(driver));
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        protected IWebElement WaitForElement(By by)
        {
            return wait.Until(driver => driver.FindElement(by));
        }

        protected void Click(By by)
        {
            WaitForElement(by).Click();
        }

        protected void EnterText(By by, string text)
        {
            var element = WaitForElement(by);
            element.Clear();
            element.SendKeys(text);
        }

        protected string GetText(By by)
        {
            return WaitForElement(by).Text;
        }
    }
}
