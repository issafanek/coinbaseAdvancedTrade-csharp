using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using CoinbaseAdvancedTrade.Services.Fills.Types;
using CoinbaseAdvancedTrade.Shared.Utilities.Converters;

namespace CoinbaseAdvancedTrade.Services.Fills.Models
{
    public class Fill
    {
        public string entry_id { get; set; }
        public string trade_id { get; set; }
        public string order_id { get; set; }
        public DateTime trade_time { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public TradeType trade_type { get; set; }
        [JsonConverter(typeof(StringDecimalConverter))]
        public decimal price { get; set; }
        [JsonConverter(typeof(StringDecimalConverter))]
        public decimal size { get; set; }
        [JsonConverter(typeof(StringDecimalConverter))]
        public decimal commission { get; set; }
        public string product_id { get; set; }
        public DateTime sequence_timestamp { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public LiquidityIndicator liquidity_indicator { get; set; }
        public bool size_in_quote { get; set; }
        public string user_id { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Side side { get; set; }
        public string retail_portfolio_id { get; set; }
    }
}