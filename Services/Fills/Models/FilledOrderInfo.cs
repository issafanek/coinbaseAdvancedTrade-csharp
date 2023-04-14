using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using CoinbaseAdvancedTrade.Services.Fills.Types;

namespace CoinbaseAdvancedTrade.Services.Fills.Models
{
    public class FilledOrderInfo
    {
        public FilledOrderInfo(List<Fill> fills)
        {
            if(fills.Count == 0) return;
            
            numOfFills = fills.Count;
            order_id = fills[0].order_id;

            trade_ids = new List<string>();
            entry_ids = new List<string>();
            trade_times = new List<DateTime>();
            sequence_timestamps = new List<DateTime>();
            liquidity_indicators = new List<LiquidityIndicator>();

            trade_type = fills[0].trade_type;

            price = 0;
            sizeInCryptoCurrency = 0;
            sizeInQuoteCurrency = 0;
            commission = 0;

            product_id = fills[0].product_id;
            size_in_quote = fills[0].size_in_quote;
            user_id = fills[0].user_id;
            side = fills[0].side;

            if(size_in_quote == true)
            {
                foreach(var fill in fills)
                {
                    price += fill.price * fill.size;
                    sizeInQuoteCurrency += fill.size;
                    commission += fill.commission;
                }
                price /= sizeInQuoteCurrency;

                //base increment for ETH and BTC is 0.00000000
                sizeInCryptoCurrency = sizeInQuoteCurrency / price;
                sizeInCryptoCurrency = decimal.Round(sizeInCryptoCurrency, 8);
            }
            else
            {
                foreach(var fill in fills)
                {
                    price += fill.price * fill.size;
                    sizeInCryptoCurrency += fill.size;
                    commission += fill.commission;
                }
                price /= sizeInCryptoCurrency;

                //base increment for ETH and BTC is 0.00000000
                sizeInQuoteCurrency = sizeInCryptoCurrency * price;
                //sizeInQuoteCurrency = decimal.Round(sizeInQuoteCurrency, 2, MidpointRounding.ToZero);
            }
        }

        public string order_id { get; set; }
        public List<string> trade_ids {get; set;}
        public List<string> entry_ids {get; set;}
        public List<DateTime> trade_times {get; set;}
        public int numOfFills {get; set; }


        [JsonConverter(typeof(StringEnumConverter))]
        public TradeType trade_type { get; set; }
        public decimal price { get; set; }
        public decimal sizeInCryptoCurrency { get; set; }

        //in Coinbase, this is referred to as size in quote
        public decimal sizeInQuoteCurrency {get; set; }
        public decimal commission { get; set; }
        public string product_id { get; set; }
        public List<DateTime> sequence_timestamps { get; set; }
        public List<LiquidityIndicator> liquidity_indicators { get; set; }
        public bool size_in_quote { get; set; }
        public string user_id { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Side side { get; set; }
    }
}