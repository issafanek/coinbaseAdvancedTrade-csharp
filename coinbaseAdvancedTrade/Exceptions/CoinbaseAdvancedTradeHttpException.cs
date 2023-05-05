using System;
using System.Net;
using System.Net.Http;
using CoinbaseAdvancedTrade.Services;

namespace CoinbaseAdvancedTrade.Exceptions
{
    public class CoinbaseAdvancedTradeHttpException : HttpRequestException
    {
        public HttpStatusCode StatusCode { get; set; }

        public IEndPoint EndPoint { get; set; }

        public HttpRequestMessage RequestMessage { get; set; }

        public HttpResponseMessage ResponseMessage { get; set; }

        public CoinbaseAdvancedTradeHttpException()
        {
        }

        public CoinbaseAdvancedTradeHttpException(string message) 
            : base(message)
        {
        }

        public CoinbaseAdvancedTradeHttpException(string message, Exception inner) 
            : base(message, inner)
        {
        }
    }
}
