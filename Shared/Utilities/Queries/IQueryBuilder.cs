using System.Collections.Generic;

namespace CoinbaseAdvancedTrade.Shared.Utilities.Queries
{
    public interface IQueryBuilder
    {
        string BuildQuery(params KeyValuePair<string, string>[] queryParameters);
    }
}
