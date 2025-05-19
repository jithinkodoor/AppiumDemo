using AppiumDemoTest.Config;
using OpenQA.Selenium;
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
        private static ICommandExecutor serverUri;

        public static AppiumDriver InitDriver()
        {

            var app = ConfigReader.Settings.App;
            if (Environment.GetEnvironmentVariable("PLATFORM")?.ToLower() == "android")
            {

                app = Directory.GetCurrentDirectory() + "\\Apk\\" + ConfigReader.Settings.App;
            }

            else
            {
                app = ConfigReader.Settings.App;
            }

            var options = new AppiumOptions
            {
                PlatformName = ConfigReader.Settings.PlatformName,
                DeviceName = ConfigReader.Settings.DeviceName,
                PlatformVersion = ConfigReader.Settings.PlatformVersion,
                AutomationName = ConfigReader.Settings.AutomationName,
                App= app
            };

            Uri serverUri = new Uri(ConfigReader.Settings.Host);      
            

            if (Environment.GetEnvironmentVariable("PLATFORM")?.ToLower() == "android")
            {

                return new AndroidDriver(serverUri, options);
            }
            else if (Environment.GetEnvironmentVariable("PLATFORM")?.ToLower() == "ios")
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
