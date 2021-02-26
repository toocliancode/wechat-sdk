using System;
using System.Collections.Concurrent;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace WeChat.Pay
{
    public class WeChatPayCertificateStore : IWeChatPayCertificateStore
    {
        private readonly ConcurrentDictionary<string, X509Certificate2> _certificates = new ConcurrentDictionary<string, X509Certificate2>();
        public bool TryGet(WeChatPaySettings settings, out X509Certificate2 certificate2)
        {
            if (string.IsNullOrEmpty(settings.Certificate) || string.IsNullOrEmpty(settings.CertificatePassword))
            {
                throw new WeChatPayException($"{nameof(settings.Certificate)} 或 {nameof(settings.CertificatePassword)} 为空");
            }
            var key = settings.Certificate.MD5Encrypt();
            if (_certificates.TryGetValue(key, out certificate2))
            {
                return true; 
            }

            try
            {
                if (File.Exists(settings.Certificate))
                {
                    certificate2 = new X509Certificate2(settings.Certificate, settings.CertificatePassword);
                }
                else
                {
                    certificate2 = new X509Certificate2(Convert.FromBase64String(settings.Certificate), settings.CertificatePassword);
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
}
