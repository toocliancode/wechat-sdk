using Mediation.HttpClient;

using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace WeChat.Pay;

#pragma warning disable 8602,8604

public class WeChatPayAuthorizationHandler : IWeChatPayAuthorizationHandler
{
    private readonly IWeChatPayCertificateStore _certificateStore;

    public WeChatPayAuthorizationHandler(IWeChatPayCertificateStore certificateStore)
    {
        _certificateStore = certificateStore;
    }

    public async Task Handle(HttpRequestMessage message, WeChatPayOptions settings)
    {
        if (!_certificateStore.TryGet(settings, out var certificate))
        {
            throw new ArgumentException("证书获取失败");
        }
        var rsa = certificate.GetRSAPrivateKey();
        var serialNo = certificate.GetSerialNumberString();

        var method = message.Method.Method;
        var uri = message.RequestUri?.PathAndQuery;
        var timestamp = HttpUtility.GetTimeStamp();
        var nonce = HttpUtility.GenerateNonceStr();
        var body = method switch
        {
            "POST" or "PUT" or "PATCH" => await message.Content?.ReadAsStringAsync(),
            _ => ""
        };

        var data = Encoding.UTF8.GetBytes($"{method}\n{uri}\n{timestamp}\n{nonce}\n{body}\n");
        var signature = Convert.ToBase64String(rsa.SignData(data, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1));
        var token = $"mchid=\"{settings.MchId}\",nonce_str=\"{nonce}\",timestamp=\"{timestamp}\",serial_no=\"{serialNo}\",signature=\"{signature}\"";

        message.Headers.Authorization = new AuthenticationHeaderValue("WECHATPAY2-SHA256-RSA2048", token);
        message.Headers.UserAgent.Add(new ProductInfoHeaderValue(new ProductHeaderValue("Unknown")));
        message.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }
}
