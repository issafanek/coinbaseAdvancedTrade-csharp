using System;
using CoinbaseAdvancedTrade;
using CoinbaseAdvancedTrade.Network;
using CoinbaseAdvancedTrade.Network.Authentication;
using CoinbaseAdvancedTrade.Services.Products.Models;
using CoinbaseAdvancedTrade.Services.Products.Types;
using CoinbaseAdvancedTrade.Services.Accounts.Models;
using CoinbaseAdvancedTrade.Services.Fills.Models;
using System.Threading;
using System.Threading.Tasks;

namespace CoinbaseAdvancedTrade.Examples
{
    class Program 
    {

        private static CoinbaseAdvancedTradeClient CoinBase;
        private static string TestAccountUUID = "";

        static async Task Main(string[] args) {

            if(String.IsNullOrEmpty(Environment.GetEnvironmentVariable("IF_COINBASE_API_KEY")) || 
                String.IsNullOrEmpty(Environment.GetEnvironmentVariable("IF_COINBASE_API_SECRET")))
            {
                System.Console.WriteLine("Env variables for CB API KEY and PASSPHRASE are not set. Please set COINBASE_API_KEY and COINBASE_PASSPHRASE variables");
                return;
            }
            
            var authenticator = new Authenticator(
                Environment.GetEnvironmentVariable("IF_COINBASE_API_KEY"), 
                Environment.GetEnvironmentVariable("IF_COINBASE_API_SECRET"));
            CoinBase = new CoinbaseAdvancedTradeClient(authenticator);

            System.Console.WriteLine("--- Get All Accounts Test ---");
            if(await AccountsGetAsync() == false) System.Console.WriteLine("ERROR: Get All Accounts Test Failed.");
            System.Threading.Thread.Sleep(4000);
            System.Console.WriteLine("--- Get Account by UUID Test ---");
            if(await AccountsGetByUUIDAsync(TestAccountUUID) == false) System.Console.WriteLine("ERROR: Get Account by UUID Test Failed.");;

            System.Threading.Thread.Sleep(2000);

            System.Console.WriteLine("--- Product Test ---");
            bool ProductGetTest = await ProductGetAsync("ETH-USD");
            System.Threading.Thread.Sleep(800);
            ProductGetTest = await ProductGetAsync("BTC-USD");
            System.Threading.Thread.Sleep(800);
            ProductGetTest = await ProductGetAsync("SOL-USD");
            System.Threading.Thread.Sleep(800);
            ProductGetTest = await ProductGetAsync("DOGE-USD");
            System.Threading.Thread.Sleep(800);
            ProductGetTest = await ProductGetAsync("ETH-USDC");

            System.Threading.Thread.Sleep(2000);

            System.Console.WriteLine("--- Fees Summary Test ---");
            if(await TransactionFeesAsync() == false) System.Console.WriteLine("ERROR: Get Transaction Fees Summary Failed.");

            System.Threading.Thread.Sleep(2000);
            System.Console.WriteLine("--- Historicals ---");
            if(await getHistoricalsAsync("ETH-USD", DateTime.UtcNow.AddDays(/*-8*365*/-2), DateTime.UtcNow.AddDays(/*-8*365*/-1), CandleGranularity.ONE_MINUTE) == false) System.Console.WriteLine("ERROR: Get historicals Failed.");
            
            System.Threading.Thread.Sleep(2000);
            System.Console.WriteLine("--- Order fill Test ---");
            if(await OrderFillTest() == false) System.Console.WriteLine("ERROR: Get Transaction Fees Summary Failed.");;
            
            
            Console.ReadLine();
        }

        public static async Task<bool> getHistoricalsAsync(string pair, DateTime start, DateTime end, CandleGranularity granularity)
        {
            try
            {
                System.Console.WriteLine($"Getting historicals for {pair} between {start.ToString("yyyy-MM-dd HH:mm:ss")} and {start.ToString("yyyy-MM-dd HH:mm:ss")}");
                var history = await CoinBase.ProductsService.GetHistoricRatesAsync(pair, start, end, granularity);
                var counter = 1;
                foreach(var candle in history)
                {
                    System.Console.WriteLine($"[{counter}]\t{candle.Time}: {candle.Low}  {candle.High}  {candle.Open}  {candle.Close}  {candle.Volume}");
                    counter++;
                }
                return true;
            }
            catch(Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return false;
            }
        }

