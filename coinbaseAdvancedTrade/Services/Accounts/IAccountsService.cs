using CoinbaseAdvancedTrade.Services.Accounts.Models;
using CoinbaseAdvancedTrade.Services.Accounts.Models.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoinbaseAdvancedTrade.Services.Accounts
{
    public interface IAccountsService
    {
        Task<List<Account>> GetAccountsAsync();
        Task<Account> GetAccountAsync(string UUID);
    }
}
