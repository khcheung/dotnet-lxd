using System;

namespace LXDClient.PowerShell.Common;

public static class Config
{
    public static Models.Config LoadConfig()
    {        
        var homeFolder = "";
        if (System.Environment.OSVersion.Platform == PlatformID.Unix ||
            System.Environment.OSVersion.Platform == PlatformID.Other)
        {
            homeFolder = System.Environment.GetEnvironmentVariable("HOME");
        }
        else
        {
            homeFolder = System.Environment.GetEnvironmentVariable("USERPROFILE");
        }
        var configFolder = System.IO.Path.Combine(homeFolder!, ".config", "dotnetlxd");
        var configFile = System.IO.Path.Combine(configFolder, "config.json");
        if (!System.IO.Directory.Exists(configFolder))
        {
            System.IO.Directory.CreateDirectory(configFolder);
        }
        if (!System.IO.File.Exists(configFile))
        {
            var config = new Models.Config
            {
                ServerUrl = "https://localhost:8443",
                CertificatePath = System.IO.Path.Combine(homeFolder!, ".config", "dotnetlxd"),
                CertificateName = "dotnet"
            };
            var json = System.Text.Json.JsonSerializer.Serialize(config);
            System.IO.File.WriteAllText(configFile, json);
        }
        var configJson = System.IO.File.ReadAllText(configFile);
        var configObject = System.Text.Json.JsonSerializer.Deserialize<Models.Config>(configJson)!;
        return configObject;
    }

    public static CertHelper LoadCertificate(Models.Config config)
    {
        var certHelper = new LXDClient.CertHelper(config.CertificatePath);
        certHelper.GenerateCert(config.CertificateName, false).Wait();
        certHelper.LoadCert(config.CertificateName);
        return certHelper;
    }
}
