﻿

using System.Diagnostics.SymbolStore;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace LXDClient;

public class Client
{
    private readonly string serverUrl;
    private readonly X509Certificate2 certificate;

    private HttpClient httpClient = null!;

    public Client(String serverUrl, X509Certificate2 certificate)
    {
        this.serverUrl = serverUrl;
        this.certificate = certificate;
        this.CreateHttpClient();
    }


    private void CreateHttpClient()
    {
        HttpClientHandler handler = new();
        handler.ServerCertificateCustomValidationCallback = (sender, certificate, chain, _) =>
        {
            //var hash = String.Join(" ", certificate!.GetCertHash().Select(h => h.ToString("x02")));
            //Console.WriteLine(hash);
            return true;
        };

        handler.CheckCertificateRevocationList = false;
        handler.ClientCertificates.Add(certificate);
        handler.ClientCertificateOptions = ClientCertificateOption.Manual;
        handler.SslProtocols = System.Security.Authentication.SslProtocols.Tls13;
        HttpClient client = new HttpClient(handler);
        client.BaseAddress = new Uri(serverUrl);
        this.httpClient = client;
    }

    public async Task<Boolean> CertificatePublicPostAsync(String token)
    {
        var jsonObj = new
        {
            trust_token = token
        };
        var json = JsonSerializer.Serialize(jsonObj);
        var response = await this.httpClient.PostAsync("/1.0/certificates?public",
        new StringContent(json, System.Text.Encoding.UTF8, "application/json"));

        var content = await response.Content.ReadAsStringAsync();
        //Console.WriteLine(content);

        if (response.StatusCode == System.Net.HttpStatusCode.Created)
        {
            return true;
        }
        return false;
    }

    public async Task AuthIdentitiesOidcGetAsync()
    {
        var response = await this.httpClient.GetAsync("/1.0/auth/identities/oidc");
        Console.WriteLine(response.StatusCode);
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine(content);
        }
        else
        {
            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine(content);

        }
    }



    public async Task TestAsync()
    {

        var client = this.httpClient;

        //var response = await client.GetAsync("/");
        //var response = await client.GetAsync("/1.0");
        var response = await client.GetAsync("/1.0/auth/identities/oidc");

        Console.WriteLine(response.StatusCode);
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine(content);
        }
        else
        {
            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine(content);

        }
    }
}
