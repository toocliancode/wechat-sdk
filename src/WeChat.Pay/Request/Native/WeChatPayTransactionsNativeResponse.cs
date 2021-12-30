namespace WeChat.Pay.Native;

/// <summary>
/// Native下单API 响应
/// https://pay.weixin.qq.com/wiki/doc/apiv3/wxpay/pay/transactions/chapter3_3.shtml
/// </summary>
public class WeChatPayTransactionsNativeResponse : WeChatHttpResponseBase
{
    /// <summary>
    /// 二维码链接
    /// 此URL用于生成支付二维码，然后提供给用户扫码支付。
    /// 注意：code_url并非固定值，使用时按照URL格式转成二维码即可。
    /// 示例值：weixin://wxpay/bizpayurl/up?pr=NwY5Mz9&amp;groupid=00
    /// </summary>
    [JsonPropertyName("code_url")]
    public string CodeUrl { get; set; }
}
