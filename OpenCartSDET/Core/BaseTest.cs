using Microsoft.Playwright;
using NUnit.Framework;
using System.Threading.Tasks;

namespace OpenCartSDET.Core
{
    public class BaseTest
    {
        protected IPlaywright Playwright;
        protected IBrowser Browser;
        protected IBrowserContext Context;
        protected IPage Page;

        [SetUp]
        public async Task Setup()
        {
            Playwright = await Microsoft.Playwright.Playwright.CreateAsync();

            Browser = await Playwright.Chromium.LaunchAsync(
                new BrowserTypeLaunchOptions
                {
                    Headless = false,
                    SlowMo = 200
                });

            Context = await Browser.NewContextAsync();
            Page = await Context.NewPageAsync();

            await Page.GotoAsync("https://parabank.parasoft.com/parabank/index.htm");
        }

        [TearDown]
        public async Task TearDown()
        {
            await Browser.CloseAsync();
            Playwright.Dispose();
        }
    }
}