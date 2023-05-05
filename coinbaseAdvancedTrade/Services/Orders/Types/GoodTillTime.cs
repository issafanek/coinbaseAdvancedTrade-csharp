using System.Runtime.Serialization;

namespace CoinbaseAdvancedTrade.Services.Orders.Types
{
    public enum GoodTillTime
    {
        [EnumMember(Value = "min")]
        Min,
        [EnumMember(Value = "hour")]
        Hour,
        [EnumMember(Value = "day")]
        Day
    }
}
