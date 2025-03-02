

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

        //await client.InstancesDeleteAsync("v2");
    }
}

