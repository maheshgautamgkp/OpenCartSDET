using Microsoft.Playwright;
using System.Globalization;
using System.Threading.Tasks;

namespace OpenCartSDET.Pages
{
    public class CartPage
    {
        private readonly IPage _page;

        public CartPage(IPage page)
        {
            _page = page;
        }

        private ILocator Total =>
            _page.Locator("//strong[text()='Total:']/ancestor::tr/td[2]");

        private ILocator RemoveButton =>
            _page.Locator(".btn-danger");

        public async Task<decimal> GetTotalAsync()
        {
            var totalText = await Total.InnerTextAsync();
            totalText = totalText.Replace("$", "");
            return decimal.Parse(totalText, CultureInfo.InvariantCulture);
        }

        public async Task RemoveProductAsync()
        {
            await RemoveButton.ClickAsync();
        }
    }
}