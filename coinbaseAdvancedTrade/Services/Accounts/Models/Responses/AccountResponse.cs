using System;
using CoinbaseAdvancedTrade.Services.Accounts.Models;
using CoinbaseAdvancedTrade.Services.Accounts.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CoinbaseAdvancedTrade.Services.Accounts.Models.Responses
{
    public class AccountResponse
    {
        [JsonProperty("account")]
        public Account Account { get; set; }
    }
}
