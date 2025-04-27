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
        public ILocator PasswordSignUp => _driver.Page.Locator("//h2[text()='"+signUpForm+"']/following-sibling::form/input[3]");
        public ILocator SignUpButton => _driver.Page.Locator("//h2[text()='"+signUpForm+"']/following-sibling::form/button");
    }
}