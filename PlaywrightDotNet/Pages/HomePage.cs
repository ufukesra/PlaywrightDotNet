using Microsoft.Playwright;
using PlaywrightDotNet.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightDotNet.Pages
{
    public class HomePage
    {
        private readonly Driver _driver;
        public HomePage(Driver driver)
        {
            _driver = driver;
        }
        public ILocator UserNameLogin => _driver.Page.Locator("//input[@data-testid='username']");
        public ILocator PasswordLogin => _driver.Page.Locator("//input[@name='password']");

        public ILocator Consent => _driver.Page.Locator("//p[text()='Consent']");
        public ILocator PageHeader => _driver.Page.Locator("(//h1/span)[1]/..");
        
    }
}
