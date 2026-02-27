using Microsoft.Playwright;
using System.Threading.Tasks;

namespace OpenCartSDET.Pages
{
    public class TransferPage
    {
        private readonly IPage _page;

        public TransferPage(IPage page)
        {
            _page = page;
        }

        private ILocator TransferLink => _page.GetByText("Transfer Funds");
        private ILocator Amount => _page.Locator("#amount");
        private ILocator FromAccount => _page.Locator("#fromAccountId");
        private ILocator ToAccount => _page.Locator("#toAccountId");
        private ILocator TransferButton => _page.Locator("input[value='Transfer']");
        private ILocator SuccessMessage => _page.Locator("#showResult");

        public async Task NavigateToTransferAsync()
        {
            await TransferLink.ClickAsync();
            await _page.WaitForURLAsync("**/transfer.htm");
        }

        public async Task<bool> TransferAsync(string amount)
        {
            await Amount.FillAsync(amount);

            var options = await FromAccount.Locator("option").CountAsync();

            if (options > 1)
            {
                // Select different accounts
                await FromAccount.SelectOptionAsync(new SelectOptionValue { Index = 0 });
                await ToAccount.SelectOptionAsync(new SelectOptionValue { Index = 1 });

                await TransferButton.ClickAsync();
                await _page.WaitForSelectorAsync("#showResult");

                return true; // transfer between different accounts
            }
            else
            {
                // Only one account exists
                await FromAccount.SelectOptionAsync(new SelectOptionValue { Index = 0 });
                await ToAccount.SelectOptionAsync(new SelectOptionValue { Index = 0 });

                await TransferButton.ClickAsync();
                await _page.WaitForSelectorAsync("#showResult");

                return false; // same account transfer
            }
        }

        public async Task<string> GetSuccessMessageAsync()
        {
            return await SuccessMessage.InnerTextAsync();
        }
    }
}