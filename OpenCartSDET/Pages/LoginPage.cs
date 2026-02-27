using Microsoft.Playwright;
using System.Threading.Tasks;

namespace OpenCartSDET.Pages
{
    public class LoginPage
    {
        private readonly IPage _page;

        public LoginPage(IPage page)
        {
            _page = page;
        }

        private ILocator Username => _page.Locator("input[name='username']");
        private ILocator Password => _page.Locator("input[name='password']");
        private ILocator LoginButton => _page.Locator("input[value='Log In']");

        public async Task LoginAsync(string user, string pass)
        {
            await Username.FillAsync(user);
            await Password.FillAsync(pass);
            await LoginButton.ClickAsync();

            // Wait until Accounts Overview loads
            await _page.WaitForURLAsync("**/overview.htm");
            await _page.WaitForSelectorAsync("#accountTable");
        }
    }
}