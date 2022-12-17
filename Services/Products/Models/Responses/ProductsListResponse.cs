using CoinbaseAdvancedTrade.Services.Products;

namespace CoinbaseAdvancedTrade.Services.Products.Models.Responses
{
    public class ProductsListResponse
    {
        public List<Product> products { get; set; }
        public int num_products { get; set; }
    }
}