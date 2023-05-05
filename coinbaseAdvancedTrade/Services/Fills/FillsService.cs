using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CoinbaseAdvancedTrade.Network.HttpClient;
using CoinbaseAdvancedTrade.Network.HttpRequest;
using CoinbaseAdvancedTrade.Services.Fills.Models;
using CoinbaseAdvancedTrade.Services.Fills.Models.Responses;
using CoinbaseAdvancedTrade.Services.Fills.Types;
using CoinbaseAdvancedTrade.Shared.Utilities.Queries;
using CoinbaseAdvancedTrade.Shared.Utilities.Extensions;

namespace CoinbaseAdvancedTrade.Services.Fills
{
    public class FillsService : AbstractService, IFillsService
    {
        //private readonly IQueryBuilder queryBuilder;

        public FillsService(
            IHttpClient httpClient,
            IHttpRequestMessageService httpRequestMessageService/*,
            IQueryBuilder queryBuilder*/)
                : base(httpClient, httpRequestMessageService)
        {
            //this.queryBuilder = queryBuilder;
        }

        public async Task<IEnumerable<Fill>> GetFillsByOrderIDAsync(string orderID)
        {
            return (await SendServiceCall<FillResponse>(HttpMethod.Get, $"/api/v3/brokerage/orders/historical/fills?order_id={orderID}")).fills;
        }

        public async Task<FilledOrderInfo> GetFillOrderInfoByOrderIDAsync(string orderID)
        {
            return new FilledOrderInfo((await SendServiceCall<FillResponse>(HttpMethod.Get, $"/api/v3/brokerage/orders/historical/fills?order_id={orderID}")).fills);
        }
    }
}
