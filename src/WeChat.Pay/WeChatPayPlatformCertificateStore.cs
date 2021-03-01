using Mediator;

using System.Collections.Concurrent;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using WeChat.Pay.Request;

namespace WeChat.Pay
{
    public class WeChatPayPlatformCertificateStore: IWeChatPayPlatformCertificateStore
    {
        private readonly ConcurrentDictionary<string, X509Certificate2> _certificates = new ConcurrentDictionary<string, X509Certificate2>();

        private readonly IMediator _mediator;

        public WeChatPayPlatformCertificateStore(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<X509Certificate2> GetAsync(string serialNo, WeChatPaySettings settings)
        {
            if(_certificates.TryGetValue(serialNo,out var certificate2))
            {
                return certificate2;
            }

            var request = new WeChatPayCertificatesRequest();
            request.Configure(settings);

            var response = await _mediator.Send(request);

            if (!response.IsSuccessed())
            {
                throw new WeChatPayException($"获取平台证书列表失败：Code={response.StatusCode}");
            }

            foreach (var certificate in response.Certificates)
            {
                if (_certificates.ContainsKey(certificate.SerialNo))
                {
                    continue;
                }
                switch (certificate.EncryptCertificate.Algorithm)
                {
                    case "AEAD_AES_256_GCM":
                        var certStr = CryptographyExtensions.AesGcmDecrypt(certificate.EncryptCertificate.Nonce, certificate.EncryptCertificate.Ciphertext, certificate.EncryptCertificate.AssociatedData, settings.V3Key);
                        var cert = new X509Certificate2(Encoding.UTF8.GetBytes(certStr));
                        _certificates.TryAdd(certificate.SerialNo, cert);
                        break;
                    default:
                        throw new WeChatPayException($"Unknown algorithm: {certificate.EncryptCertificate.Algorithm}");
                }
            }

            // 重新从缓存获取
            if (_certificates.TryGetValue(serialNo, out certificate2))
            {
                return certificate2;
            } 
            else
            {
                throw new WeChatPayException("Download certificates failed!");
            }
        }
    }
}
