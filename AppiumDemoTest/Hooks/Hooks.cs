using AppiumTestProject.Drivers;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using Reqnroll;


namespace AppiumDemoTest.Hooks
{
    [Binding]
    public sealed class Hooks
	{
		private readonly ScenarioContext _scenarioContext;
		private AppiumDriver driver;

		public Hooks(ScenarioContext scenarioContext)
		{
			_scenarioContext = scenarioContext;
		}

		[BeforeScenario]
		public void BeforeScenario()
		{
			driver = DriverFactory.InitDriver();
			_scenarioContext["driver"] = driver;
		}
		[AfterScenario]
		public void TearDown()
		{
			if (driver != null)
				driver.Quit();
		}
	}
}
