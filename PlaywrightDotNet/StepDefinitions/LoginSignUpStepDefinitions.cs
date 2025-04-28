using System;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework;
using PlaywrightDotNet.Pages;
using PlaywrightDotNet.Support;
using PlaywrightDotNet.Utilities;
using Reqnroll;
using Reqnroll.Infrastructure;
using Support;
using static Microsoft.Playwright.Assertions;
using Bogus;



namespace PlaywrightDotNet.StepDefinitions{
[Binding]

public class LoginSignUpStepDefinitions : TestBase{
    private readonly Driver _driver;
    private readonly LoginSignUpPage _loginSignUp;
    private string firstName=TestDataBuilder.firstName();
    private string lastName=TestDataBuilder.lastName();

        public LoginSignUpStepDefinitions(Driver driver) : base(driver)
        {
            _driver = driver;
            _loginSignUp= new LoginSignUpPage(_driver);
        }

        
        [When("User clicks to SignUp_Login module")]
        public async Task WhenUserClicksToSignUpLoginModule()
        {
            await _loginSignUp.LoginSignUpLink.ClickAsync();
        }

        [When("User enters invalid username")]
        public async Task WhenUserEntersInvalidUsername()
        {            await _loginSignUp.UserNameLogin.FillAsync(Configuration.Instance.TestParameters.InvalidUsername);
    
        }

        [When("User enters invalid password")]
        public async Task WhenUserEntersInvalidPassword()
        {
            await _loginSignUp.PasswordLogin.FillAsync(Configuration.Instance.TestParameters.InvalidPassword);
    
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

        //Registration

       [When("User enters name")]
        public async Task WhenUserEntersName()
        {
            string fullname = firstName+" "+lastName;
            await _loginSignUp.UserNameSignUp.FillAsync(fullname);
        }

        [When("User enters valid email")]
        public async Task WhenUserEntersValidEmail()
        {
            await _loginSignUp.EmailSignUp.FillAsync(TestDataBuilder.EmailGenerator());
        }

        [When("User clicks signUp button")]
        public async Task WhenUserClicksSignUpButton()
        {
            await _loginSignUp.SignUpButton.ClickAsync();
        }

        [Then("User validate account page {string}")]
        public async Task ThenUserValidateAccountPage(string headerText)
        {
            await Expect(_loginSignUp.AccountPageHeader).ToHaveTextAsync(headerText);
        }
        [Then("User select title")]
        public async Task ThenUserSelectTitle()
        {
            await _loginSignUp.Gender1.CheckAsync();
            
    
        }

        [When("User enter password")]
        public async Task WhenUserEnterPassword()
        {
            string password = TestDataBuilder.PasswordGenerator();
            await _loginSignUp.PasswordInput.FillAsync(password);
            //await BrowserUtils.CustomWaitAsync(5000);
        }

        [When("User enter DOB details")]
        public async Task WhenUserEnterDOBDetails()
        {
            string DOB= TestDataBuilder.DOBGenerator();
            string[] DOBArray = DOB.Split('/');
            string day= DOBArray[0];
            string month= DOBArray[1];
            string year= DOBArray[2];
            Console.WriteLine(day+month+year);
            
            
            await _loginSignUp.DayInput.SelectOptionAsync(day);
            await _loginSignUp.MonthInput.SelectOptionAsync(month);
            await _loginSignUp.YearInput.SelectOptionAsync(year);
            
        }

        [When("User checks the SignUp newslater checkbox")]
        public async Task WhenUserChecksTheSignUpNewslaterCheckbox()
        {
            await _loginSignUp.NewsletterCheckbox.CheckAsync();
        }

        [When("User enters address Information")]
        public async Task WhenUserEntersAddressInformation()
        {
            var faker = new Faker();
            
            
            
            await _loginSignUp.FirstNameInput.FillAsync(firstName);
            await _loginSignUp.LastNameInput.FillAsync(lastName);
            await _loginSignUp.CompanyInput.FillAsync(faker.Company.CompanyName());
            await _loginSignUp.Address1Input.FillAsync(faker.Address.StreetAddress());
            await _loginSignUp.Address2Input.FillAsync(faker.Address.SecondaryAddress());
            await _loginSignUp.CountryDropDown.SelectOptionAsync("United States");
            await _loginSignUp.StateInput.FillAsync(faker.Address.State());
            await _loginSignUp.CityInput.FillAsync(faker.Address.City());
            await _loginSignUp.PostCodeInput.FillAsync(faker.Address.ZipCode());
            await _loginSignUp.MobileInput.FillAsync(faker.Phone.PhoneNumber());

           
    
        }

        [When("User click create account button")]
        public async Task WhenUserClickCreateAccountButton()
        {
            await _loginSignUp.RegisterButton.ClickAsync();
             
        }


        [Then("User verifies successful registration with message {string}")]
        public async Task ThenUserVerifiesSuccessfulRegistrationWithMessage(string message)
        {
            await Expect(_loginSignUp.AccountCreated).ToHaveTextAsync(message);
            await BrowserUtils.CustomWaitAsync(3000);
        }

    }
}