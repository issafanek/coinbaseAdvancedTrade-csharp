﻿using System;
using CoinbaseAdvancedTrade.Services.Orders.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CoinbaseAdvancedTrade.Services.Products.Models
{
    public class ProductTrade
    {
        public DateTime Time { get; set; }

        public int TradeId { get; set; }

        public decimal Price { get; set; }

        public decimal Size { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public OrderSide Side { get; set; }
    }
}
