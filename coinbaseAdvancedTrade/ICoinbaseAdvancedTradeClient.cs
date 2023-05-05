// using CoinbaseAdvancedTrade.Services.Accounts;
// using CoinbaseAdvancedTrade.Services.CoinbaseAccounts;
// using CoinbaseAdvancedTrade.Services.Currencies;
// using CoinbaseAdvancedTrade.Services.Deposits;
using CoinbaseAdvancedTrade.Services.Fees;
using CoinbaseAdvancedTrade.Services.Fills;
// using CoinbaseAdvancedTrade.Services.Fills;
// using CoinbaseAdvancedTrade.Services.Fundings;
// using CoinbaseAdvancedTrade.Services.Limits;
using CoinbaseAdvancedTrade.Services.Orders;
// using CoinbaseAdvancedTrade.Services.Payments;
using CoinbaseAdvancedTrade.Services.Products;
// using CoinbaseAdvancedTrade.Services.Profiles;
// using CoinbaseAdvancedTrade.Services.Reports;
// using CoinbaseAdvancedTrade.Services.StablecoinConversions;
// using CoinbaseAdvancedTrade.Services.UserAccount;
// using CoinbaseAdvancedTrade.Services.Withdrawals;
// using CoinbaseAdvancedTrade.WebSocket;

namespace CoinbaseAdvancedTrade
{
    public interface ICoinbaseAdvancedTradeClient
    {
        //IAccountsService AccountsService { get; }

        //ICoinbaseAccountsService CoinbaseAccountsService { get; }

        IOrdersService OrdersService { get; }

        // IPaymentsService PaymentsService { get; }

        // IWithdrawalsService WithdrawalsService { get; }

        // IDepositsService DepositsService { get; }

        IProductsService ProductsService { get; }

       // ICurrenciesService CurrenciesService { get; }

        //IFillsService FillsService { get; }

        IFeesService FeesService { get; }
        IFillsService FillsService { get; }

        // IFundingsService FundingsService { get; }

        // IReportsService ReportsService { get; }

        // IUserAccountService UserAccountService { get; }

        // IStablecoinConversionsService StablecoinConversionsService { get; }

        // IWebSocket WebSocket { get; }

        // IProfilesService ProfilesService { get; }

        // ILimitsService LimitsService { get; }
    }
}
