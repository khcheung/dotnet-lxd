using System.Text.Json.Serialization;

namespace LXDClient.Models;

public class InstancePostRequestDto
{
    public String Name { get; set; } = String.Empty;
    [JsonPropertyName("instance_type")]
    public string? InstanceType { get; set; }
    public bool Start { get; set; }
    [JsonIgnore]
    public InstanceTypeEnum Type { get; set; }  = InstanceTypeEnum.Container;
    [JsonPropertyName("type") ]
    public String TypeString
    {
        get => Type switch {
            InstanceTypeEnum.VirtualMachine => "virtual-machine",
            InstanceTypeEnum.Container => "container",
            _ => "container"
        };
    }

    public InstanceSourceDto Source { get; set; }


}

public class InstanceSourceDto
{
    [JsonIgnore]
    public InstanceSourceTypeEnum Type { get; set; } = InstanceSourceTypeEnum.None;

    [JsonPropertyName("type")]
    public String TypeString
    {
        get => Type.ToString()!.ToLower();
    }

    public string? Alias { get; set; }
}

public enum InstanceSourceTypeEnum
{
    None,
    Image,
    Container
}

public enum InstanceTypeEnum {
    VirtualMachine,
    Container
}
