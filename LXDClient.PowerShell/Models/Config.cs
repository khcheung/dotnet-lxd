using System;

namespace LXDClient.PowerShell.Models;

public class Config
{
    public string ServerUrl { get; set; } = null!;
    public string CertificatePath { get; set; } = null!;
    public string CertificateName { get; set; } = null!;
}
