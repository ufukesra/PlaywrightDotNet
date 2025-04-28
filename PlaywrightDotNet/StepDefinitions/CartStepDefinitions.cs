using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;
using NUnit.Framework;
using PlaywrightDotNet.Pages;
using PlaywrightDotNet.Utilities;
using Support;
using static Microsoft.Playwright.Assertions;

namespace PlaywrightDotNet.StepDefinitions{
    [Binding]
    public class CartStepDefinitions : TestBase{
        private readonly Driver _driver;
        private readonly CartPage _cartPage;
        private readonly ProductPage _productPage;
        private double totalPrice;
        private double cartTotalPrice;
        private double removedPrice;

        public CartStepDefinitions(Driver driver) : base(driver)
        {
            _driver = driver;
            _cartPage = new CartPage(_driver);
            _productPage  = new ProductPage(_driver);
        }

        [When("User manage to Product Page")]
        public async Task WhenUserManageToProductPage()
        {
            await _productPage.ProductPageLink.ClickAsync();
        }

        [When("User add products to chart")]
        public async Task WhenUserAddProductsToChart()
        {
            //String multiple AddToCart Button Elements in a List
            //String multiple Price Tags in a List
            totalPrice = 0;
            List<ILocator> AddToCartElements= new List<ILocator>();
            List<ILocator> PriceTags = new List<ILocator>();

            for(int i = 0; i < 35; i++){
                var element= _cartPage.AddToCartElement.Nth(i);
                AddToCartElements.Add(element);

                var price= _cartPage.PriceTag.Nth(i);
                PriceTags.Add(price);
            }
            
            
            
            //Adding first item with three quantity to cart
            int firstProductCount = 3;
            for (int i = 0; i < firstProductCount; i++){
            await AddToCartElements[0].HoverAsync();
            await AddToCartElements[0].ClickAsync();
            await _cartPage.ContinueShopping.ClickAsync();
            string priceText=await PriceTags[0].InnerTextAsync();
            priceText= priceText.Substring(4);
            double price =Convert.ToDouble(priceText);
            totalPrice = totalPrice + price;
            //Console.WriteLine("-----------Total Price1: "+totalPrice);
            
            }

            //Adding second item with two quantity to cart
            int secondProductCount = 2;
            for (int i = 0; i < secondProductCount; i++){
            await AddToCartElements[1].HoverAsync();
            await AddToCartElements[1].ClickAsync();
            await _cartPage.ContinueShopping.ClickAsync();
            string priceText= await PriceTags[1].InnerTextAsync();
            priceText= priceText.Substring(4);
            double price =Convert.ToDouble(priceText);
            totalPrice = totalPrice + price;
            //Console.WriteLine("-----------Total Price2: "+totalPrice);
            }

            //Adding third item with one quantity to cart
            int thirdProductCount = 1;
            for (int i = 0; i < thirdProductCount; i++){
            await AddToCartElements[2].HoverAsync();
            await AddToCartElements[2].ClickAsync();
            await _cartPage.ContinueShopping.ClickAsync();
            string priceText=await PriceTags[2].InnerTextAsync();
            priceText= priceText.Substring(4);
            double price =Convert.ToDouble(priceText);
            totalPrice = totalPrice + price;
            //Console.WriteLine("-----------Total Price3: "+totalPrice);
            }
            await _cartPage.CartPageLink.ClickAsync();

            
            //calculating cart total amount
            int cartProductCount=3;
            cartTotalPrice = 0;
            List<ILocator> CartTotalPrices = new List<ILocator>();
            for(int i = 0; i < cartProductCount; i++){
                var cartPrice= _cartPage.CartTotalPrice.Nth(i);
                CartTotalPrices.Add(cartPrice);
                string priceText=await CartTotalPrices[i].InnerTextAsync();
                priceText= priceText.Substring(4);
                double price =Convert.ToDouble(priceText);
                cartTotalPrice = cartTotalPrice + price;
                

            }

            
        }

        [When("User update product quantity")]
        public async Task WhenUserUpdateProductQuantity()
        {
            //Product quantity is disabled in the cart,imposiible to update it, so hanling the exception
            try{
                _cartPage.ProductQuantityInCart.ClickAsync();
                _cartPage.ProductQuantityInCart.FillAsync("10");

            }catch(Exception e){
                Console.WriteLine(e.Message);
            }
        }

        [When("User remove one product from cart")]
        public async Task WhenUserRemoveOneProductFromCart()
        {
            //Adding multiple cart items element in the cart in a List
            List<ILocator> ChartItems= new List<ILocator>();
            for(int i = 0; i < 3; i++){
                var element= _cartPage.ProductToRemove.Nth(i);
                ChartItems.Add(element);
            }
            
            //Updating total price and remove product
            string thirdpriceText=await _cartPage.RemovedProductPriceInCart.InnerTextAsync();
            thirdpriceText= thirdpriceText.Substring(4);
            double priceToRemove =Convert.ToDouble(thirdpriceText);
            totalPrice = totalPrice - priceToRemove;

            //Removing one product from cart
            await ChartItems[2].ClickAsync();


            // This part is to calculating Cart total Price after removing one product
            int cartProductCount=2;
            cartTotalPrice = 0;
            List<ILocator> CartTotalPrices = new List<ILocator>();
            for(int i = 0; i < cartProductCount; i++){
                var cartPrice= _cartPage.CartTotalPrice.Nth(i);
                CartTotalPrices.Add(cartPrice);
                string priceText=await CartTotalPrices[i].InnerTextAsync();
                priceText= priceText.Substring(4);
                double price =Convert.ToDouble(priceText);
                cartTotalPrice = cartTotalPrice + price;
                //Console.WriteLine("-----------Cart Total Price: "+cartTotalPrice);

            }


        }

        [Then("Verify total amount calculation correct")]
        public async Task ThenVerifyTotalAmountCalculationCorrect()
        {
            
            Console.WriteLine("-----------Total Price: "+totalPrice);
            Console.WriteLine("-----------Cart Total Price: "+cartTotalPrice);
            Assert.AreEqual(totalPrice, cartTotalPrice);


            //This part to remove all remaining items from cart for the next test for same user
            List<ILocator> ChartItems= new List<ILocator>();
            for(int i = 0; i < 2; i++){
                var element= _cartPage.ProductToRemove.Nth(i);
                ChartItems.Add(element);
                await ChartItems[i].ClickAsync();
            }
        }

        

    }
}