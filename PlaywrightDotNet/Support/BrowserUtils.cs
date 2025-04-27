using Microsoft.Playwright;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Support{

    public class BrowserUtils{

        //Get Page Title
        public async Task<string> GetTitle(IPage page){
            return await page.TitleAsync();
        }

        //Navigate to a URL
        public static async Task NavigateToUrl(IPage page, string url)
        {
            await page.GotoAsync(url);
        }
        
        //Wait for Element to Be Visible
        public static async Task WaitForElementToBeVisible(IPage page, string selector)
        {
             await page.WaitForSelectorAsync(selector, new PageWaitForSelectorOptions { State = WaitForSelectorState.Visible });
        }

        //Wait for Element to Be Clickable
        public static async Task WaitForElementToBeClickable(IPage page, string selector)
        {
            await page.WaitForSelectorAsync(selector, new PageWaitForSelectorOptions { State = WaitForSelectorState.Visible });
        }

        //Click an Element
        public static async Task ClickElement(IPage page, string selector)
        {
            await page.ClickAsync(selector);
        }


        //Fill an Input Field
        public static async Task FillInputField(IPage page, string selector, string value)
        {
            await page.FillAsync(selector, value);
        }


        //Get Text Content of an Element
        public static async Task<string> GetTextContent(IPage page, string selector)
        {
            return await page.TextContentAsync(selector);
        }


        //Check if Element is Visible
        public static async Task<bool> IsElementVisible(IPage page, string selector)
        {
            var element = await page.QuerySelectorAsync(selector);
            return element != null && await element.IsVisibleAsync();
        }


        //Take Screenshot
        public static async Task TakeScreenshot(IPage page, string filePath)
        {
            await page.ScreenshotAsync(new PageScreenshotOptions { Path = filePath });
        }



        //Scroll to an Element
        public static async Task ScrollToElement(IPage page, string selector)
        {
            var element = await page.QuerySelectorAsync(selector);
            await element.ScrollIntoViewIfNeededAsync();
        }


        //Select Dropdown Option
        public static async Task SelectDropdownOption(IPage page, string selector, string optionText)
        {
            await page.SelectOptionAsync(selector, new SelectOptionValue { Label = optionText });
        }


        //Handle Browser Alerts
        public static async Task<string> HandleAlertAsync(IPage page)
        {
            string alertMessage = null;

            page.Dialog += async (_, dialog) =>
            {
                alertMessage = dialog.Message;
                await dialog.AcceptAsync();
            };
            return alertMessage;
        }

        //Switch to Another Tab
        public static async Task<IPage> SwitchToNewTab(IBrowser browser)
        {
            var context = await browser.NewContextAsync();
            var newPage = await context.NewPageAsync();
            return newPage;
        }


        //Scroll to Bottom of the Page
        public static async Task ScrollToBottom(IPage page)
        {
            await page.EvaluateAsync("window.scrollTo(0, document.body.scrollHeight);");
        }


        //Get the Current Page URL
        public static string GetCurrentPageUrl(IPage page)
        {
            return page.Url;
        }


        //Wait for Page Load to Complete
        public static async Task WaitForPageLoad(IPage page)
        {
            await page.WaitForLoadStateAsync(LoadState.NetworkIdle);
        }


        //Static Timeout
        public static async Task CustomWaitAsync(int milliseconds)
        {
            await Task.Delay(milliseconds);
        }

        









    }  
}