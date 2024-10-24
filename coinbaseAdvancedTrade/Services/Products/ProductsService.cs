using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CoinbaseAdvancedTrade.Network.HttpClient;
using CoinbaseAdvancedTrade.Network.HttpRequest;
using CoinbaseAdvancedTrade.Services.Products.Models;
using CoinbaseAdvancedTrade.Services.Products.Models.Responses;
using CoinbaseAdvancedTrade.Services.Products.Types;
using CoinbaseAdvancedTrade.Shared.Utilities.Queries;
using CoinbaseAdvancedTrade.Shared.Utilities.Extensions;
using Serilog;

namespace CoinbaseAdvancedTrade.Services.Products
{
    public class ProductsService : AbstractService, IProductsService
    {
        private readonly IQueryBuilder queryBuilder;

        public ProductsService(
            IHttpClient httpClient,
            IHttpRequestMessageService httpRequestMessageService,
            IQueryBuilder queryBuilder)
                : base(httpClient, httpRequestMessageService)
        {
            this.queryBuilder = queryBuilder;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return (await SendServiceCall<ProductsListResponse>(HttpMethod.Get, "/api/v3/brokerage/products")).products;
        }

        public async Task<Product> GetSingleProductAsync(string productId)
        {
            return await SendServiceCall<Product>(HttpMethod.Get, $"/api/v3/brokerage/products/{productId}");
        }

        public async Task<ProductsOrderBookResponse> GetProductOrderBookAsync(
            string productId,
            ProductLevel productLevel = ProductLevel.One)
        {
            var productsOrderBookJsonResponse = await SendServiceCall<ProductsOrderBookJsonResponse>(HttpMethod.Get, $"/api/v3/brokerage/products/{productId}/book/?level={(int)productLevel}").ConfigureAwait(false);
            var productOrderBookResponse = ConvertProductOrderBookResponse(productsOrderBookJsonResponse, productLevel);

            return productOrderBookResponse;
        }

        public async Task<ProductTicker> GetProductTickerAsync(string productId)
        {
            return await SendServiceCall<ProductTicker>(HttpMethod.Get, $"/api/v3/brokerage/products/{productId}/ticker").ConfigureAwait(false);
        }

        public async Task<ProductStats> GetProductStatsAsync(string productId)
        {
            return await SendServiceCall<ProductStats>(HttpMethod.Get, $"/api/v3/brokerage/products/{productId}/stats").ConfigureAwait(false);
        }

        public async Task<IList<IList<ProductTrade>>> GetTradesAsync(
            string productId,
            int limit = 100,
            int numberOfPages = 0)
        {
            var httpResponseMessage = await SendHttpRequestMessagePagedAsync<ProductTrade>(HttpMethod.Get, $"/api/v3/brokerage/products/{productId}/trades?limit={limit}", numberOfPages: numberOfPages);

            return httpResponseMessage;
        }

