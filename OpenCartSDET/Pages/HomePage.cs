using Microsoft.Playwright;
using System.Threading.Tasks;

namespace OpenCartSDET.Pages
{
    public class HomePage
    {
        private readonly IPage _page;

        public HomePage(IPage page)
        {
            _page = page;
        }

        private ILocator FirstProduct =>
            _page.Locator(".product-thumb h4 a").First;

        public async Task OpenFirstProductAsync()
        {
            await FirstProduct.ClickAsync();
        }
    }
}