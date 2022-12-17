using System;
using CoinbaseAdvancedTrade.Network.Authentication;
using CoinbaseAdvancedTrade.Network.HttpClient;
using CoinbaseAdvancedTrade.Network.HttpRequest;
// using CoinbaseAdvancedTrade.Services.Accounts;
// using CoinbaseAdvancedTrade.Services.CoinbaseAccounts;
// using CoinbaseAdvancedTrade.Services.Currencies;
// using CoinbaseAdvancedTrade.Services.Deposits;
using CoinbaseAdvancedTrade.Services.Fees;
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
using CoinbaseAdvancedTrade.Shared.Utilities.Clock;
using CoinbaseAdvancedTrade.Shared.Utilities.Queries;
// using CoinbaseAdvancedTrade.WebSocket;
using Serilog;

namespace CoinbaseAdvancedTrade
{
    public class CoinbaseAdvancedTradeClient : ICoinbaseAdvancedTradeClient
    {
        public CoinbaseAdvancedTradeClient(
            bool sandBox = false)
                : this(null, new Network.HttpClient.HttpClient(), sandBox)
        {
        }

        public CoinbaseAdvancedTradeClient(
            IAuthenticator authenticator,
            bool sandBox = false)
                : this(authenticator, new Network.HttpClient.HttpClient(), sandBox)
        {
        }

        public CoinbaseAdvancedTradeClient(
            IAuthenticator authenticator,
            IHttpClient httpClient,
            bool sandBox = false)
        {
            var clock = new Clock();
            var httpRequestMessageService = new HttpRequestMessageService(authenticator, clock, sandBox);
            //var createWebSocketFeed = (Func<IWebSocketFeed>)(() => new WebSocketFeed(sandBox));
            var queryBuilder = new QueryBuilder();

            //AccountsService = new AccountsService(httpClient, httpRequestMessageService);
            //CoinbaseAccountsService = new CoinbaseAccountsService(httpClient, httpRequestMessageService);
            OrdersService = new OrdersService(httpClient, httpRequestMessageService, queryBuilder);
            //PaymentsService = new PaymentsService(httpClient, httpRequestMessageService);
            //WithdrawalsService = new WithdrawalsService(httpClient, httpRequestMessageService, queryBuilder);
            //DepositsService = new DepositsService(httpClient, httpRequestMessageService, queryBuilder);
            ProductsService = new ProductsService(httpClient, httpRequestMessageService, queryBuilder);
            //CurrenciesService = new CurrenciesService(httpClient, httpRequestMessageService);
            //LimitsService = new LimitsService(httpClient, httpRequestMessageService);
            //FillsService = new FillsService(httpClient, httpRequestMessageService);
            //FundingsService = new FundingsService(httpClient, httpRequestMessageService, queryBuilder);
            //ReportsService = new ReportsService(httpClient, httpRequestMessageService);
            //UserAccountService = new UserAccountService(httpClient, httpRequestMessageService);
            //StablecoinConversionsService = new StablecoinConversionsService(httpClient, httpRequestMessageService);
            FeesService = new FeesService(httpClient, httpRequestMessageService);
            //ProfilesService = new ProfilesService(httpClient, httpRequestMessageService);
            //WebSocket = new WebSocket.WebSocket(createWebSocketFeed, authenticator, clock);

            Log.Information("CoinbaseAdvancedTradeClient constructed");
        }

        // public IAccountsService AccountsService { get; }

        // public ICoinbaseAccountsService CoinbaseAccountsService { get; }

        public IOrdersService OrdersService { get; }

        // public IPaymentsService PaymentsService { get; }

        // public IWithdrawalsService WithdrawalsService { get; }

        // public IDepositsService DepositsService { get; }

        public IProductsService ProductsService { get; }

        // public ICurrenciesService CurrenciesService { get; }

        // public IFillsService FillsService { get; }

        // public ILimitsService LimitsService { get; }

        // public IFundingsService FundingsService { get; }

        public IFeesService FeesService { get; }

        // public IReportsService ReportsService { get; }

        // public IUserAccountService UserAccountService { get; }

        // public IStablecoinConversionsService StablecoinConversionsService { get; }

        // public IProfilesService ProfilesService { get; }

        // public IWebSocket WebSocket { get; }
    }
}