        public async Task<IList<Candle>> GetHistoricRatesAsync(
            string productPair,
            DateTime start,
            DateTime end,
            CandleGranularity granularity)
        {
            //const int maxPeriods = 300;
            const int maxNumOfCandlesPerRequest = 300;

            start = start.AddSeconds(-start.Second);
            end = end.AddSeconds(-end.Second);

            //calculate number of requests..
            long startInUnixSeconds = GetUnixTimeInSeconds(start);
            long endInUnixSeconds = GetUnixTimeInSeconds(end);
            //int numOfRequests = (int)(Math.Ceiling((float)(endInUnixSeconds - startInUnixSeconds) / (float)maxNumOfCandlesPerRequest));
            int incrementTime = (int)granularity * (maxNumOfCandlesPerRequest - 1); //decrease by one to ensure that we don't have any gaps between the requests

            var candleList = new List<Candle>();

            var requests = 0;
            for(long currTime = startInUnixSeconds; currTime <= endInUnixSeconds; currTime += incrementTime)
            {
                System.Console.WriteLine($"{currTime} to {currTime + incrementTime - (int)granularity} --> Add {incrementTime}");
                System.Console.WriteLine($"{ GetUtcDateTimeFromUnixTimestamp(currTime)} to {GetUtcDateTimeFromUnixTimestamp(currTime + incrementTime - (int)granularity)} --> Add {incrementTime}");
                
                if (requests >= 3)
                {
                    await Task.Delay(1000);
                    requests = 0;
                }

                long endTimestamp = currTime + incrementTime - (int)granularity;
                if(endTimestamp >= endInUnixSeconds)
                {
                    endTimestamp = endInUnixSeconds;
                }
                Log.Debug($"Range: {GetUtcDateTimeFromUnixTimestamp(currTime).ToString("yyyy-MM-dd HH:mm:ss")} to {GetUtcDateTimeFromUnixTimestamp(endTimestamp).ToString("yyyy-MM-dd HH:mm:ss")}");
                candleList.AddRange(await GetHistoricRatesInternalAsync(productPair, currTime, endTimestamp , granularity));

                //debugging - remove
                //return candleList;
            }

            return candleList;

            // var reversedCandleList = new List<Candle>();
            // for(int i=candleList.Count-1; i>=0;i--)
            // {
            //     reversedCandleList.Add(candleList[i]);
            // }

            // return reversedCandleList;
        }
        private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        private static long GetUnixTimeInSeconds(DateTime dt)
        {
            return ((DateTimeOffset)dt).ToUnixTimeSeconds();
        }
        private static DateTime GetUtcDateTimeFromUnixTimestamp(long unixTimestamp)
        {
            var offset = DateTimeOffset.FromUnixTimeSeconds(unixTimestamp);
            return offset.UtcDateTime;
        }
        private async Task<IList<Candle>> GetHistoricRatesInternalAsync(
            string productId,
            long startInUnixSeconds,
            long endInUnixSeconds,
            CandleGranularity granularity)
        {
            //var isoStart = ((Int32)(DateExtensions.ToTimeStamp(start))).ToString();//start.ToString("yyyy-MM-ddTHH:mm:ss.fffK");
            //var isoEnd = ((Int32)(DateExtensions.ToTimeStamp(end))).ToString();//end.ToString("yyyy-MM-ddTHH:mm:ss.fffK");

            // var unixTimestampStart = GetUnixTimeInSeconds(start);
            // var unixTimestampEnd = GetUnixTimeInSeconds(end);
            // System.Console.WriteLine(unixTimestampStart);
            // System.Console.WriteLine(unixTimestampEnd);

            var queryString = queryBuilder.BuildQuery(
                new KeyValuePair<string, string>("start", startInUnixSeconds.ToString()),
                new KeyValuePair<string, string>("end", endInUnixSeconds.ToString()),
                new KeyValuePair<string, string>("granularity", Enum.GetName(typeof(CandleGranularity), granularity)));

            //System.Console.WriteLine($"/api/v3/brokerage/products/{productId}/candles{queryString}");
            CandleListResponse response = await SendServiceCall<CandleListResponse>(HttpMethod.Get, $"/api/v3/brokerage/products/{productId}/candles{queryString}").ConfigureAwait(false);
            //System.Console.WriteLine(response.candles[0].Open);
            IList<Candle> Candles = new List<Candle>();
            //for(int i= response.candles.Count - 1; i>=0; i--)
            for(int i= 0; i<response.candles.Count-1; i++)
            {
                var candle = response.candles[i];
                Candles.Add(new Candle
                {
                    Time = UnixEpoch.AddSeconds(candle.Time),
                    Low = candle.Low,
                    High = candle.High,
                    Close = candle.Close,
                    Volume = candle.Volume,
                    Open = candle.Open
                });
            }

            //return Candles;//await SendServiceCall<IList<Candle>>(HttpMethod.Get, $"/api/v3/brokerage/products/{productId}/candles" + queryString).ConfigureAwait(false);

            var reversedCandleList = new List<Candle>();
            for(int i=Candles.Count-1; i>=0;i--)
            {
                reversedCandleList.Add(Candles[i]);
            }

            return reversedCandleList;
        }

        private ProductsOrderBookResponse ConvertProductOrderBookResponse(
            ProductsOrderBookJsonResponse productsOrderBookJsonResponse,
            ProductLevel productLevel)
        {
            var askList = productsOrderBookJsonResponse.Asks.Select(product => product.ToArray()).Select(askArray => new Ask(Convert.ToDecimal(askArray[0], CultureInfo.InvariantCulture), Convert.ToDecimal(askArray[1], CultureInfo.InvariantCulture))
            {
                OrderId = productLevel == ProductLevel.Three
                    ? new Guid(askArray[2])
                    : (Guid?)null,
                NumberOfOrders = productLevel == ProductLevel.Three
                    ? (decimal?)null
                    : Convert.ToDecimal(askArray[2], CultureInfo.InvariantCulture)
            }).ToArray();

            var bidList = productsOrderBookJsonResponse.Bids.Select(product => product.ToArray()).Select(bidArray => new Bid(Convert.ToDecimal(bidArray[0], CultureInfo.InvariantCulture), Convert.ToDecimal(bidArray[1], CultureInfo.InvariantCulture))
            {
                OrderId = productLevel == ProductLevel.Three
                    ? new Guid(bidArray[2])
                    : (Guid?)null,
                NumberOfOrders = productLevel == ProductLevel.Three
                    ? (decimal?)null
                    : Convert.ToDecimal(bidArray[2], CultureInfo.InvariantCulture)
            });

            var productOrderBookResponse = new ProductsOrderBookResponse(productsOrderBookJsonResponse.Sequence, bidList, askList);
            return productOrderBookResponse;
        }
    }
}
