using AppiumTestProject.Drivers;
using OpenQA.Selenium.Appium;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Reqnroll;
using AventStack.ExtentReports.Gherkin.Model;
using AppiumDemoTest.Util;

namespace AppiumDemoTest.Hooks
{
    [Binding]
    public sealed class Hooks
	{
        private static ExtentReports? _extent;
        private static ExtentSparkReporter? _sparkReporter;
        private static ExtentTest? _feature;
        private static readonly AsyncLocal<ExtentTest> _scenario = new();
        private readonly ScenarioContext _scenarioContext;
		private AppiumDriver? driver;

		public Hooks(ScenarioContext scenarioContext)
		{
			_scenarioContext = scenarioContext;
		}

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            string fileName = $"AppiumDemo_{DateTime.Now:yyyyMMdd_HHmmss}.html";
            var solutionDir = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)?.Parent?.Parent?.Parent?.FullName;
            var reportPath = Path.Combine(solutionDir, "TestResults", fileName);

            _sparkReporter = new ExtentSparkReporter(reportPath);
            _extent = new ExtentReports();
            _extent.AttachReporter(_sparkReporter);
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            _feature = _extent?.CreateTest(featureContext.FeatureInfo.Title);
        }

        [BeforeScenario]
		public void BeforeScenario()
		{
			driver = DriverFactory.InitDriver();
			_scenarioContext["driver"] = driver;
            _scenario.Value = _feature?.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);

        }
        [AfterStep]
        public void AfterStep()
        {
            var stepInfo = _scenarioContext.StepContext.StepInfo;
            var stepType = stepInfo.StepDefinitionType.ToString();

            if (_scenarioContext.TestError == null)
            {
                _scenario.Value?.CreateNode(stepType, stepInfo.Text);
            }
            else
            {
                var node = _scenario.Value?.CreateNode(stepType, stepInfo.Text)
                    .Fail(_scenarioContext.TestError.Message);

                var screenshotPath = ScreenshotHelper.CaptureScreenshot(driver, stepInfo.Text);
                if (!string.IsNullOrEmpty(screenshotPath))
                {
                    node?.AddScreenCaptureFromPath(screenshotPath);
                }
            }
        }
        [AfterScenario]
		public void TearDown()
		{
			if (driver != null)
				driver.Quit();
		}
        [AfterTestRun]
        public static void AfterTestRun()
        {
            _extent?.Flush();

        }
    }
}
