using System.Text.Json.Serialization;

namespace LXDClient.Models;

public class ServerConfigDto
{
    [JsonPropertyName("core.https_address")]
    public String CoreHttpsAddress { get; set; } = null!;
}
