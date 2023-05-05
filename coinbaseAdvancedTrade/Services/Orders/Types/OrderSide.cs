using System.Runtime.Serialization;

namespace CoinbaseAdvancedTrade.Services.Orders.Types
{
    public enum OrderSide
    {
        [EnumMember(Value = "BUY")]
        Buy,
        [EnumMember(Value = "SELL")]
        Sell,
        [EnumMember(Value = "UNKOWN_ORDER_SIDE")]
        Unknown
    }
}
