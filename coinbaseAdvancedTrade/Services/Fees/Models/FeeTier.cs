using System;
using CoinbaseAdvancedTrade.Services.Fees.Models;
using CoinbaseAdvancedTrade.Services.Fees.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using CoinbaseAdvancedTrade.Shared.Utilities.Converters;

namespace CoinbaseAdvancedTrade.Services.Fees.Models
{
    public class FeeTier
    {
        [JsonProperty("pricing_tier")]
        public string? PricingTier { get; set; }
        [JsonProperty("usd_from")]
        [JsonConverter(typeof(StringDecimalConverter))]
        public decimal? UsdFrom { get; set; }
        [JsonProperty("usd_to")]
        [JsonConverter(typeof(StringDecimalConverter))]
        public decimal? UsdTo { get; set; }
        [JsonProperty("taker_fee_rate")]
        [JsonConverter(typeof(StringDecimalConverter))]
        public decimal? TakerFeeRate { get; set; }
        [JsonProperty("maker_fee_rate")]
        [JsonConverter(typeof(StringDecimalConverter))]
        public decimal? MakerFeeRate { get; set; }
    }
}
