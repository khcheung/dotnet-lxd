namespace LXDClient.Models;

public class NetworkPostRequestDto {
    public Dictionary<String, String>? Config { get; set; }

    public String? Description {get; set; }
    public required String Name { get; set; }
    public required String Type { get; set; }
    
}
