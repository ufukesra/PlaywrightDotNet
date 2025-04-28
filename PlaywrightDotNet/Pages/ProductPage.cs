using Microsoft.Playwright;
using PlaywrightDotNet.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightDotNet.Pages
{
    public class ProductPage : TestBase
    {
        private readonly Driver _driver;
        public ProductPage(Driver driver) : base(driver) {
            _driver = driver;
         }

        public ILocator ProductPageLink=> _driver.Page.Locator("//a[@href='/products']");
        public ILocator PageHeader => _driver.Page.Locator("//div[@class='features_items']/h2[starts-with(@class,'title')]");
        public ILocator ProductSearchInput => _driver.Page.Locator("[id=search_product]");
        public ILocator SearchButton => _driver.Page.Locator("[id=submit_search]");
        public ILocator PoloBrand => _driver.Page.Locator("//div[@class='brands-name']/ul/li[1]/a");
        public ILocator FirstProductView => _driver.Page.Locator("//div[@class='features_items']/div[2]/div/div[2]/ul/li/a");
        public ILocator SecondProduct => _driver.Page.Locator("//div[@class='features_items']/div[3]/div/div[2]/ul/li/a");
        public ILocator ThirdProduct => _driver.Page.Locator("//div[@class='features_items']/div[4]/div/div[2]/ul/li/a");
        public ILocator FourthProduct => _driver.Page.Locator("//div[@class='features_items']/div[5]/div/div[2]/ul/li/a");
        public ILocator FifthProduct => _driver.Page.Locator("//div[@class='features_items']/div[6]/div/div[2]/ul/li/a");
        public ILocator SixthProduct => _driver.Page.Locator("//div[@class='features_items']/div[7]/div/div[2]/ul/li/a");
        public ILocator ProductBrandInfo => _driver.Page.Locator("//div[@class='product-information']/p[4]");
        



    }

    
}
