using OpenQA.Selenium.Appium.Android;
using Reqnroll;
using AppiumDemoTest.Pages;
using OpenQA.Selenium.Appium;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Xml.Linq;

namespace AppiumDemoTest.StepDefinitions
{
    [Binding]
    public class AppiumDemoSteps
    {
        private AppiumDriver _driver;
        private LoginPage loginPage;
        private LandingPage landingPage;
        private AppiumElement? loginPageTitle;
        private ProductPage productPage;
        public AppiumDemoSteps(ScenarioContext scenarioContext)
        {
            _driver = scenarioContext["driver"] as AppiumDriver ?? throw new ArgumentNullException("WebDriver not found");
            loginPage = new LoginPage(_driver, new ArgumentNullException("WebDriver not found"));
            landingPage = new LandingPage(_driver);
            productPage= new ProductPage(_driver, new ArgumentNullException("WebDriver not found"));
        }

        [Given("the user has logged in to the mobile app")]
        public void GivenTheUserHasLoggedInToTheMobileApp()
        {
            landingPage.NavigateToLoginPage();
            loginPageTitle = loginPage.Login();
        }

        [Given("user verifies the page title")]
        public void GivenUserVerifiesThePageTitle()
        {
            if(Environment.GetEnvironmentVariable("PLATFORM")?.ToLower() == "android")
                Assert.That(loginPageTitle, Is.Not.Null, "Login is failed");
        }

        [When("the user adds the first product to the cart")]
        public void WhenTheUserAddsTheFirstProductToTheCart()
        {
            
        }

        [When("the user adds the {int} of product or products to the cart")]
        public void WhenTheUserAddsTheProductToTheCart(int numberOfProducts)
        {
            productPage.AddProductToCart(numberOfProducts);
            
        }
        [Then("user can see the  {int} of product or products in the cart")]
        public void ThenUserCanSeeTheOfProductInTheCart(int numberOfProducts)
        {
            Assert.That(productPage.VerifyCartCount(numberOfProducts), Is.Not.Null, "Product not added to the cart");
        }
        
    }
}
