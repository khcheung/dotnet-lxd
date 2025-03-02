using System;
using System.Text.Json.Serialization;

namespace LXDClient.Models;

public class NetworkPutRequestDto
{
    [JsonPropertyName("description")]
    public String? Description { get; set; }
    [JsonPropertyName("config")]
    public Dictionary<String, String>? Config { get; set; }
}
