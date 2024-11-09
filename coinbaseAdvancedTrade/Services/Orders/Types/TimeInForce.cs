using System.Runtime.Serialization;

namespace CoinbaseAdvancedTrade.Services.Orders.Types
{
    public enum TimeInForce
    {
        [EnumMember(Value = "GTC")]
        Gtc,
        [EnumMember(Value = "GTT")]
        Gtt,
        [EnumMember(Value = "IOC")]
        Ioc,
        [EnumMember(Value = "FOK")]
        Fok,

        [EnumMember(Value = "GOOD_UNTIL_DATE_TIME")]
        GoodUntilDateTime,
        [EnumMember(Value = "GOOD_UNTIL_CANCELLED")]
        GoodUntilCancelled,
        [EnumMember(Value = "IMMEDIATE_OR_CANCEL")]
        ImmediateOrCancel,
        [EnumMember(Value = "FILL_OR_KILL")]
        FillOrKill,
        [EnumMember(Value = "UNKNOWN_TIME_IN_FORCE")]
        Unknown
    }
}
