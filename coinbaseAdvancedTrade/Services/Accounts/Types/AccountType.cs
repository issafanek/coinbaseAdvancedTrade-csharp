using System.Runtime.Serialization;

namespace CoinbaseAdvancedTrade.Services.Accounts.Types
{
    public enum AccountType
    {
        ACCOUNT_TYPE_UNSPECIFIED, 
        ACCOUNT_TYPE_CRYPTO, 
        ACCOUNT_TYPE_FIAT, 
        ACCOUNT_TYPE_VAULT, 
    }
}
