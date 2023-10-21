using CoinbaseAdvancedTrade.Network.HttpClient;
using CoinbaseAdvancedTrade.Network.HttpRequest;
using CoinbaseAdvancedTrade.Services.Accounts.Models;
using CoinbaseAdvancedTrade.Services.Accounts.Models.Responses;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CoinbaseAdvancedTrade.Services.Accounts
{
    public class AccountsService : AbstractService, IAccountsService
    {
        public AccountsService(
            IHttpClient httpClient,
            IHttpRequestMessageService httpRequestMessageService)
                : base(httpClient, httpRequestMessageService)
        {
        }

        public async Task<List<Account>> GetAccountsAsync()
        {
            var accountsResponse = await SendServiceCall<AccountsResponse>(HttpMethod.Get, $"/api/v3/brokerage/accounts");

            return accountsResponse.Accounts;
        }
    }
}
