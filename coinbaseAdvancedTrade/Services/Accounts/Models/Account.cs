using System;
using CoinbaseAdvancedTrade.Services.Accounts.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CoinbaseAdvancedTrade.Services.Accounts.Models.Responses
{
    public class Account
    {
        [JsonProperty("uuid")]
        public string UUID { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("available_balance")]
        public Balance AvailableBalance { get; set; }
        [JsonProperty("default")]
        public bool Default { get; set; }
        [JsonProperty("active")]
        public bool Active { get; set; }
        [JsonProperty("created_at")]
        public DateTime created_at { get; set; }
        [JsonProperty("updated_at")]
        public DateTime updated_at { get; set; }
        [JsonProperty("deleted_at")]
        public DateTime deleted_at { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("type")]
        public AccountType Type { get; set; }
        [JsonProperty("ready")]
        public bool Ready { get; set; }
        [JsonProperty("hold")]
        public Balance Hold { get; set; }
    }
}
