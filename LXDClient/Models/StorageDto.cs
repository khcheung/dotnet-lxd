using System;
using System.Text.Json.Serialization;

namespace LXDClient.Models;

public class StorageDto
{
    [JsonPropertyName("name")]
    public String Name { get; set; } = null!;
    [JsonPropertyName("driver")]
    public String Driver { get; set; } = null!;
    [JsonPropertyName("config")]
    public Dictionary<String,String> Config { get; set; } = null!;
    [JsonPropertyName("description")]
    public String Description { get; set; } = null!;
    [JsonPropertyName("status")]
    public String Status { get; set; } = null!;
    [JsonPropertyName("locations")]
    public String[] Locations { get; set; } = null!;
    [JsonPropertyName("used_by")]
    public String[] UsedBy { get; set; } = null!;
    [JsonPropertyName("access_entitlements")]
    public String[] AccessEntitlements { get; set; } = null!;

}
