using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoinbaseAdvancedTrade;
using CoinbaseAdvancedTrade.Network;
using CoinbaseAdvancedTrade.Network.Authentication;
using CoinbaseAdvancedTrade.Services.Products.Models;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace coinbaseAdvancedTradeTests;

[TestClass]
public class Tests
{
    private readonly CoinbaseAdvancedTradeClient CoinBase;
    public Product Product = new Product();

    public Tests()
    {
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
    }

    // [TestMethod]
    // public void Test1()
    // {
    //     Assert.AreEqual("0.001", "0.001","Not Equal");
    // }

    [TestMethod]
    public void TestProductGet()
    {
        Product = (Task.Run(async () => await CoinBase.ProductsService.GetSingleProductAsync("ETH-USD"))).Result;
        System.Console.WriteLine($"Product ID Fetched: {Product.Id}");
        Assert.AreEqual("ETH-USD", Product.Id, "Product wasn't fetched correctly");
        Assert.AreEqual("ETH", Product.base_currency_id, "Base Currency wasn't fetched correctly");
        Assert.AreEqual("USD", Product.quote_currency_id, "Quote Currency wasn't fetched correctly");
    }
}