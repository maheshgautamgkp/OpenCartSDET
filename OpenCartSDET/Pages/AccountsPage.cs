using Microsoft.Playwright;
using System.Globalization;
using System.Threading.Tasks;

namespace OpenCartSDET.Pages
{
    public class AccountsPage
    {
        private readonly IPage _page;

        public AccountsPage(IPage page)
        {
            _page = page;
        }

        private ILocator AccountRows =>
            _page.Locator("#accountTable tbody tr");

        public async Task<decimal> GetAccountBalanceByIndexAsync(int index)
        {
            var balanceLocator =
                AccountRows.Nth(index).Locator("td").Nth(1);

            var balanceText = await balanceLocator.InnerTextAsync();

            balanceText = balanceText
                .Replace("$", "")
                .Replace(",", "")
                .Trim();

            return decimal.Parse(balanceText, CultureInfo.InvariantCulture);
        }

        public async Task NavigateToAccountsOverviewAsync()
        {
            await _page.ClickAsync("text=Accounts Overview");
            await _page.WaitForSelectorAsync("#accountTable");
        }
    }
}