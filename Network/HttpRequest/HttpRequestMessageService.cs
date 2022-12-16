using CoinbaseAdvancedTrade.Shared.Utilities.Extensions;
using System;
using System.Globalization;
using System.Net.Http;
using System.Text;
using CoinbaseAdvancedTrade.Exceptions;
using CoinbaseAdvancedTrade.Network.Authentication;
using CoinbaseAdvancedTrade.Shared;
using CoinbaseAdvancedTrade.Shared.Utilities.Clock;

namespace CoinbaseAdvancedTrade.Network.HttpRequest
{
    public class HttpRequestMessageService : IHttpRequestMessageService
    {
        private readonly IAuthenticator authenticator;

        private readonly IClock clock;

        //private readonly bool sandBox;

        public HttpRequestMessageService(
            IAuthenticator authenticator,
            IClock clock)//,
            //bool sandBox)
        {
            this.authenticator = authenticator;
            this.clock = clock;
            //this.sandBox = sandBox;
        }

        public HttpRequestMessage CreateHttpRequestMessage(
            HttpMethod httpMethod,
            string requestUri,
            string contentBody = "")
        {
            var apiUri = ApiUris.ApiUri;//sandBox
                //? ApiUris.ApiUriSandbox
                //: ApiUris.ApiUri;

            var requestMessage = new HttpRequestMessage(httpMethod, new Uri(new Uri(apiUri), requestUri))
            {
                Content = contentBody == string.Empty
                    ? null
                    : new StringContent(contentBody, Encoding.UTF8, "application/json")
            };

            var timeStamp = clock.GetTime().ToTimeStamp();

            if (authenticator == null)
            {
                AddHeaders(requestMessage, null, timeStamp, false);

                return requestMessage;
            }

            var signedSignature = authenticator.ComputeSignature(httpMethod, authenticator.UnsignedSignature, timeStamp, requestUri, contentBody);

            AddHeaders(requestMessage, signedSignature, timeStamp, true);
            return requestMessage;
        }

        private void AddHeaders(
            HttpRequestMessage httpRequestMessage,
            string signedSignature,
            double timeStamp,
            bool includeAuthentication)
        {
            httpRequestMessage.Headers.Add("User-Agent", "CoinbaseProClient");

            if (!includeAuthentication)
            {
                return;
            }

            httpRequestMessage.Headers.Add("CB-ACCESS-KEY", authenticator.ApiKey);
            httpRequestMessage.Headers.Add("CB-ACCESS-TIMESTAMP", timeStamp.ToString("F0", CultureInfo.InvariantCulture));
            httpRequestMessage.Headers.Add("CB-ACCESS-SIGN", signedSignature);
            httpRequestMessage.Headers.Add("CB-ACCESS-PASSPHRASE", authenticator.Passphrase);
        }
    }
}
