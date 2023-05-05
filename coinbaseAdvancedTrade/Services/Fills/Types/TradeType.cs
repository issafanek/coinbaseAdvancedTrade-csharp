using System.Runtime.Serialization;

namespace CoinbaseAdvancedTrade.Services.Fills.Types
{
    public enum TradeType
    {
        [EnumMember(Value = "FILL")]
        Fill,
        [EnumMember(Value = "REVERSAL")]
        Reversal,
        [EnumMember(Value = "CORRECTION")]
        Correction,
        [EnumMember(Value = "SYNTHETIC")]
        Synthetic,
    }
}
