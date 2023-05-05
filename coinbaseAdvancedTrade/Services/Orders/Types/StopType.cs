using System.Runtime.Serialization;

namespace CoinbaseAdvancedTrade.Services.Orders.Types
{
    public enum StopType
    {
        [EnumMember(Value = "Unknown")]
        Unknown,
        [EnumMember(Value = "loss")]
        Loss,
        [EnumMember(Value = "entry")]
        Entry,
    }
}
