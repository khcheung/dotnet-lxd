using System;
using System.Management.Automation;

namespace LXDClient.PowerShell.Storages;

[Cmdlet(VerbsCommon.Get, "LXDStorages")]
public class ListStoragesCommand : Cmdlet
{
     private Client _client = null!;

    protected override void BeginProcessing()
    {
        base.BeginProcessing();
        var config = Common.Config.LoadConfig();
        var certHelper = Common.Config.LoadCertificate(config);
        this._client = new LXDClient.Client(config.ServerUrl, certHelper.Certificate);
    }

    protected override void ProcessRecord()
    {
        var storages = this._client.StoragesGetRecursivelyAsync().Result;
        foreach (var storage in storages!)
        {
            WriteObject(new
            {
                Name = storage.Name,
                Driver = storage.Driver,
                Description = storage.Description,
                Status = storage.Status,
                Locations = storage.Locations,
                UsedBy = storage.UsedBy,
                AccessEntitlements = storage.AccessEntitlements
            });
        }
    }

}
