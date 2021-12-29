
using System.Text.Json.Serialization;

using WeChat.Pay.Certificates;

namespace WeChat.Pay;

/// <summary>
/// 获取平台证书列表
/// https://wechatpay-api.gitbook.io/wechatpay-api-v3/jie-kou-wen-dang/ping-tai-zheng-shu
/// </summary>
public class WeChatPayCertificatesRequest : WeChatPayHttpRequest<WeChatPayCertificatesResponse>
{
    public static string Endpoint = "https://api.mch.weixin.qq.com/v3/certificates";

    [JsonIgnore]
    protected override bool SignatureCheck => false;

    protected override string GetRequestUri() => Endpoint;

    protected override Task<HttpContent?> GetContent() => Task.FromResult<HttpContent?>(null);
}
