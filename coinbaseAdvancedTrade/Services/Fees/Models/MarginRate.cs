using System;
using CoinbaseAdvancedTrade.Services.Fees.Models;
using CoinbaseAdvancedTrade.Services.Fees.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CoinbaseAdvancedTrade.Services.Fees.Models
{
    public class MarginRate
    {
        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
