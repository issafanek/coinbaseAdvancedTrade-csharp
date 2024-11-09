using System.Runtime.Serialization;

namespace CoinbaseAdvancedTrade.Services.Orders.Types
{
    public enum OrderStatus
    {
        [EnumMember(Value = "all")]
        All,
        [EnumMember(Value = "PENDING")]
        Pending,
        [EnumMember(Value = "OPEN")]
        Open,
        [EnumMember(Value = "FILLED")]
        Filled,
        [EnumMember(Value = "CANCELLED")]
        Cancelled,
        [EnumMember(Value = "EXPIRED")]
        Expired,
        [EnumMember(Value = "FAILED")]
        Failed,
        [EnumMember(Value = "UNKNOWN_ORDER_STATUS")]
        Unkown,
        [EnumMember(Value = "QUEUED")]
        Queued,
        [EnumMember(Value = "CANCEL_QUEUED")]
        CancelQueued,
    }
}
