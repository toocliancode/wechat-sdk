using Microsoft.Extensions.Logging;

using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace WeChat;

public class WeChatPayResponseSignatureChecker(
    ILogger<WeChatPayResponseSignatureChecker> logger,
    IWeChatPayPlatformCertificateStore certificateStore) : IWeChatPayResponseSignatureChecker
{
    public async Task Check(HttpResponseMessage message, WeChatPayOptions settings)
    {
        try
        {
            if (!message.Headers.TryGetValues("WeChatPay-Serial", out var serialValues))
            {
                logger.LogError("响应签名检查：WeChatPay-Serial 为空");
                throw new WeChatException("响应签名检查：WeChatPay-Serial 为空");
            }
            if (!message.Headers.TryGetValues("WeChatPay-Timestamp", out var timestampValues))
            {
                logger.LogError("响应签名检查：WeChatPay-Timestamp 为空");
                throw new WeChatException("响应签名检查：WeChatPay-Timestamp 为空");
            }
            if (!message.Headers.TryGetValues("WeChatPay-Nonce", out var nonceValues))
            {
                logger.LogError("响应签名检查：WeChatPay-Nonce 为空");
                throw new WeChatException("响应签名检查：WeChatPay-Nonce 为空");
            }
            if (!message.Headers.TryGetValues("WeChatPay-Signature", out var signatureValues))
            {
                logger.LogError("响应签名检查：WeChatPay-Signature 为空");
                throw new WeChatException("响应签名检查：WeChatPay-Signature 为空");
            }
            var body = await message.Content.ReadAsStringAsync();
            var serialNo = serialValues.First();
            var timestamp = timestampValues.First();
            var nonce = nonceValues.First();
            var signature = signatureValues.First();

            var certificate2 = await certificateStore.GetAsync(serialNo, settings);
            var signatureSourceData = $"{timestamp}\n{nonce}\n{body}\n";

            var rsa = certificate2.GetRSAPublicKey();
            if (!rsa.VerifyData(Encoding.UTF8.GetBytes(signatureSourceData), Convert.FromBase64String(signature), HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1))
            {
                logger.LogError("响应签名检查：检查不通过");
                throw new WeChatException("响应签名检查：检查不通过");
            }
        }
        catch (Exception ex)
        {
            logger.LogError("响应签名检查：检查异常");
            throw new WeChatException("响应签名检查：检查异常", ex);
        }
    }
}
