using System;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework;
using PlaywrightDotNet.Pages;
using PlaywrightDotNet.Utilities;
using Reqnroll;
using static Microsoft.Playwright.Assertions;

namespace PlaywrightDotNet.StepDefinitions
{
    [Binding]
    public class HomePageStepDefinition : TestBase
    {
        private readonly Driver _driver;
        private readonly HomePage _homePage;

        public HomePageStepDefinition(Driver driver) : base(driver)
        {
            _driver = driver;
            _homePage = new HomePage(_driver);
        }


        [Given("User enters valid email")]
        public async Task GivenUserEntersValidEmail()
        {
            await _homePage.UserNameLogin.FillAsync(Configuration.Instance.TestParameters.Username);
        }

        [Given("User enters valid password")]
        public async Task GivenUserEntersValidPassword()
        {
            await _homePage.PasswordLogin.FillAsync(Configuration.Instance.TestParameters.Password);
        }

        [Given("User clicks Login button")]
        public async Task GivenUserClicksLoginButton()
        {
            await ClassLocatorStartsWith("span", "login-button","1").ClickAsync();
        }

        [Then("User verifies successfull login")]
        public async Task ThenUserVerifiesSuccessfullLogin()
        {
            var isExist = await ClassLocatorStartsWith("span", "text-success fw-bold", "1").InnerTextAsync();
            Assert.IsTrue(isExist.Contains(Configuration.Instance.TestParameters.Username));
        }

         [Given("User navigates to landing page")]
        public async Task GivenUserNavigatesToLandingPage()
        {
            string urlToNavigate = Configuration.Instance.UrlPath;
            await _driver.Page.GotoAsync(urlToNavigate);
            await _homePage.Consent.ClickAsync();
        }


        [Then("User validates the Page Title {string}")]
        public async Task ThenUserValidatesThePageTitle(string pageTitle)
        {
            var title = await _driver.Page.TitleAsync();
            //Console.WriteLine("TITLE: "+title);
            Assert.AreEqual(pageTitle, title);
            
        }

    [Then("User validates the Page Header {string}")]
        public async Task ThenUserValidatesThePageHeader(string expectedPageHeader)
        {
            //Console.WriteLine("HEADER:"+await _homePage.PageHeader.InnerTextAsync());
            await Expect(_homePage.PageHeader).ToHaveTextAsync(expectedPageHeader);
        }
    }
}
