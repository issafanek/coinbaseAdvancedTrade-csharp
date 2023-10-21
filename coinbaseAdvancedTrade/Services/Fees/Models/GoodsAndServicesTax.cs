using System;
using CoinbaseAdvancedTrade.Services.Fees.Models;
using CoinbaseAdvancedTrade.Services.Fees.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CoinbaseAdvancedTrade.Services.Fees.Models
{
    public class GoodsAndServicesTax
    {
        [JsonProperty("rate")]
        public string? Rate { get; set; }
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public GoodsAndServicesTaxType? Type { get; set; }
    }
}
