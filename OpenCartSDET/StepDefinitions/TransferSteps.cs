using TechTalk.SpecFlow;
using FluentAssertions;
using OpenCartSDET.Core;
using OpenCartSDET.Pages;
using System.Threading.Tasks;

namespace OpenCartSDET.StepDefinitions
{
    [Binding]
    public class TransferSteps : BaseTest
    {
        private LoginPage _login;
        private AccountsPage _accounts;
        private TransferPage _transfer;

        private decimal _sourceInitial;
        private decimal _destinationInitial;
        private bool _differentAccounts;

        [Given(@"the user logs into Parabank")]
        public async Task GivenTheUserLogsIntoParabank()
        {
            await Setup();

            _login = new LoginPage(Page);
            _accounts = new AccountsPage(Page);
            _transfer = new TransferPage(Page);

            await _login.LoginAsync("john", "demo");
        }

        [Given(@"the user captures initial account balances")]
        public async Task GivenTheUserCapturesInitialBalances()
        {
            _sourceInitial = await _accounts.GetAccountBalanceByIndexAsync(0);
            _destinationInitial = await _accounts.GetAccountBalanceByIndexAsync(1);
        }

        [When(@"the user transfers 100 dollars")]
        public async Task WhenTheUserTransfersAmount()
        {
            await _transfer.NavigateToTransferAsync();
            _differentAccounts = await _transfer.TransferAsync("100");
        }

        [Then(@"the transfer should be successful")]
        public async Task ThenTransferShouldBeSuccessful()
        {
            var message = await _transfer.GetSuccessMessageAsync();
            message.Should().Contain("Transfer Complete");
        }

        [Then(@"account balances should be updated correctly")]
        public async Task ThenBalancesShouldBeUpdatedCorrectly()
        {
            await _accounts.NavigateToAccountsOverviewAsync();

            var sourceUpdated = await _accounts.GetAccountBalanceByIndexAsync(0);
            var destinationUpdated = await _accounts.GetAccountBalanceByIndexAsync(1);

            if (_differentAccounts)
            {
                sourceUpdated.Should().Be(_sourceInitial - 100);
                destinationUpdated.Should().Be(_destinationInitial + 100);
            }
            else
            {
                sourceUpdated.Should().Be(_sourceInitial);
            }

            await TearDown();
        }
    }
}