//using Mediator.HttpClient;

//using Microsoft.Extensions.Options;

//using System.Security.Cryptography;

//namespace WeChat;

//public class WeChatPayDelegatingHandler : DelegatingHandler
//{
//    private readonly IOptions<WeChatOptions> _options;
//    private readonly string _name;

//    public WeChatPayDelegatingHandler(IOptions<WeChatOptions> options, string name)
//    {
//        _options = options;
//        _name = name;
//    }

//    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
//    {
//        var settings = _options.Value.GetConfiguration(_name).Get<WeChatPayOptions>();
//        var auth = await BuildAuthAsync(request, settings);
//        request.Headers.Add("Authorization", $"WECHATPAY2-SHA256-RSA2048 {auth}");
//        return await base.SendAsync(request, cancellationToken);
//    }

//    protected async Task<string> BuildAuthAsync(HttpRequestMessage request, WeChatPayOptions settings)
//    {
//        string method = request.Method.ToString();
//        string body = "";
//        if (method == "POST" || method == "PUT" || method == "PATCH")
//        {
//            var content = request.Content;
//            body = await content.ReadAsStringAsync();
//        }

//        string uri = request.RequestUri.PathAndQuery;
//        var timestamp = HttpUtility.GetTimeStamp();
//        string nonce = HttpUtility.GenerateNonceStr();

//        string message = $"{method}\n{uri}\n{timestamp}\n{nonce}\n{body}\n";
//        string signature = Sign(settings.CertificateRSAPrivateKey, message);
//        return $"mchid=\"{settings.MchId}\",nonce_str=\"{nonce}\",timestamp=\"{timestamp}\",serial_no=\"{settings.CertificateSerialNo}\",signature=\"{signature}\"";
//    }

//    protected static string Sign(RSA rsa, string message)
//    {
//        // NOTE： 私钥不包括私钥文件起始的-----BEGIN PRIVATE KEY-----
//        //        亦不包括结尾的-----END PRIVATE KEY-----
//        byte[] data = System.Text.Encoding.UTF8.GetBytes(message);
//        return Convert.ToBase64String(rsa.SignData(data, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1));
//    }
//}
