using System;
using System.Text.Json.Serialization;

namespace LXDClient.Models;

public class ServerDto
{
    [JsonPropertyName("access_entitlements")]
    public String[] AccessEntitlements { get; set; } = null!;
    [JsonPropertyName("api_extensions")]
    public String[] ApiExtensions { get; set; } = null!;
    [JsonPropertyName("api_status")]
    public String ApiStatus { get; set; } = null!;
    [JsonPropertyName("auth")]
    public String Auth { get; set; } = null!;
    [JsonPropertyName("config")]
    public ServerConfigDto Config { get; set; } = null!;
    [JsonPropertyName("environment")]
    public ServerEnvironmentDto Environment { get; set; } = null!;
    [JsonPropertyName("public")]
    public Boolean Public { get; set; }

}
