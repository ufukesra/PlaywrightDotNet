using System;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework;
using PlaywrightDotNet.Pages;
using PlaywrightDotNet.Utilities;
using Reqnroll;
using static Microsoft.Playwright.Assertions;



namespace PlaywrightDotNet.StepDefinitions{
[Binding]

public class LoginSignUpStepDefinitions : TestBase{
    private readonly Driver _driver;
    private readonly LoginSignUpPage _loginSignUp;

        public LoginSignUpStepDefinitions(Driver driver) : base(driver)
        {
            _driver = driver;
            _loginSignUp= new LoginSignUpPage(_driver);
        }

        
        [When("User clicks to SignUp_Login module")]
        public async Task WhenUserClicksToSignUpLoginModule()
        {
            await _driver.Page.Locator("//a[@href='/login']").ClickAsync();
        }

        [When("User enters invalid username")]
        public async Task WhenUserEntersInvalidUsername()
        {
            await _loginSignUp.UserNameLogin.FillAsync(Configuration.Instance.TestParameters.Username);
    
        }

        [When("User enters invalid password")]
        public async Task WhenUserEntersInvalidPassword()
        {
            await _loginSignUp.PasswordLogin.FillAsync(Configuration.Instance.TestParameters.Password);
    
        }

        [When("User clicks login button")]
        public async Task WhenUserClicksLoginButton()
        {
            await _loginSignUp.LoginButton.ClickAsync();
    
        }

        [Then("User verifies the error message {string}")]
        public async Task ThenUserVerifiesTheErrorMessage(string errorMessage)
        {
            await Expect(_loginSignUp.ErrorMessage).ToHaveTextAsync(errorMessage);
        }



    }
}