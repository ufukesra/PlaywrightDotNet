
using System;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework;
using PlaywrightDotNet.Pages;
using PlaywrightDotNet.Utilities;
using Reqnroll;
using Support;
using static Microsoft.Playwright.Assertions;

namespace PlaywrightDotNet.StepDefinitions{
    [Binding]
    public class ProductPageStepDefinitions : TestBase
    {

        private readonly Driver _driver;
        private readonly ProductPage _productPage;
        private readonly LoginSignUpPage _loginSignUpPage; 
        public ProductPageStepDefinitions(Driver driver) : base(driver)
        {
            _driver = driver;
            _productPage = new ProductPage(_driver);
            _loginSignUpPage = new LoginSignUpPage(_driver);
        }

        [When("Enters valid email")]
        public async Task WhenEntersValidEmail()
        {
            await _loginSignUpPage.UserNameLogin.FillAsync(Configuration.Instance.TestParameters.ValidUsername);

        }

        [When("Enters valid password")]
        public async Task WhenEntersValidPassword()
        {
            await _loginSignUpPage.PasswordLogin.FillAsync(Configuration.Instance.TestParameters.ValidPassword);
        }
        [When("User manages to Product page and verifies with message {string}")]
        public async Task WhenUserManagesToProductPageAndVerifiesWithMessage(string header)
        {
            await _productPage.ProductPageLink.ClickAsync();
            await Expect(_productPage.PageHeader).ToHaveTextAsync(header);
        }
         

        [When("User enters {string} and click search button")]
        public async Task WhenUserEntersAndClickSearchButton(string tshirts)
        {
            await _productPage.ProductSearchInput.FillAsync(tshirts);
            await _productPage.SearchButton.ClickAsync();
        }

        [When("User filter brand POLO")]
        public async Task WhenUserFilterBrandPOLO()
        {
            await _productPage.PoloBrand.ClickAsync();
        }

        [Then("Verify products displayed based on selected brand")]
        public async Task ThenVerifyProductsDisplayedBasedOnSelectedBrand()
        {
            await _productPage.FirstProductView.ClickAsync();
            await Expect(_productPage.ProductBrandInfo).ToContainTextAsync("Polo");



        }








    }
}