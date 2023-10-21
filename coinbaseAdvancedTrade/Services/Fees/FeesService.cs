using CoinbaseAdvancedTrade.Network.HttpClient;
using CoinbaseAdvancedTrade.Network.HttpRequest;
using CoinbaseAdvancedTrade.Services.Fees.Models;
using CoinbaseAdvancedTrade.Services.Fees.Models.Responses;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CoinbaseAdvancedTrade.Services.Fees
{
    public class FeesService : AbstractService, IFeesService
    {
        public FeesService(
            IHttpClient httpClient,
            IHttpRequestMessageService httpRequestMessageService)
                : base(httpClient, httpRequestMessageService)
        {
        }

        public async Task<TransactionSummaryResponse> GetCurrentFeesAsync()
        {
            var transactionSummaryResponse = await SendServiceCall<TransactionSummaryResponse>(HttpMethod.Get, "/api/v3/brokerage/transaction_summary");

            return transactionSummaryResponse;
        }
    }
}
