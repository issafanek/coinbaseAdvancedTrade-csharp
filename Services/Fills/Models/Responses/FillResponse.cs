using System;
using CoinbaseAdvancedTrade.Services.Fills.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CoinbaseAdvancedTrade.Services.Fills.Models.Responses
{
    public class FillResponse
    {
        public List<Fill> fills { get; set; }
        public string cursor { get; set; }
    }
}