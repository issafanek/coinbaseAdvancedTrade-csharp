﻿using System;
using CoinbaseAdvancedTrade.Services.Orders.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CoinbaseAdvancedTrade.Services.Orders.Models.Responses
{
    public class OrderResponse
    {
        public Guid Id { get; set; }

        public decimal Price { get; set; }

        public decimal Size { get; set; }

        public string ProductId { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public OrderSide Side { get; set; }

        public string Stp { get; set; }

        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public OrderType OrderType { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public TimeInForce TimeInForce { get; set; }

        public bool PostOnly { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime DoneAt { get; set; }

        public string DoneReason { get; set; }

        public decimal FillFees { get; set; }

        public decimal FilledSize { get; set; }

        public decimal ExecutedValue { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public OrderStatus Status { get; set; }

        public bool Settled { get; set; }

        public decimal SpecifiedFunds { get; set; }

        public decimal StopPrice { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public StopType Stop { get; set; }
    }
}
