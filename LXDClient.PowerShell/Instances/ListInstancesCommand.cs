﻿using System.Management.Automation;
using LXDClient.PowerShell.Models;

namespace LXDClient.PowerShell.Instances;


[Cmdlet(VerbsCommon.Get, "LXDInstances")]
public class ListInstancesCommand : Cmdlet
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
        var instances = this._client.InstancesGetRecursivelyAsync().Result;
        foreach (var instance in instances!)
        {
            WriteObject(new
            {
                Name = instance.Name,
                Type = instance.Type,
                Description = instance.Description,
                Status = instance.Status,
                Architecture = instance.Architecture
            });
        }
    }
}



