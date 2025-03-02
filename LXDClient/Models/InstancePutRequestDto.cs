using System;
using System.Text.Json.Serialization;

namespace LXDClient.Models;

public class InstancePutRequestDto
{
    [JsonPropertyName("architecture"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public String? Architecture { get; set; }
    [JsonPropertyName("config"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dictionary<String, String>? Config { get; set; }
    [JsonPropertyName("description"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public String? Description { get; set; }
    [JsonPropertyName("devices"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dictionary<String, Dictionary<String, String>>? Devices { get; set; }
    [JsonPropertyName("ephemeral"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Boolean? Ephemeral { get; set; }
    [JsonPropertyName("profiles"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public String[]? Profiles { get; set; }
    [JsonPropertyName("stateful"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Boolean? Stateful { get; set; }
    [JsonPropertyName("restore"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public String? Restore { get; set; }
}
