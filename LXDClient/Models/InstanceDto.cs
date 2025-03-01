using System;
using System.Text.Json.Serialization;

namespace LXDClient.Models;

public partial class InstanceDto
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("status_code")]
    public long StatusCode { get; set; }

    [JsonPropertyName("created_at")]
    public DateTimeOffset CreatedAt { get; set; }

    [JsonPropertyName("last_used_at")]
    public DateTimeOffset LastUsedAt { get; set; }

    [JsonPropertyName("location")]
    public string? Location { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("project")]
    public string? Project { get; set; }

    [JsonPropertyName("architecture")]
    public string? Architecture { get; set; }

    [JsonPropertyName("ephemeral")]
    public bool Ephemeral { get; set; }

    [JsonPropertyName("stateful")]
    public bool Stateful { get; set; }

    [JsonPropertyName("profiles")]
    public string[]? Profiles { get; set; }

    [JsonPropertyName("config")]
    public Dictionary<String, String>? Config { get; set; }

    [JsonPropertyName("devices")]
    public Dictionary<String, Dictionary<String, String>>? Devices { get; set; }

    [JsonPropertyName("expanded_config")]
    public Dictionary<String, String>? ExpandedConfig { get; set; }

    [JsonPropertyName("expanded_devices")]
    public Dictionary<String, Dictionary<String, String>>? ExpandedDevices { get; set; } 
}
