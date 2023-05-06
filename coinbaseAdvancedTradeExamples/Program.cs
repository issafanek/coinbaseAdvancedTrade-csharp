using System;
using CoinbaseAdvancedTrade;
using CoinbaseAdvancedTrade.Network;
using CoinbaseAdvancedTrade.Network.Authentication;
using CoinbaseAdvancedTrade.Services.Products.Models;
using System.Threading;
using System.Threading.Tasks;

namespace CoinbaseAdvancedTrade.Examples
{
    class Program 
    {

        private static CoinbaseAdvancedTradeClient CoinBase;  

        static async Task Main(string[] args) {

            string apiKey = "";
            string passPhrase = "";
            System.Console.WriteLine(System.IO.File.Exists("Sensitive.txt"));
            if(System.IO.File.Exists("Sensitive.txt"))
            {
                string [] allLines = System.IO.File.ReadAllLines("Sensitive.txt");
                if(allLines.Length >= 2)
                {
                    apiKey = allLines[0];
                    passPhrase = allLines[1];
                }
                System.Console.WriteLine(apiKey);
                System.Console.WriteLine(passPhrase);
                if(string.IsNullOrEmpty(apiKey) || string.IsNullOrEmpty(passPhrase))
                {
                    System.Console.WriteLine("API Key or Passphrase not entered correctly.");
                    return;
                }
                var authenticator = new Authenticator(apiKey, passPhrase);

                CoinBase = new CoinbaseAdvancedTradeClient(authenticator);
            }


            System.Console.WriteLine("--- Product Test ---");
            bool ProductGetTest = await ProductGetAsync("ETH-USD");
            ProductGetTest = await ProductGetAsync("BTC-USD");
            ProductGetTest = await ProductGetAsync("SOL-USD");
            ProductGetTest = await ProductGetAsync("DOGE-USD");
            Console.ReadLine();
        }

        public static async Task<bool> ProductGetAsync(string id)
        {
            try
            {
                var Product = await CoinBase.ProductsService.GetSingleProductAsync(id);
                //System.Console.WriteLine($"Product ID Fetched: {Product.Id}");
                //Assert.AreEqual("ETH-USD", Product.Id, "Product wasn't fetched correctly");
                //Assert.AreEqual("ETH", Product.base_currency_id, "Base Currency wasn't fetched correctly");
                //Assert.AreEqual("USD", Product.quote_currency_id, "Quote Currency wasn't fetched correctly");

                System.Console.WriteLine($"{Product.Id} | Price: {Product.Price}{Product.quote_currency_id} | 24h Change: {Product.price_percentage_change_24h.ToString("0.00")}% | Volume: {Product.volume_24h} | BaseMinSize: {Product.BaseMinSize} | BaseIncrement: {Product.BaseIncrement} | QuoteMinSize: {Product.quote_min_size}{Product.quote_currency_id}");

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