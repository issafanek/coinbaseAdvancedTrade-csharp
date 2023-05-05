using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using CoinbaseAdvancedTrade.Services.Orders.Types;
using CoinbaseAdvancedTrade.Shared.Utilities.Converters;

namespace CoinbaseAdvancedTrade.Services.Orders.Models
{
    public class Market_IOC
    {
        [JsonProperty("quote_size")]
        [JsonConverter(typeof(StringDecimalConverter))]
        public decimal? QuoteSize {get; set;} // Amount of quote currency (example in USD) to spend on an order. // Required for BUY orders.    
        
        [JsonProperty("base_size")]
        [JsonConverter(typeof(StringDecimalConverter))]
        public decimal? BaseSize {get; set;} // Amount of base currency (example in USD) to spend on an order. // Required for SELL orders.

    }
    public class Limit_GTC
    {
        [JsonProperty("base_size")]
        [JsonConverter(typeof(StringDecimalConverter))]
        public decimal? BaseSize {get; set;}
        [JsonProperty("limit_price")]
        [JsonConverter(typeof(StringDecimalConverter))]
        public decimal? LimitPrice {get; set;}
        [JsonProperty("post_only")]
        public bool? PostOnly {get; set;}
    }
    public class Limit_GTD
    {
        [JsonProperty("base_size")]
        [JsonConverter(typeof(StringDecimalConverter))]
        public decimal? BaseSize {get; set;}
        [JsonProperty("limit_price")]
        [JsonConverter(typeof(StringDecimalConverter))]
        public decimal? LimitPrice {get; set;}
        [JsonProperty("end_time")]
        public DateTime? EndTime {get; set;}
        [JsonProperty("post_only")]
        public bool? PostOnly {get; set;}
    }
    public class StopLimit_GTC
    {
        [JsonProperty("base_size")]
        [JsonConverter(typeof(StringDecimalConverter))]
        public decimal? BaseSize {get; set;}
        [JsonProperty("limit_price")]
        [JsonConverter(typeof(StringDecimalConverter))]
        public decimal? LimitPrice {get; set;}
        [JsonProperty("stop_price")]
        [JsonConverter(typeof(StringDecimalConverter))]
        public decimal? StopPrice {get; set;}
        [JsonProperty("stop_direction")]
        [JsonConverter(typeof(StringEnumConverter))]
        public StopDirection? StopDirection {get; set;}
    }

    public class StopLimit_GTD
    {
        [JsonProperty("base_size")]
        [JsonConverter(typeof(StringDecimalConverter))]
        public decimal? BaseSize {get; set;}
        [JsonProperty("limit_price")]
        [JsonConverter(typeof(StringDecimalConverter))]
        public decimal? LimitPrice {get; set;}
        [JsonProperty("stop_price")]
        [JsonConverter(typeof(StringDecimalConverter))]
        public decimal? StopPrice {get; set;}
        [JsonProperty("end_time")]
        public DateTime? EndTime {get; set;}
        [JsonProperty("stop_direction")]
        [JsonConverter(typeof(StringEnumConverter))]
        public StopDirection? StopDirection {get; set;}
    }

    public class OrderConfiguration
    {
        [JsonProperty("market_market_ioc")]
        public Market_IOC? Market_IOC {get; set;}
        [JsonProperty("limit_limit_gtc")]
        public Limit_GTC? Limit_GTC {get; set;}
        [JsonProperty("limit_limit_gtd")]
        public Limit_GTD? Limit_GTD {get; set;}
        [JsonProperty("stop_limit_stop_limit_gtc")]
        public StopLimit_GTC? StopLimit_GTC {get; set;}
        [JsonProperty("stop_limit_stop_limit_gtd")]
        public StopLimit_GTD? StopLimit_GTD {get; set;}
        
    }
}