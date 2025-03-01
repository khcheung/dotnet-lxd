

namespace LXDClient.Test;

public class Program
{
    public static async Task Main(string[] args)
    {
        // Generate Cert / Load Cert
        string currentFolder = new FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).DirectoryName!;
        LXDClient.CertHelper certHelper = new LXDClient.CertHelper(currentFolder);
        await certHelper.GenerateCert("dotnet", false);
        certHelper.LoadCert("dotnet");

        // Create Client
        LXDClient.Client client = new("https://10.0.0.21:8443", certHelper.Certificate);

        // Add Cert With Trust Token
        //await client.CertificatePublicPostAsync("TOKEN");

        // Get Auth Identies OIDC (Test Client Cert Auth)
        //await client.AuthIdentitiesOidcGetAsync();

        //await client.InstancesGetAsync();
        //await client.InstancesGetAsync("v1");
    }
}

