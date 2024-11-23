using Newtonsoft.Json;

namespace CoinbaseAdvancedTrade.Services.Products.Models
{
    public class Product
    {
        [JsonProperty("product_id")]
        public string Id { get; set; }
        [JsonProperty("price")]
        public decimal Price {get; set; }
        [JsonProperty("price_percentage_change_24h")]
        public decimal price_percentage_change_24h {get; set; }
        [JsonProperty("volume_24h")]
        public decimal volume_24h {get; set; }
        [JsonProperty("volume_percentage_change_24h")]
        public decimal volume_percentage_change_24h {get; set; }

         [JsonProperty("base_name")]
         public string BaseCurrency { get; set; }
         [JsonProperty("quote_name")]
        public string QuoteCurrency { get; set; }
[JsonProperty("base_min_size")]
        public decimal BaseMinSize { get; set; }
[JsonProperty("base_max_size")]
        public decimal BaseMaxSize { get; set; }

[JsonProperty("quote_increment")]
        public decimal QuoteIncrement { get; set; }
[JsonProperty("base_increment")]
        public decimal BaseIncrement { get; set; }
[JsonProperty("post_only")]
        public bool PostOnly { get; set; }
[JsonProperty("limit_only")]
        public bool LimitOnly { get; set; }
[JsonProperty("cancel_only")]
        public bool CancelOnly { get; set; }
[JsonProperty("trading_disabled")]
        public bool TradingDisabled { get; set; }
[JsonProperty("status")]
        public string Status { get; set; }

        public decimal quote_min_size { get; set; }
        public decimal quote_max_size { get; set; }
        public bool watched { get; set; }
        public bool is_disabled { get; set; }
        [JsonProperty("new")]
        public bool IsNew { get; set; }
        public bool auction_mode { get; set; }
        public string product_type { get; set; }
        public string quote_currency_id { get; set; }
        public string base_currency_id { get; set; }
        public object fcm_trading_session_details { get; set; }
        public string mid_market_price { get; set; }
    }
}
