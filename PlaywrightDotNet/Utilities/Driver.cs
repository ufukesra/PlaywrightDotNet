using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightDotNet.Utilities
{
    public class Driver : IDisposable
    {
        private readonly Task<IPage> _page;
        private IBrowser? _browser;
        private IBrowserContext? _browserContext;
        public Driver()
        {
            _page = Task.Run(InitializePlaywright);
        }
        public IPage Page => _page.Result;

        public void Dispose()
        {
            _browser?.CloseAsync();
            _browserContext?.CloseAsync();
        }
        private async Task<IPage> InitializePlaywright()
        {
            //Playwright
            var playwright = await Playwright.CreateAsync();
            //Browser
            _browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
                Args = new List<string> { "--start-maximized" }
            });
            _browserContext = await _browser.NewContextAsync(new BrowserNewContextOptions
            {
                IgnoreHTTPSErrors = true,
                ViewportSize = ViewportSize.NoViewport
            });
            //Page
            return await _browserContext.NewPageAsync();
        }
    }
}
