using System.Security.Cryptography.X509Certificates;

namespace WeChat.Pay;

public interface IWeChatPayCertificateStore
{
    bool TryGet(WeChatPayOptions options, out X509Certificate2? certificate2);
}
