using System.Text.Json.Serialization;

using WeChat.Pay.Domain;

namespace WeChat.Pay.Certificates;

/// <summary>
/// 获取平台证书列表
/// https://wechatpay-api.gitbook.io/wechatpay-api-v3/jie-kou-wen-dang/ping-tai-zheng-shu
/// </summary>
public class WeChatPayCertificatesResponse : WeChatResponseBase
{
    [JsonPropertyName("data")]
    public List<Certificate> Certificates { get; set; }
}
