using System.Security.Cryptography.X509Certificates;

namespace WeChat;

public interface IWeChatPayPlatformCertificateStore
{
    Task<X509Certificate2> GetAsync(string serialNo, WeChatPayOptions options);
}
