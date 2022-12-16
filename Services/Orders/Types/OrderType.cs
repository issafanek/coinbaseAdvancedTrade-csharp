using System.Runtime.Serialization;

namespace CoinbaseAdvancedTrade.Services.Orders.Types
{
    public enum OrderType
    {
        [EnumMember(Value = "limit")]
        Limit,
        [EnumMember(Value = "market")]
        Market,
        [EnumMember(Value = "stop")]
        Stop
    }
}
