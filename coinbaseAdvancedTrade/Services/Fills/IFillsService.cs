using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoinbaseAdvancedTrade.Services.Fills.Models;
using CoinbaseAdvancedTrade.Services.Fills.Models.Responses;
using CoinbaseAdvancedTrade.Services.Fills.Types;

namespace CoinbaseAdvancedTrade.Services.Fills
{
    public interface IFillsService
    {
        Task<IEnumerable<Fill>> GetFillsByOrderIDAsync(string orderID);

        Task<FilledOrderInfo> GetFillOrderInfoByOrderIDAsync(string orderID);
    }
}
