using System;
using System.Text.Json.Serialization;

namespace LXDClient.Models;

public class CertificatePublicRequestDto
{
    [JsonPropertyName("trust_token")]
    public String TrustToken { get; set; }  = String.Empty;
}
