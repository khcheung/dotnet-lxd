using System;
using System.Text.Json.Serialization;

namespace LXDClient.Models;

public class NetworkDto
{
    [JsonPropertyName("access_entitlements")]
    public String[] AccessEntitlements { get; set; } = null!;
    [JsonPropertyName("config")]
    public Dictionary<String, String>? Config { get; set; }
    [JsonPropertyName("description")]
    public String Description { get; set; } = null!;
    [JsonPropertyName("locations")]
    public String[] Locations { get; set; } = null!;
    [JsonPropertyName("name")]
    public String Name { get; set; } = null!;
    [JsonPropertyName("type")]
    public String Type { get; set; } = null!;
    [JsonPropertyName("managed")]
    public Boolean Managed { get; set; }
    [JsonPropertyName("status")]
    public String Status { get; set; } = null!;
    [JsonPropertyName("used_by")]
    public String[] UsedBy { get; set; } = null!;
}
