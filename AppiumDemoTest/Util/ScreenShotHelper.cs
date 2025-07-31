using OpenQA.Selenium.Appium;
using OpenQA.Selenium;

namespace AppiumDemoTest.Util
{
    public static class ScreenshotHelper
    {
        public static string CaptureScreenshot(AppiumDriver driver, string stepName)
        {
            try
            {
                string screenshotsDir = Path.Combine(Directory.GetCurrentDirectory(), "TestResults", "Screenshots");
                Directory.CreateDirectory(screenshotsDir);

                string fileName = $"{stepName}_{DateTime.Now:yyyyMMdd_HHmmss}.png";
                string filePath = Path.Combine(screenshotsDir, fileName);

                Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                screenshot.SaveAsFile(filePath);

                return filePath;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to capture screenshot: " + ex.Message);
                return string.Empty;
            }
        }
    }
}
