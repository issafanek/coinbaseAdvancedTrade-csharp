using CoinbaseAdvancedTrade.Services.Products;

namespace CoinbaseAdvancedTrade.Services.Products.Models.Responses
{
    public class CandleListResponse
    {
        public List<CandleIntermediate> candles { get; set; }
    }
}