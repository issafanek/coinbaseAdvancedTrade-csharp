using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using CoinbaseAdvancedTrade.Services.Orders.Types;

namespace CoinbaseAdvancedTrade.Services.Orders.Models
{
    public class Order
    {
        [JsonProperty("client_order_id")]
        public string OrderID { get; set; }

        [JsonProperty("product_id")]
        public string ProductId { get; set; }

        [JsonProperty("side")]
        [JsonConverter(typeof(StringEnumConverter))]
        public OrderSide? Side { get; set; }

        [JsonProperty("order_configuration")]
        public OrderConfiguration? OrderConfiguration { get; set; }

    }
}
