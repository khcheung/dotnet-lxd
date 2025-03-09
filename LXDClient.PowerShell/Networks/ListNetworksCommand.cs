using System;
using System.Management.Automation;

namespace LXDClient.PowerShell.Networks;

[Cmdlet(VerbsCommon.Get, "LXDNetworks")]
public class ListNetworksCommand : Cmdlet
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
        var networks = this._client.NetworksGetAsync().Result;
        foreach (var network in networks!)
        {
            WriteObject(new { NetworkPath = network });
        }
    }

}
