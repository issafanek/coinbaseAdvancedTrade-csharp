using System.Runtime.Serialization;

namespace CoinbaseAdvancedTrade.Services.Fills.Types
{
    public enum LiquidityIndicator
    {
        [EnumMember(Value = "MAKER")]
        Maker,
        [EnumMember(Value = "TAKER")]
        Taker,
        [EnumMember(Value = "UNKNOWN_LIQUIDITY_INDICATOR")]
        Unknown
    }
}
