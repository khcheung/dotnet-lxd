

using LXDClient.Models;

namespace LXDClient.Test;

public class Program
{
    public static async Task Main(string[] args)
    {
        // Generate Cert / Load Cert
        string currentFolder = new FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).DirectoryName!;
        LXDClient.CertHelper certHelper = new LXDClient.CertHelper(currentFolder);
        await certHelper.GenerateCert("dotnet03", false);
        certHelper.LoadCert("dotnet03");

        // Create Client
        LXDClient.Client client = new("https://10.0.0.21:8443", certHelper.Certificate);

        // Add Cert With Trust Token
        //await client.CertificatePublicPostAsync("eyJjb.....");

        // Get Auth Identies OIDC (Test Client Cert Auth)
        //await client.AuthIdentitiesOidcGetAsync();

        //var instances = await client.InstancesGetRecursivelyAsync();

        // var instances = await client.InstancesGetAsync();
        // foreach (var instance in instances!)
        // {
        //     Console.WriteLine(instance);
        // }
        //await client.InstancesGetAsync("v1");


        // Create Empty VM
        // await client.InstancesPostAsync("default", new InstancePostRequestDto()
        // {
        //     Name = "v2",
        //     InstanceType = "t2.micro",
        //     Source = new InstanceSourceDto()
        //     {
        //         Type = InstanceSourceTypeEnum.None
        //     },
        //     Start = false,
        //     Type = InstanceTypeEnum.VirtualMachine
        // });

        // var v2 = await client.InstancesGetAsync("v2");
        // if (v2 != null)
        // {
        //     Console.WriteLine(v2!.Project);
        // }

        // var instanceV2 = await client.InstancesGetAsync("v2");

        // if (instanceV2 != null)
        // {
        //     instanceV2.Devices??= new Dictionary<string, Dictionary<string, string>>();
        //     instanceV2.Devices.Add("eth0", new Dictionary<string, string>() {
        //         {"type", "nic"},
        //         {"nictype", "bridged"},
        //         {"parent", "lxdbr0"}
        //     });
        //     await client.InstancesPutAsync("v2", new InstancePutRequestDto()
        //     {
        //         Architecture = instanceV2.Architecture,
        //         Config = instanceV2.Config,
        //         Description = instanceV2.Description,
        //         Ephemeral = instanceV2.Ephemeral,
        //         Profiles = instanceV2.Profiles,
        //         Stateful = instanceV2.Stateful,
        //         Devices = instanceV2.Devices
        //     });
        // }

        //await client.InstancesDeleteAsync("v2");

        // var networks = await client.NetworksGetAsync();
        // var networks2 = await client.NetworksGetRecursivelyAsync();

        // networks2?
        // .Where(n => n.Type != "unknown" && n.Type != "loopback")
        // .ToList()
        // .ForEach(n =>
        // {
        //     Console.WriteLine(n.Name);
        //     //Console.WriteLine(n.Type);
        // });

        // await client.NetworkPostAsync(new NetworkPostRequestDto()
        // {
        //     Name = "lxdbr1",
        //     Type = "bridge",
        //     Config = new Dictionary<string, string>() {
        //         {"ipv4.address", "10.0.22.1/24"},
        //         {"ipv4.nat", "true"},
        //         {"ipv6.address", "none"},
        //         {"ipv6.nat", "true"}
        //     }
        // });

        // var br1 = await client.NetworksGetAsync("lxdbr1");
        // if (br1 != null)
        // {
        //     br1.Config!["ipv4.address"] = "10.0.22.2/24";

        //     await client.NetworkPutAsync("lxdbr1", new NetworkPutRequestDto()
        //     {
        //         Description = br1.Description,
        //         Config = br1.Config
        //     });
        // }

        //await client.NetworkDeleteAsync("lxdbr1");

        // var storages1 = await client.StoragesGetAsync();
        // var storage = await client.StoragesGetAsync("default");
        // var storages = await client.StoragesGetRecursivelyAsync();

    }
}

