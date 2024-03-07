using System.Collections.Concurrent;
using System.Security.Cryptography.X509Certificates;

namespace WeChat;

public class WeChatPayCertificateStore : IWeChatPayCertificateStore
{
    private readonly ConcurrentDictionary<string, X509Certificate2> _certificates = new();

    public bool TryGet(WeChatPayOptions options, out X509Certificate2? certificate2)
    {
        if (string.IsNullOrEmpty(options.Certificate) || string.IsNullOrEmpty(options.CertificatePassword))
        {
            throw new WeChatException($"{nameof(options.Certificate)} 或 {nameof(options.CertificatePassword)} 为空");
        }
        var key = WeChatSignature.MD5Encrypt(options.Certificate);
        if (_certificates.TryGetValue(key, out certificate2))
        {
            return true;
        }

        try
        {
            if (File.Exists(options.Certificate))
            {
                certificate2 = new X509Certificate2(options.Certificate, options.CertificatePassword);
            }
            else
            {
                certificate2 = new X509Certificate2(Convert.FromBase64String(options.Certificate), options.CertificatePassword);
            }
        }
        catch
        {
            //throw new CryptographicException("反序列化证书失败，请确认是否为微信支付签发的有效PKCS#12格式证书。");
            return false;
        }
        _certificates.TryAdd(key, certificate2);
        return true;
    }
}