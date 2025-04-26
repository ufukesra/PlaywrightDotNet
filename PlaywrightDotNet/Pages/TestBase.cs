using Microsoft.Playwright;
using PlaywrightDotNet.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightDotNet.Pages
{
    public class TestBase
    {
        public static  Driver _driver;
        public ILocator ClassLocatorStartsWith(string tag, string attribute, string index) => _driver.Page.Locator($"(//{tag}[starts-with(@class, '{attribute}')])[{index}]");
        public ILocator TypeLocatorStartsWith(string tag, string attribute, string index) => _driver.Page.Locator($"(//{tag}[starts-with(@type, '{attribute}')])[{index}]");
        public ILocator LinkText(string tag, string attribute, string index) => _driver.Page.Locator($"(//{tag}[text() = '{attribute}'])[{index}]");
        public ILocator LinkTextStartsWith(string tag, string text, string index) => _driver.Page.Locator($"(//{tag}[starts-with(text(), '{text}')])[{index}]");
        public ILocator LinkTextcontains(string tag, string text, string index) => _driver.Page.Locator($"(//{tag}[contains(text(), '{text}')])[{index}]");
        public ILocator AttributeContains(string tag, string attribute, string text, string index) => _driver.Page.Locator($"(//{tag}[contains(@{attribute}, '{text}')])[{index}]");
        public ILocator Placeholder(string tag, string attribute, string text, string index) => _driver.Page.Locator($"(//{tag}[contains(@{attribute}, '{text}')])[{index}]");
        public TestBase(Driver driver)
        {
            _driver = driver;
        }
    }
}
