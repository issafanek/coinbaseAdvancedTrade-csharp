using System;
using CoinbaseAdvancedTrade.Services.Orders.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CoinbaseAdvancedTrade.Services.Orders.Models.Responses
{
    public class OrderResponse
    {
        [JsonProperty("success")]
        public bool Success {get; set;}
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("failure_reason")]
        public FailureReason FailureReason { get; set; }

        [JsonProperty("order_id")]
        public Guid OrderId { get; set; }
        [JsonProperty("success_response")]
        public OrderSuccessResponse? SuccessResponse {get; set;}
        [JsonProperty("error_response")]
        public OrderErrorResponse? ErrorResponse {get; set;}
        [JsonProperty("order_configuration")]
        public OrderConfiguration? OrderConfiguration {get; set;}
    }

    public class OrderSuccessResponse
    {
         [JsonProperty("order_id")]
        public string? OrderId { get; set; }
        [JsonProperty("product_id")]
        public string? ProductId { get; set; }
        [JsonProperty("side")]
        [JsonConverter(typeof(StringEnumConverter))]
        public OrderSide? Side { get; set; }
        [JsonProperty("client_order_id")]
        public string? ClientOrderId { get; set; }
    }

    public class OrderErrorResponse
    {
        [JsonProperty("error")]
        [JsonConverter(typeof(StringEnumConverter))]
        public OrderError? Error { get; set; }
        [JsonProperty("message")]
        public string? Message { get; set; }
        [JsonProperty("error_details")]
        public string? ErrorDetails { get; set; }
        [JsonProperty("preview_failure_reason")]
        [JsonConverter(typeof(StringEnumConverter))]
        public PreviewFailureReason? PreviewFailureReason { get; set; }
         [JsonProperty("new_order_failure_reason")]
        [JsonConverter(typeof(StringEnumConverter))]
        public NewOrderFailureReason? NewOrderFailureReason { get; set; }
    }
}
