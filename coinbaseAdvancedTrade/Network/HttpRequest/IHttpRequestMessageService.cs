using System.Net.Http;

namespace CoinbaseAdvancedTrade.Network.HttpRequest
{
    public interface IHttpRequestMessageService
    {
        HttpRequestMessage CreateHttpRequestMessage(
            HttpMethod httpMethod,
            string requestUri,
            string contentBody = "");
    }
}
