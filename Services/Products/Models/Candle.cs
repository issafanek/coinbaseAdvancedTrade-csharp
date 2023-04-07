using System;
using CoinbaseAdvancedTrade.Shared.Utilities.Converters;
using Newtonsoft.Json;

namespace CoinbaseAdvancedTrade.Services.Products.Models
{
    //[JsonConverter(typeof(CandleConverter))]
    public class CandleIntermediate
    {
        [JsonProperty("start")]
        public int Time { get; set; }

        [JsonProperty("low")]
        public decimal? Low { get; set; }

        [JsonProperty("high")]
        public decimal? High { get; set; }

        [JsonProperty("open")]
        public decimal? Open { get; set; }

        [JsonProperty("close")]
        public decimal? Close { get; set; }

        [JsonProperty("volume")]
        public decimal Volume { get; set; }
    }
    
    public class Candle
    {
        [JsonProperty(Order = 1)]
        public DateTime Time { get; set; }

        [JsonProperty(Order = 2)]
        public decimal? Low { get; set; }

        [JsonProperty(Order = 3)]
        public decimal? High { get; set; }

        [JsonProperty(Order = 4)]
        public decimal? Open { get; set; }

        [JsonProperty(Order = 5)]
        public decimal? Close { get; set; }

        [JsonProperty(Order = 6)]
        public decimal Volume { get; set; }
    }
}
