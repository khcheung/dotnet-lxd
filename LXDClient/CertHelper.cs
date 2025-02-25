using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace LXDClient;

public class CertHelper
{
    private readonly string certFolder;
    public X509Certificate2 Certificate { get; private set; } = null!;

    public CertHelper(String certFolder)
    {
        this.certFolder = certFolder;
    }

    public void LoadCert(String certName)
    {
        var keyFile = Path.Combine(certFolder, $"{certName.ToLower()}.key");
        var certFile = Path.Combine(certFolder, $"{certName.ToLower()}.crt");
        if (File.Exists(keyFile) && File.Exists(certFile))
        {
            try
            {
                var cert = X509Certificate2.CreateFromPemFile(certFile, keyFile);
                this.Certificate = cert;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    public async Task<Boolean> GenerateCert(string certName, Boolean forceOverwrite = false)
    {
        var keyFile = Path.Combine(certFolder, $"{certName.ToLower()}.key");
        var certFile = Path.Combine(certFolder, $"{certName.ToLower()}.crt");

        if ((File.Exists(keyFile) || File.Exists(certFile)) && forceOverwrite == false)
        {
            return false;
        }

        if (forceOverwrite)
        {
            if (File.Exists(keyFile))
            {
                File.Delete(keyFile);
            }

            if (File.Exists(certFile))
            {
                File.Delete(certFile);
            }
        }


        var rsa = RSA.Create();
        var rsaKey = rsa.ExportRSAPrivateKeyPem();
        using (var file = File.Create(keyFile))
        {
            using (var sw = new StreamWriter(file))
            {
                await sw.WriteAsync(rsaKey);
                await sw.FlushAsync();
                sw.Close();
            }
            file.Close();
        }

        var req = new CertificateRequest($"cn={certName}", rsa, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
        req.CertificateExtensions.Add(new X509KeyUsageExtension(X509KeyUsageFlags.DigitalSignature | X509KeyUsageFlags.KeyEncipherment, true));
        req.CertificateExtensions.Add(new X509EnhancedKeyUsageExtension(new OidCollection()
        {
            new Oid("1.3.6.1.5.5.7.3.2")
        }, false));
        req.CertificateExtensions.Add(new X509BasicConstraintsExtension(false, false, 0, true));
        var cert = req.CreateSelfSigned(DateTimeOffset.Now, DateTimeOffset.Now.AddDays(365));
        var certPem = cert.ExportCertificatePem();
        using (var file = File.Create(certFile))
        {
            using (var sw = new StreamWriter(file))
            {
                await sw.WriteAsync(certPem);
                await sw.FlushAsync();
                sw.Close();
            }
            file.Close();
        }
        //cert = X509Certificate2.CreateFromPem(cc.AsSpan(), ck.AsSpan());
        this.Certificate = cert;
        return true;
    }
}

