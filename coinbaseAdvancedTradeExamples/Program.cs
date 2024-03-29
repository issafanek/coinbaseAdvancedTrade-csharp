﻿using System;
using CoinbaseAdvancedTrade;
using CoinbaseAdvancedTrade.Network;
using CoinbaseAdvancedTrade.Network.Authentication;
using CoinbaseAdvancedTrade.Services.Products.Models;
using CoinbaseAdvancedTrade.Services.Products.Types;
using CoinbaseAdvancedTrade.Services.Accounts.Models;
using System.Threading;
using System.Threading.Tasks;

namespace CoinbaseAdvancedTrade.Examples
{
    class Program 
    {

        private static CoinbaseAdvancedTradeClient CoinBase;
        private static string TestAccountUUID = "";

        static async Task Main(string[] args) {

            if(String.IsNullOrEmpty(Environment.GetEnvironmentVariable("COINBASE_API_KEY")) || 
                String.IsNullOrEmpty(Environment.GetEnvironmentVariable("COINBASE_PASSPHRASE")))
            {
                System.Console.WriteLine("Env variables for CB API KEY and PASSPHRASE are not set. Please set COINBASE_API_KEY and COINBASE_PASSPHRASE variables");
                return;
            }
            
            var authenticator = new Authenticator(
                Environment.GetEnvironmentVariable("COINBASE_API_KEY"), 
                Environment.GetEnvironmentVariable("COINBASE_PASSPHRASE"));
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
            if(await getHistoricalsAsync("ETH-USD", DateTime.UtcNow.AddDays(-2), DateTime.UtcNow, CandleGranularity.ONE_MINUTE) == false) System.Console.WriteLine("ERROR: Get historicals Failed.");
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