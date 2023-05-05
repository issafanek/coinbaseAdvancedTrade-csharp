using System.Runtime.Serialization;

namespace CoinbaseAdvancedTrade.Services.Orders.Types
{
    public enum StopDirection
    {
        [EnumMember(Value = "UNKNOWN_STOP_DIRECTION")]
        Unknown,
        [EnumMember(Value = "STOP_DIRECTION_STOP_UP")]
        Up,
        [EnumMember(Value = "STOP_DIRECTION_STOP_DOWN")]
        Down,
    }
}
