using CoinbaseAdvancedTrade.Services.Fees.Models;
using CoinbaseAdvancedTrade.Services.Fees.Models.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoinbaseAdvancedTrade.Services.Fees
{
    public interface IFeesService
    {
        Task<TransactionSummaryResponse> GetCurrentFeesAsync();
    }
}
