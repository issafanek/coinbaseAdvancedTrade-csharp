using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoinbaseAdvancedTrade.Services.Products.Models;
using CoinbaseAdvancedTrade.Services.Products.Models.Responses;
using CoinbaseAdvancedTrade.Services.Products.Types;

namespace CoinbaseAdvancedTrade.Services.Products
{
    public interface IProductsService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();

        Task<Product> GetSingleProductAsync(string productId);

        Task<ProductsOrderBookResponse> GetProductOrderBookAsync(
            string productId,
            ProductLevel productLevel = ProductLevel.One);

        Task<IList<IList<ProductTrade>>> GetTradesAsync(
            string productId,
            int limit = 100,
            int numberOfPages = 0);

        Task<IList<Candle>> GetHistoricRatesAsync(
            string productPair,
            DateTime start,
            DateTime end,
            CandleGranularity granularity);

        Task<ProductTicker> GetProductTickerAsync(string productId);

        Task<ProductStats> GetProductStatsAsync(string productId);
    }
}
