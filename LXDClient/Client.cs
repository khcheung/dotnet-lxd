using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using LXDClient.Models;

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

    #region HttpClient with Certificate and Accept All Server Certificate
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
    #endregion

    #region Certificates
    public async Task<Boolean> CertificatePublicPostAsync(String token)
    {
        var path = "/1.0/certificates?public";
        var request = new CertificatePublicRequestDto
        {
            TrustToken = token
        };
        var response = await PostAsync<CertificatePublicRequestDto, ResponseBase<Object>>(path, request);
        if (response?.StatusCode == 200)
        {
            return true;
        }
        return false;
    }
    #endregion

    #region Identities
    public async Task AuthIdentitiesOidcGetAsync()
    {
        var path = "/1.0/auth/identities/oidc";
        var response = await GetAsync<ResponseBase<Object>>(path);
    }
    #endregion

    #region Instances
    public async Task<String[]?> InstancesGetAsync()
    {
        var path = "/1.0/instances";
        var response = await GetAsync<ResponseBase<String[]>>(path);
        return response?.Metadata ?? null;
    }

    public async Task<InstanceDto?> InstancesGetAsync(String name)
    {
        var path = $"/1.0/instances/{name}";
        var response = await GetAsync<ResponseBase<InstanceDto>>(path);
        return response?.Metadata ?? null;
    }

    public async Task InstancesPostAsync(String project, InstancePostRequestDto request)
    {
        var path = $"/1.0/instances?project={project}";
        var response = await PostAsync<InstancePostRequestDto, AsyncResponseBase<AsyncOperationDto>>(path, request);
    }

    public async Task<AsyncResponseBase<AsyncOperationDto>?> InstancesDeleteAsync(String name, String? project = null)
    {
        var path = $"/1.0/instances/{name}";
        if (project != null)
        {
            path += $"?project={project}";
        }
        var response = await DeleteAsync<AsyncResponseBase<AsyncOperationDto>>(path);
        return response;
    }


    #endregion

    #region HTTP Methods
    private async Task<TOut?> GetAsync<TOut>(String path)
    {
        using (var response = await this.httpClient.GetAsync(path))
        {
            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(content);
                    return JsonSerializer.Deserialize<TOut>(content);
                }
                catch (Exception)
                {
                    Console.WriteLine("Deserialization failed");
                    return default!;
                }
            }
            else
            {
                Console.WriteLine(response.StatusCode);
                return default!;
            }
        }
    }

    private async Task<TOut?> PostAsync<TIn, TOut>(String path, TIn request)
    {
        using (var response = await this.httpClient.PostAsJsonAsync<TIn>(path, request))
        {
            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(content);
                    return JsonSerializer.Deserialize<TOut>(content);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Deserialization failed");
                    Console.WriteLine(ex.Message);                    
                    return default!;
                }
            }
            else
            {
                Console.WriteLine(response.StatusCode);
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);
                return default!;
            }
        }
    }

    private async Task<TOut?> DeleteAsync<TOut>(String path)
    {
        using (var response = await this.httpClient.DeleteAsync(path))
        {
            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(content);
                    return JsonSerializer.Deserialize<TOut>(content);
                }
                catch (Exception)
                {
                    Console.WriteLine("Deserialization failed");
                    return default!;
                }
            }
            else
            {
                Console.WriteLine(response.StatusCode);
                return default!;
            }
        }
    }



    #endregion
}
