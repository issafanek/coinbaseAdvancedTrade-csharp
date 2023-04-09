using System.Runtime.Serialization;

namespace CoinbaseAdvancedTrade.Services.Orders.Types
{
    public enum OrderError
    {
        UNKNOWN_FAILURE_REASON, 
        UNSUPPORTED_ORDER_CONFIGURATION, 
        INVALID_SIDE, 
        INVALID_PRODUCT_ID, 
        INVALID_SIZE_PRECISION, 
        INVALID_PRICE_PRECISION, 
        INSUFFICIENT_FUND, 
        INVALID_LEDGER_BALANCE, 
        ORDER_ENTRY_DISABLED, 
        INELIGIBLE_PAIR, 
        INVALID_LIMIT_PRICE_POST_ONLY, 
        INVALID_LIMIT_PRICE, 
        INVALID_NO_LIQUIDITY, 
        INVALID_REQUEST, 
        COMMANDER_REJECTED_NEW_ORDER, 
        INSUFFICIENT_FUNDS
    }
}
