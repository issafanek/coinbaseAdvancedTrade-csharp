using System.Runtime.Serialization;

namespace CoinbaseAdvancedTrade.Services.Orders.Types
{
    public enum PreviewFailureReason
    {
        UNKNOWN_PREVIEW_FAILURE_REASON,
        PREVIEW_MISSING_COMMISSION_RATE,
        PREVIEW_INVALID_SIDE,
        PREVIEW_INVALID_ORDER_CONFIG,
        PREVIEW_INVALID_PRODUCT_ID,
        PREVIEW_INVALID_SIZE_PRECISION,
        PREVIEW_INVALID_PRICE_PRECISION,
        PREVIEW_MISSING_PRODUCT_PRICE_BOOK,
        PREVIEW_INVALID_LEDGER_BALANCE,
        PREVIEW_INSUFFICIENT_LEDGER_BALANCE,
        PREVIEW_INVALID_LIMIT_PRICE_POST_ONLY,
        PREVIEW_INVALID_LIMIT_PRICE, 
        PREVIEW_INVALID_NO_LIQUIDITY, 
        PREVIEW_INSUFFICIENT_FUND, 
        PREVIEW_INVALID_COMMISSION_CONFIGURATION, 
        PREVIEW_INVALID_STOP_PRICE, 
        PREVIEW_INVALID_BASE_SIZE_TOO_LARGE, 
        PREVIEW_INVALID_BASE_SIZE_TOO_SMALL, 
        PREVIEW_INVALID_QUOTE_SIZE_PRECISION, 
        PREVIEW_INVALID_QUOTE_SIZE_TOO_LARGE, 
        PREVIEW_INVALID_PRICE_TOO_LARGE, 
        PREVIEW_INVALID_QUOTE_SIZE_TOO_SMALL, 
        PREVIEW_BREACHED_PRICE_LIMIT, 
        PREVIEW_BREACHED_ACCOUNT_POSITION_LIMIT, 
        PREVIEW_BREACHED_COMPANY_POSITION_LIMIT, 
        PREVIEW_INVALID_MARGIN_HEALTH, 
        PREVIEW_RISK_PROXY_FAILURE
    }
}
