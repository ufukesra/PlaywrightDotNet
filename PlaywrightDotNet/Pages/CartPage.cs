
using PlaywrightDotNet.Utilities;
using Microsoft.Playwright;
using PlaywrightDotNet.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightDotNet.Pages
{
    public class CartPage : TestBase
    {

        public readonly Driver _driver;
        private readonly ProductPage _productPage;
    
        public CartPage(Driver driver) : base(driver)
        {
            _driver=driver;
            _productPage = new ProductPage(_driver);
        }

        public ILocator CartPageLink=> _driver.Page.Locator("(//a[@href='/view_cart'])[1]");
        public ILocator AddToCartElement=> _driver.Page.Locator("//div[@class='single-products']/div/a/i");
        public ILocator ContinueShopping => _driver.Page.Locator("//button[text()='Continue Shopping']");
        public ILocator PriceTag => _driver.Page.Locator("//div[@class='single-products']/div[1]/h2");
        public ILocator CartTotalPrice => _driver.Page.Locator("[class=cart_total_price]");
        public ILocator ProductQuantityInCart => _driver.Page.Locator("(//td[@class='cart_quantity'])[1]/button");
        public ILocator ProductToRemove => _driver.Page.Locator("//td[@class='cart_delete']/a/i");
        public ILocator RemovedProductPriceInCart=> _driver.Page.Locator("(//p[@class='cart_total_price'])[3]");

        

        
        

    }
}