
using System.Text.Json.Serialization;

namespace WeChat.Pay.Jsapi;

/// <summary>
/// JSAPI 统一下单API 响应
/// https://pay.weixin.qq.com/wiki/doc/apiv3/wxpay/pay/transactions/chapter3_2.shtml
/// </summary>
public class WeChatPayTransactionsJsapiResponse : WeChatResponseBase
{
    /// <summary>
    /// 预支付交易会话标识
    /// </summary>
    [JsonPropertyName("prepay_id")]
    public string PrepayId { get; set; }
}