        public static async Task<bool> OrderFillTest()
        {
            try
            {
                //string OrderUUID = "b3434b06-344c-42da-b252-67672e89e064";
                string OrderUUID = "ca6a91c6-0971-4026-ba96-001e848b7544";
                var OrderFillSummary = await CoinBase.FillsService.GetFillsByOrderIDAsync(OrderUUID);
                int countOfFills = ((List<Fill>)(OrderFillSummary)).Count;
                System.Console.WriteLine($"Order to get fills for: {OrderUUID}");
                System.Console.WriteLine($"Number of fills: {countOfFills}");
                int i = 1;
                foreach (var fill in ((List<Fill>)(OrderFillSummary)))
                {
                    System.Console.WriteLine($"Fill {i} out of {countOfFills}");
                    System.Console.WriteLine($"   Entry ID: {fill.entry_id}");
                    System.Console.WriteLine($"   Trade ID: {fill.trade_id}");
                    System.Console.WriteLine($"   Order ID: {fill.order_id}");
                    System.Console.WriteLine($"   Trade time: {fill.trade_time}");
                    System.Console.WriteLine($"   Trade type: {fill.trade_type}");
                    System.Console.WriteLine($"   Price: {fill.price}");
                    System.Console.WriteLine($"   Size: {fill.size}");
                    System.Console.WriteLine($"   Commission: {fill.commission}");
                    System.Console.WriteLine($"   Product ID: {fill.product_id}");
                    System.Console.WriteLine($"   Sequence Timestamp: {fill.sequence_timestamp}");
                    System.Console.WriteLine($"   Liquidity Indicator: {fill.liquidity_indicator}");
                    System.Console.WriteLine($"   Size in Quote: {fill.size_in_quote}");
                    System.Console.WriteLine($"   User ID: {fill.user_id}");
                    System.Console.WriteLine($"   Side: {fill.side}");
                    System.Console.WriteLine($"   Retail Portfolio ID: {fill.retail_portfolio_id}");
                    System.Console.WriteLine("----------");
                    i++;
                }
                return true;
            }
            catch(Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return false;
            }
        }
        public static async Task<bool> TransactionFeesAsync()
        {
            try
            {
                var TransactionSummary = await CoinBase.FeesService.GetCurrentFeesAsync();
                System.Console.WriteLine("Trailing 30 day:");
                System.Console.WriteLine($"Total Volume: {TransactionSummary.TotalVolume} | Total Fees: {TransactionSummary.TotalFees}");// | Fee Tier: {TransactionSummary.TotalFees("0.00")}% | Volume: {Product.volume_24h} | BaseMinSize: {Product.BaseMinSize} | BaseIncrement: {Product.BaseIncrement} | QuoteMinSize: {Product.quote_min_size}{Product.quote_currency_id}");
                System.Console.WriteLine($"Tier: {TransactionSummary.FeeTier.PricingTier} | From {TransactionSummary.FeeTier.UsdFrom}USD to {TransactionSummary.FeeTier.UsdTo}USD | Taker Fee Rate: {TransactionSummary.FeeTier.TakerFeeRate} | Maker Fee Rate: {TransactionSummary.FeeTier.MakerFeeRate}" );
                return true;
            }
            catch(Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return false;
            }
        }
        public static async Task<bool> ProductGetAsync(string id)
        {
            try
            {
                var Product = await CoinBase.ProductsService.GetSingleProductAsync(id);
                System.Console.WriteLine($"{Product.Id} | Price: {Product.Price}{Product.quote_currency_id} | 24h Change: {Product.price_percentage_change_24h.ToString("0.00")}% | Volume: {Product.volume_24h} | BaseMinSize: {Product.BaseMinSize} | BaseIncrement: {Product.BaseIncrement} | QuoteMinSize: {Product.quote_min_size}{Product.quote_currency_id}");

                return true;
            }
            catch(Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return false;
            }
        }

        public static async Task<bool> AccountsGetAsync()
        {
            try
            {
                var Accounts = await CoinBase.AccountsService.GetAccountsAsync();
                
                foreach(var Account in Accounts)
                {
                    System.Console.WriteLine($"{Account.UUID} | {Account.Name} in {Account.Currency} | Default: {Account.Default} | Active: {Account.Active} | Balance: {Account.AvailableBalance.Value}{Account.AvailableBalance.Currency} | Type: {Account.Type} | Ready: {Account.Ready} | Hold: {Account.Hold.Value}{Account.Hold.Currency} | Created: {Account.created_at} | Updated: {Account.updated_at} | Deleted: {Account.deleted_at}");
                }
                TestAccountUUID = Accounts[1].UUID;
                System.Console.WriteLine($"Test UUID set to {TestAccountUUID}");

                return true;
            }
            catch(Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return false;
            }
        }

        public static async Task<bool> AccountsGetByUUIDAsync(string UUID)
        {
            try
            {
                System.Console.WriteLine($"Test UUID to be Used: {UUID}");
                var Acc = await CoinBase.AccountsService.GetAccountAsync(UUID);
                System.Console.WriteLine($"{Acc.UUID} | {Acc.Name} in {Acc.Currency} | Default: {Acc.Default} | Active: {Acc.Active} | Balance: {Acc.AvailableBalance.Value}{Acc.AvailableBalance.Currency} | Type: {Acc.Type} | Ready: {Acc.Ready} | Hold: {Acc.Hold.Value}{Acc.Hold.Currency} | Created: {Acc.created_at} | Updated: {Acc.updated_at} | Deleted: {Acc.deleted_at}");
                
                return true;
            }
            catch(Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}