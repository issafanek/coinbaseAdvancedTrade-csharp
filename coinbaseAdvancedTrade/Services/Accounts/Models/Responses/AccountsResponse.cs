using System;
using CoinbaseAdvancedTrade.Services.Accounts.Models;
using CoinbaseAdvancedTrade.Services.Accounts.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CoinbaseAdvancedTrade.Services.Accounts.Models.Responses
{

    public class Balance
    {
        [JsonProperty("value")]
        public decimal Value { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
    }

    public class AccountsResponse
    {
        [JsonProperty("accounts")]
        public List<Account> Accounts { get; set; }
        [JsonProperty("has_next")]
        public bool has_next { get; set; }
        [JsonProperty("cursor")]
        public string Cursor { get; set; }
        [JsonProperty("size")]
        public string Size { get; set; }
    }
}
