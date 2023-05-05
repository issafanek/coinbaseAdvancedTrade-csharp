using System.Runtime.Serialization;

namespace CoinbaseAdvancedTrade.Services.Fills.Types
{
    public enum Side
    {
        [EnumMember(Value = "BUY")]
        Buy,
        [EnumMember(Value = "SELL")]
        Sell,
        [EnumMember(Value = "UNKOWN_ORDER_SIDE")]
        Unknown
    }
}
