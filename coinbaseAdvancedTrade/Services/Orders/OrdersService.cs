using CoinbaseAdvancedTrade.Shared.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CoinbaseAdvancedTrade.Network.HttpClient;
using CoinbaseAdvancedTrade.Network.HttpRequest;
using CoinbaseAdvancedTrade.Services.Orders.Models;
using CoinbaseAdvancedTrade.Services.Orders.Models.Responses;
using CoinbaseAdvancedTrade.Services.Orders.Types;
using CoinbaseAdvancedTrade.Shared.Utilities;
using CoinbaseAdvancedTrade.Shared.Utilities.Queries;

namespace CoinbaseAdvancedTrade.Services.Orders
{
    public class OrdersService : AbstractService, IOrdersService
    {
        private readonly QueryBuilder queryBuilder;

        public OrdersService(
            IHttpClient httpClient,
            IHttpRequestMessageService httpRequestMessageService,
            QueryBuilder queryBuilder)
                : base(httpClient, httpRequestMessageService)
        {
            this.queryBuilder = queryBuilder;
        }

        public async Task<OrderResponse> PlaceMarketOrderAsync(
            OrderSide side,
            string productId,
            decimal amount,
            Guid? clientOid = null)
        {
            if(clientOid == null)
            {
                clientOid = System.Guid.NewGuid();
            }

            Market_IOC marketOrderConfiguration = new Market_IOC();
            if(side == OrderSide.Buy)
            {
                marketOrderConfiguration.QuoteSize = amount;
            }
            else
            {
                marketOrderConfiguration.BaseSize = amount;
            }

            return await PlaceOrderAsync(new Order
            {
                OrderID = ((Guid)clientOid).ToString(),
                ProductId = productId,
                Side = side,
                OrderConfiguration = new OrderConfiguration{
                    Market_IOC = marketOrderConfiguration
                }
            });
        }

        // public async Task<OrderResponse> PlaceLimitOrderAsync(
        //     OrderSide side,
        //     string productId,
        //     decimal size,
        //     decimal price,
        //     TimeInForce timeInForce = TimeInForce.Gtc,
        //     bool postOnly = true,
        //     Guid? clientOid = null)
        // {
        //     var order = new Order
        //     {
        //         Side = side,
        //         ProductId = productId,
        //         OrderType = OrderType.Limit,
        //         Price = price,
        //         Size = size,
        //         TimeInForce = timeInForce,
        //         PostOnly = postOnly,
        //         ClientOid = clientOid
        //     };

        //     return await PlaceOrderAsync(order);
        // }

        // public async Task<OrderResponse> PlaceLimitOrderAsync(
        //     OrderSide side,
        //     string productId,
        //     decimal size,
        //     decimal price,
        //     GoodTillTime cancelAfter,
        //     bool postOnly = true,
        //     Guid? clientOid = null)
        // {
        //     var order = new Order
        //     {
        //         Side = side,
        //         ProductId = productId,
        //         OrderType = OrderType.Limit,
        //         Price = price,
        //         Size = size,
        //         TimeInForce = TimeInForce.Gtt,
        //         CancelAfter = cancelAfter,
        //         PostOnly = postOnly,
        //         ClientOid = clientOid
        //     };

        //     return await PlaceOrderAsync(order);
        // }

        // public async Task<OrderResponse> PlaceStopOrderAsync(
        //     OrderSide side,
        //     string productId,
        //     decimal size,
        //     decimal limitPrice,
        //     decimal stopPrice,
        //     Guid? clientOid = null)
        // {
        //     var order = new Order
        //     {
        //         Side = side,
        //         OrderType = OrderType.Limit,
        //         ProductId = productId,
        //         Price = limitPrice,
        //         Stop = side == OrderSide.Buy
        //             ? StopType.Entry
        //             : StopType.Loss,
        //         StopPrice = stopPrice,
        //         Size = size,
        //         ClientOid = clientOid
        //     };

        //     return await PlaceOrderAsync(order);
        // }

        private async Task<OrderResponse> PlaceOrderAsync(Order order)
        {
            return await SendServiceCall<OrderResponse>(HttpMethod.Post, "/api/v3/brokerage/orders", JsonConfig.SerializeObject(order)).ConfigureAwait(false);
        }

        public async Task<CancelOrderResponse> CancelAllOrdersAsync()
        {
            return new CancelOrderResponse
            {
                OrderIds = await SendServiceCall<IEnumerable<Guid>>(HttpMethod.Delete, "/api/v3/brokerage/orders").ConfigureAwait(false)
            };
        }

        public async Task<CancelOrderResponse> CancelOrderByIdAsync(string id)
        {
            return new CancelOrderResponse
            {
                OrderIds = new[] { await SendServiceCall<Guid>(HttpMethod.Delete, $"/api/v3/brokerage/orders/{id}") }
            };
        }

        public async Task<IList<IList<OrderResponse>>> GetAllOrdersAsync(
            OrderStatus orderStatus = OrderStatus.All,
            int limit = 100,
            int numberOfPages = 0)
        {
            var httpResponseMessage = await SendHttpRequestMessagePagedAsync<OrderResponse>(HttpMethod.Get, $"/api/v3/brokerage/orders?limit={limit}&status={orderStatus.GetEnumMemberValue()}", numberOfPages: numberOfPages);

            return httpResponseMessage;
        }

        public async Task<IList<IList<OrderResponse>>> GetAllOrdersAsync(
            OrderStatus[] orderStatus,
            int limit = 100,
            int numberOfPages = 0)
        {
            var queryKeyValuePairs = orderStatus.Select(p => new KeyValuePair<string, string>("status", p.GetEnumMemberValue())).ToArray();
            var query = queryBuilder.BuildQuery(queryKeyValuePairs);

            var httpResponseMessage = await SendHttpRequestMessagePagedAsync<OrderResponse>(HttpMethod.Get, $"/api/v3/brokerage/orders{query}&limit={limit}", numberOfPages: numberOfPages);

            return httpResponseMessage;
        }

        public async Task<OrderResponse> GetOrderByIdAsync(string id)
        {
            return await SendServiceCall<OrderResponse>(HttpMethod.Get, $"/api/v3/brokerage/orders/{id}").ConfigureAwait(false);
        }
    }
}
