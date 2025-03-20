using System.Text.Json.Serialization;

namespace LXDClient.Models;

public class ServerEnvironmentDto
{
    [JsonPropertyName("addresses")]
    public String[] Addresses { get; set; } = null!;
}
