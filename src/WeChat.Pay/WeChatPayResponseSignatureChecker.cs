using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.Extensions.Logging;

using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Security.Cryptography;
using System;

namespace WeChat.Pay
{
    public class WeChatPayResponseSignatureChecker : IWeChatPayResponseSignatureChecker
    {
        private readonly ILogger<WeChatPayResponseSignatureChecker> _logger;
        private readonly IWeChatPayPlatformCertificateStore _certificateStore;

        public WeChatPayResponseSignatureChecker(
            ILogger<WeChatPayResponseSignatureChecker> logger,
            IWeChatPayPlatformCertificateStore certificateStore)
        {
            _logger = logger;
            _certificateStore = certificateStore;
        }

        public async Task Check(HttpResponseMessage message, WeChatPaySettings settings)
        {
            try
            {
                if (!message.Headers.TryGetValues("Wechatpay-Serial", out var serialValues))
                {
                    _logger.LogError("响应签名检查：Wechatpay-Serial 为空");
                    throw new WeChatPayException("响应签名检查：Wechatpay-Serial 为空");
                }
                if (!message.Headers.TryGetValues("Wechatpay-Timestamp", out var timestampValues))
                {
                    _logger.LogError("响应签名检查：Wechatpay-Timestamp 为空");
                    throw new WeChatPayException("响应签名检查：Wechatpay-Timestamp 为空");
                }
                if (!message.Headers.TryGetValues("Wechatpay-Nonce", out var nonceValues))
                {
                    _logger.LogError("响应签名检查：Wechatpay-Nonce 为空");
                    throw new WeChatPayException("响应签名检查：Wechatpay-Nonce 为空");
                }
                if (!message.Headers.TryGetValues("Wechatpay-Signature", out var signatureValues))
                {
                    _logger.LogError("响应签名检查：Wechatpay-Signature 为空");
                    throw new WeChatPayException("响应签名检查：Wechatpay-Signature 为空");
                }
                var body = await message.Content.ReadAsStringAsync();
                var serialNo = serialValues.First();
                var timestamp = timestampValues.First();
                var nonce = nonceValues.First();
                var signature = signatureValues.First();

                var certificate2 = await _certificateStore.GetAsync(serialNo, settings);
                var signatureSourceData = $"{timestamp}\n{nonce}\n{body}\n";

                var rsa = certificate2.GetRSAPublicKey();
                if (!rsa.VerifyData(Encoding.UTF8.GetBytes(signatureSourceData), Convert.FromBase64String(signature), HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1))
                {
                    _logger.LogError("响应签名检查：检查不通过");
                    throw new WeChatPayException("响应签名检查：检查不通过");
                }
            }
            catch(Exception ex)
            {
                _logger.LogError("响应签名检查：检查异常");
                throw new WeChatPayException("响应签名检查：检查异常", ex);
            }
        }
    }
}
