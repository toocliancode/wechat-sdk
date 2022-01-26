
using WeChat.Pay.Certificates;

namespace WeChat.Pay;

/// <summary>
/// 获取平台证书列表
/// https://wechatpay-api.gitbook.io/wechatpay-api-v3/jie-kou-wen-dang/ping-tai-zheng-shu
/// </summary>
public class WeChatPayCertificatesRequest : WeChatPayHttpRequest<WeChatPayCertificatesResponse>
{
    public static string Endpoint = "/v3/certificates";

    public WeChatPayCertificatesRequest()
    {
        Method = HttpMethod.Get;
    }

    [JsonIgnore]
    protected override bool SignatureCheck => false;

    protected override string GetRequestUri() => $"{WeChatPayProperties.Domain}{Endpoint}";

    protected override Task<HttpContent?> GetContent() => Task.FromResult<HttpContent?>(null);
}
