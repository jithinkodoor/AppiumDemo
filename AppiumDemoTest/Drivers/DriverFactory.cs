using AppiumDemoTest.Config;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.iOS;
using System;

namespace AppiumTestProject.Drivers
{
    public class DriverFactory
    {
        public static AppiumDriver? driver;

        public static AppiumDriver InitDriver()
        {

            var options = new AppiumOptions
            {
                PlatformName = ConfigReader.Settings.PlatformName,
                DeviceName = ConfigReader.Settings.DeviceName,
                PlatformVersion = ConfigReader.Settings.PlatformVersion,
                AutomationName = ConfigReader.Settings.AutomationName,
                App= ConfigReader.Settings.App
            };

            Uri serverUri = new Uri("http://127.0.0.1:4723");

            if (ConfigReader.Settings.PlatformName.ToLower() == "android")
            {
                return new AndroidDriver(serverUri, options);
            }
            else if (ConfigReader.Settings.PlatformName.ToLower() == "ios")
            {
                return new IOSDriver(serverUri, options);
            }
            else
            {
                throw new ArgumentException("Unsupported platform: " + ConfigReader.Settings.PlatformName);
            }
  
        }

        public static void QuitDriver()
        {
            driver?.Quit();
        }
    }
}
