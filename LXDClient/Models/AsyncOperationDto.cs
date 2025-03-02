using System.Text.Json.Serialization;

namespace LXDClient.Models;

public class AsyncOperationDto
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("class")]
    public string Class { get; set; } = null!;

    [JsonPropertyName("description")]
    public string Description { get; set; } = null!;

    [JsonPropertyName("created_at")]
    public DateTimeOffset CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public DateTimeOffset UpdatedAt { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; } = null!;

    [JsonPropertyName("status_code")]
    public long StatusCode { get; set; }

    [JsonPropertyName("resources")]
    public Dictionary<String, String[]>? Resources { get; set; }

    [JsonPropertyName("metadata")]
    public Dictionary<String, Dictionary<String, String>>? Metadata { get; set; }

    [JsonPropertyName("may_cancel")]
    public bool MayCancel { get; set; }

    [JsonPropertyName("err")]
    public string? Err { get; set; }

    [JsonPropertyName("location")]
    public string? Location { get; set; }
}


