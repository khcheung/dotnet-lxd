using System.Text.Json.Serialization;

namespace LXDClient.Models;

public class AsyncResponseBase<T> : ResponseBase<T>
{
    [JsonPropertyName("operation")]
    public String Operation { get; set; } = String.Empty;
}
