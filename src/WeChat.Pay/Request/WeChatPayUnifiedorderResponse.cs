namespace WeChat.Pay;

public class WeChatPayUnifiedorderResponse : WeChatHttpResponseBase
{
    /// <summary>
    /// 预支付交易会话标识
    /// 预支付交易会话标识。用于后续接口调用中使用，该值有效期为2小时
    /// 示例值：wx201410272009395522657a690389285100
    /// </summary>
    [JsonPropertyName("prepay_id")]
    public string PrepayId { get; set; }

    /// <summary>
    /// 二维码链接
    /// 此URL用于生成支付二维码，然后提供给用户扫码支付。
    /// 注意：code_url并非固定值，使用时按照URL格式转成二维码即可。
    /// 示例值：weixin://wxpay/bizpayurl/up?pr=NwY5Mz9&amp;groupid=00
    /// </summary>
    [JsonPropertyName("code_url")]
    public string CodeUrl { get; set; }

    /// <summary>
    /// 支付跳转链接
    /// h5_url为拉起微信支付收银台的中间页面，可通过访问该url来拉起微信客户端，完成支付，h5_url的有效期为5分钟。
    /// 示例值：https://wx.tenpay.com/cgi-bin/mmpayweb-bin/checkmweb?prepay_id=wx2016121516420242444321ca0631331346&amp;package=1405458241
    /// </summary>
    [JsonPropertyName("h5_url")]
    public string H5Url { get; set; }
}
