using System;
using CoinbaseAdvancedTrade.Services.Orders.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CoinbaseAdvancedTrade.Services.Orders.Models.Responses
{
    public class HistoricalOrderResponse
    {
        [JsonProperty("order")]
        public OrderHistorical? order {get; set;}
        //[JsonConverter(typeof(StringEnumConverter))]
        // [JsonProperty("failure_reason")]
        // public FailureReason FailureReason { get; set; }

        // [JsonProperty("order_id")]
        // public /*Guid*/ string OrderId { get; set; }
        // [JsonProperty("success_response")]
        // public OrderSuccessResponse? SuccessResponse {get; set;}
        // [JsonProperty("error_response")]
        // public OrderErrorResponse? ErrorResponse {get; set;}
        // [JsonProperty("order_configuration")]
        // public OrderConfiguration? OrderConfiguration {get; set;}
    }

    public class OrderHistorical
    {
        public string? order_id { get; set; }
        public string? product_id { get; set; }
        public string? user_id { get; set; }
        public OrderConfiguration order_configuration { get; set; }
        [JsonProperty("side")]
        [JsonConverter(typeof(StringEnumConverter))]
        public OrderSide? side { get; set; }
        public string? client_order_id { get; set; }
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public OrderStatus status { get; set; }
        [JsonProperty("time_in_force")]
        [JsonConverter(typeof(StringEnumConverter))]
        public TimeInForce time_in_force { get; set; }
        public DateTime created_time { get; set; }
        public decimal? completion_percentage { get; set; }
        public decimal filled_size { get; set; }
        public decimal average_filled_price { get; set; }
        public decimal fee { get; set; }
        public int number_of_fills { get; set; }
        public decimal filled_value { get; set; }
        public bool pending_cancel { get; set; }
        public bool size_in_quote { get; set; }
        public decimal? total_fees { get; set; }
        public bool size_inclusive_of_fees { get; set; }
        public decimal total_value_after_fees { get; set; }
        public string? trigger_status { get; set; }
        public string? order_type { get; set; }
        public string? reject_reason { get; set; }
        public bool settled { get; set; }
        public string? product_type { get; set; }
        public string? reject_message { get; set; }
        public string? cancel_message { get; set; }
        public string? order_placement_source { get; set; }
        public string? outstanding_hold_amount { get; set; }
        public bool is_liquidation { get; set; }
        public DateTime last_fill_time { get; set; }
        public List<object>? edit_history { get; set; }
        public string? leverage { get; set; }
        public string? margin_type { get; set; }
        public string? retail_portfolio_id { get; set; }
        public string? originating_order_id { get; set; }
        public string? attached_order_id { get; set; }
        public OrderConfiguration? attached_order_configuration { get; set; }
    }

    // public class OrderSuccessResponse
    // {
    //      [JsonProperty("order_id")]
    //     public string? OrderId { get; set; }
    //     [JsonProperty("product_id")]
    //     public string? ProductId { get; set; }
    //     [JsonProperty("side")]
    //     [JsonConverter(typeof(StringEnumConverter))]
    //     public OrderSide? Side { get; set; }
    //     [JsonProperty("client_order_id")]
    //     public string? ClientOrderId { get; set; }
    // }

    // public class OrderErrorResponse
    // {
    //     [JsonProperty("error")]
    //     [JsonConverter(typeof(StringEnumConverter))]
    //     public OrderError? Error { get; set; }
    //     [JsonProperty("message")]
    //     public string? Message { get; set; }
    //     [JsonProperty("error_details")]
    //     public string? ErrorDetails { get; set; }
    //     [JsonProperty("preview_failure_reason")]
    //     [JsonConverter(typeof(StringEnumConverter))]
    //     public PreviewFailureReason? PreviewFailureReason { get; set; }
    //      [JsonProperty("new_order_failure_reason")]
    //     [JsonConverter(typeof(StringEnumConverter))]
    //     public NewOrderFailureReason? NewOrderFailureReason { get; set; }
    // }
}
