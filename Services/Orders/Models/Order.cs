﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using CoinbaseAdvancedTrade.Services.Orders.Types;

namespace CoinbaseAdvancedTrade.Services.Orders.Models
{
    public class Order
    {
        public Guid? ClientOid { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public OrderSide Side { get; set; }

        public decimal? Size { get; set; }

        public decimal? Funds { get; set; }

        public decimal? Price { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public StopType? Stop { get; set; }

        public decimal? StopPrice { get; set; }

        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public OrderType OrderType { get; set; }

        public string ProductId { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public TimeInForce TimeInForce { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public GoodTillTime CancelAfter { get; set; }

        public bool PostOnly { get; set; }
    }
}
