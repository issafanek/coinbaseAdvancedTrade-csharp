using CoinbaseAdvancedTrade.Services.Fees.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoinbaseAdvancedTrade.Services.Fees
{
    public interface IFeesService
    {
        Task<Fee> GetCurrentFeesAsync();
    }
}
