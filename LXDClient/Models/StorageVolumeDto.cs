using System;
using System.Text.Json.Serialization;

namespace LXDClient.Models;

public class StorageVolumeDto
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;
    [JsonPropertyName("used_by")]
    public string[] UsedBy { get; set; } = [];
    [JsonPropertyName("location")]
    public string Location { get; set; } = string.Empty;
    [JsonPropertyName("pool")]
    public string Pool { get; set; } = string.Empty;
    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;
    [JsonPropertyName("content_type")]
    public string ContentType { get; set; } = string.Empty;
    [JsonPropertyName("config")]
    public Dictionary<string, string> Config { get; set; } = new();
    [JsonPropertyName("project")]
    public string Project { get; set; } = string.Empty;
}
