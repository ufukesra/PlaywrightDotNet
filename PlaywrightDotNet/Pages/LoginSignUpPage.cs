using Microsoft.Playwright;
using PlaywrightDotNet.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightDotNet.Pages
{
    public class LoginSignUpPage : TestBase
    {
        private readonly Driver _driver;
        public LoginSignUpPage(Driver driver) : base(driver)
        {
            _driver = driver;

        }

         private string loginForm="Login to your account";
        private string signUpForm="New User Signup!";
        public ILocator UserNameLogin => _driver.Page.Locator("//h2[text()='"+loginForm+"']/following-sibling::form/input[2]");
        public ILocator PasswordLogin => _driver.Page.Locator("//h2[text()='"+loginForm+"']/following-sibling::form/input[3]");
        public ILocator LoginButton => _driver.Page.Locator("//h2[text()='"+loginForm+"']/following-sibling::form/button");
        public ILocator ErrorMessage => _driver.Page.Locator("//h2[text()='"+loginForm+"']/following-sibling::form/p");
        
        public ILocator UserNameSignUp => _driver.Page.Locator("//h2[text()='"+signUpForm+"']/following-sibling::form/input[2]");
        public ILocator EmailSignUp => _driver.Page.Locator("//h2[text()='"+signUpForm+"']/following-sibling::form/input[3]");
        public ILocator SignUpButton => _driver.Page.Locator("//h2[text()='"+signUpForm+"']/following-sibling::form/button");
        public ILocator AccountPageHeader=> _driver.Page.Locator("(//h2[@class='title text-center'])[1]/b");

        public ILocator Gender1 => _driver.Page.Locator("[id=id_gender1]");
        public ILocator Gender2 => _driver.Page.Locator("[id=id_gender2]");
        public ILocator PasswordInput=> _driver.Page.Locator("[id=password]");

        public ILocator DayInput=> _driver.Page.Locator("[id=days]");
        public ILocator MonthInput=> _driver.Page.Locator("[id=months]");
        public ILocator YearInput=> _driver.Page.Locator("[id=years]");
        public ILocator NewsletterCheckbox => _driver.Page.Locator("[id=newsletter]");

        //Address Information
        public ILocator FirstNameInput => _driver.Page.Locator("[id=first_name]");
        public ILocator LastNameInput => _driver.Page.Locator("[id=last_name]");
        public ILocator CompanyInput => _driver.Page.Locator("[id=company]");
        public ILocator Address1Input => _driver.Page.Locator("[id=address1]");
        public ILocator Address2Input => _driver.Page.Locator("[id=address2]");
        public ILocator CountryDropDown => _driver.Page.Locator("[id=country]");
        public ILocator CityInput => _driver.Page.Locator("[id=city]");
        public ILocator StateInput => _driver.Page.Locator("[id=state]");
        public ILocator PostCodeInput => _driver.Page.Locator("[id=zipcode]");
        public ILocator MobileInput => _driver.Page.Locator("[id=mobile_number]");
        public ILocator AliasInput => _driver.Page.Locator("[id=alias]");
        public ILocator RegisterButton => _driver.Page.Locator("(//button[starts-with(@type,'submit')])[1]");

        public ILocator AccountCreated => _driver.Page.Locator("//h2[@data-qa='account-created']/b");

        public ILocator ContinueButton => _driver.Page.Locator("//a[text()='Continue']");
        

    }
}