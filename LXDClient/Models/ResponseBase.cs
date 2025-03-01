using System;
using System.Text.Json.Serialization;

namespace LXDClient.Models;

public class ResponseBase<T>
{
    [JsonPropertyName("type")]
    public String Type { get; set; } = String.Empty;
    [JsonPropertyName("status")]
    public String Status { get; set; } = String.Empty;
    [JsonPropertyName("status_code")]
    public Int32 StatusCode { get; set; }
    [JsonPropertyName("metadata")]
    public T? Metadata { get; set; } = default!;
    [JsonPropertyName("error_code")]
    public Int32 ErrorCode { get; set; }
    [JsonPropertyName("error")]
    public String Error { get; set; } = String.Empty;
}
