using System;
using System.Globalization;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;

namespace CoinbaseAdvancedTrade.Network.Authentication
{
    public class Authenticator : IAuthenticator
    {
        private static readonly bool debug = false;

        public Authenticator(
            string apiKey,
            string unsignedSignature)//,
            //string passphrase)
        {
            if (string.IsNullOrEmpty(apiKey) || string.IsNullOrEmpty(unsignedSignature) /*||
                string.IsNullOrEmpty(passphrase)*/)
            {
                // throw new ArgumentException(
                //     $"{nameof(Authenticator)} requires parameters {nameof(apiKey)}, {nameof(unsignedSignature)} and {nameof(passphrase)} to be populated.");
                throw new ArgumentException(
                    $"{nameof(Authenticator)} requires parameters {nameof(apiKey)}, {nameof(unsignedSignature)} to be populated.");
            }

            ApiKey = apiKey;
            UnsignedSignature = unsignedSignature;
            //Passphrase = passphrase;
        }

        public string ApiKey { get; }

        public string UnsignedSignature { get; }

        //public string Passphrase { get; }

        public string ComputeSignature(
            HttpMethod httpMethod, 
            string secret, 
            double timestamp, 
            string requestUri, 
            string contentBody = "")
        {
            //timestamp = 1671298666;
            if(debug) Console.WriteLine($"secret={secret} requestUri={requestUri}");
            //var convertedString = Convert.FromBase64String(secret);
            var convertedString = Encoding.UTF8.GetBytes(secret);
            var prehash = timestamp.ToString("F0", CultureInfo.InvariantCulture) + httpMethod.ToString().ToUpper() + requestUri.Split("?")[0] + contentBody;
            //prehash = "1671299955GET/api/v3/brokerage/products";
            if(debug) Console.WriteLine($"prehash = {prehash}");
            return HashString(prehash, convertedString);
        }

        private string HashString(string str, byte[] secret)
        {
            var bytes = Encoding.UTF8.GetBytes(str);
            using (var hmaccsha = new HMACSHA256(secret))
            {
                //return Convert.ToBase64String(hmaccsha.ComputeHash(bytes));
                return Convert.ToHexString(hmaccsha.ComputeHash(bytes)).ToLower();
            }
        }
    }
}