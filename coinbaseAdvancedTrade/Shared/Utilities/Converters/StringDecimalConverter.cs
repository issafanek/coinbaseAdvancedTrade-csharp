using System;
using System.Linq;
using CoinbaseAdvancedTrade.Services.Products.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Globalization;

namespace CoinbaseAdvancedTrade.Shared.Utilities.Converters
{
    public class StringDecimalConverter : JsonConverter
{
    public override bool CanRead
    {
        get
        {
            return false;
        }
    }

    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(decimal) || objectType == typeof(decimal?);
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        writer.WriteValue(((decimal)value).ToString(CultureInfo.InvariantCulture));
    }
}
}