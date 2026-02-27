using Microsoft.Playwright;
using System.Globalization;
using System.Threading.Tasks;

namespace OpenCartSDET.Pages
{
    public class ProductPage
    {
        private readonly IPage _page;

        public ProductPage(IPage page)
        {
            _page = page;
        }

        private ILocator Price =>
            _page.Locator(".list-unstyled h2");

        private ILocator Quantity =>
            _page.Locator("#input-quantity");

        private ILocator AddToCart =>
            _page.Locator("#button-cart");

        private ILocator CartButton =>
            _page.Locator("#cart-total");

        private ILocator ViewCart =>
            _page.GetByText("View Cart");

        public async Task<decimal> GetPriceAsync()
        {
            var priceText = await Price.InnerTextAsync();
            priceText = priceText.Replace("$", "");
            return decimal.Parse(priceText, CultureInfo.InvariantCulture);
        }

        public async Task SetQuantityAsync(int qty)
        {
            await Quantity.FillAsync(qty.ToString());
        }

        public async Task AddToCartAsync()
        {
            await AddToCart.ClickAsync();
        }

        public async Task GoToCartAsync()
        {
            await CartButton.ClickAsync();
            await ViewCart.ClickAsync();
        }
    }
}