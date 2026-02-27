using NUnit.Framework;
using FluentAssertions;
using System.Threading.Tasks;
using OpenCartSDET.Core;
using OpenCartSDET.Pages;

namespace OpenCartSDET.Tests
{
    public class ParabankTests : BaseTest
    {
        [Test]
        public async Task Transfer_Funds_And_Validate_Balances()
        {
            var login = new LoginPage(Page);
            var accounts = new AccountsPage(Page);
            var transfer = new TransferPage(Page);

            await login.LoginAsync("john", "demo");

            decimal initialBalance = await accounts.GetAccountBalanceByIndexAsync(0);

            await transfer.NavigateToTransferAsync();

            bool differentAccounts = await transfer.TransferAsync("100");

            var message = await transfer.GetSuccessMessageAsync();
            message.Should().Contain("Transfer Complete");

            await accounts.NavigateToAccountsOverviewAsync();

            decimal updatedBalance = await accounts.GetAccountBalanceByIndexAsync(0);

            if (differentAccounts)
            {
                updatedBalance.Should().Be(initialBalance - 100);
            }
            else
            {
                // Same account transfer → balance remains same
                updatedBalance.Should().Be(initialBalance);
            }
        }
    }
}