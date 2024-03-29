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
    public string TestAccountID = "";

    public Tests()
    {
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
        Assert.AreNotEqual(0, Product.Price, "Price was not fetched correctly");
    }

    [TestMethod]
    public void TestAccountsGet()
    {
        System.Threading.Thread.Sleep(2000);
        var Accounts = (Task.Run(async () => await CoinBase.AccountsService.GetAccountsAsync())).Result;
        //System.Console.WriteLine($"Accounts ID Fetched: {Product.Id}");
        Assert.IsTrue(Accounts.Count > 0, "Accounts were not fetched - number of accounts is zero or null.");
    }

    [TestMethod]
    public void TestAccountGetByUUID()
    {
        System.Threading.Thread.Sleep(1000);
        var Accounts = (Task.Run(async () => await CoinBase.AccountsService.GetAccountsAsync())).Result;
        TestAccountID = Accounts[0].UUID;
        System.Threading.Thread.Sleep(1000);
        var TestAccount = (Task.Run(async () => await CoinBase.AccountsService.GetAccountAsync(TestAccountID))).Result;
        Assert.IsFalse(String.IsNullOrEmpty(TestAccount.Name),"Account Name is Null or Empty");
        Assert.IsTrue(TestAccount.Name.Length > 0, $"Account {TestAccountID} was not fetched.");
    }
}