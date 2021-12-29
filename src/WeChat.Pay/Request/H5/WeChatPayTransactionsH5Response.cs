
using System.Text.Json.Serialization;

namespace WeChat.Pay.H5;

/// <summary>
/// H5下单API 响应
/// https://pay.weixin.qq.com/wiki/doc/apiv3/wxpay/pay/transactions/chapter3_4.shtml
/// </summary>
public class WeChatPayTransactionsH5Response : WeChatResponseBase
{
    /// <summary>
    /// 支付跳转链接
    /// h5_url为拉起微信支付收银台的中间页面，可通过访问该url来拉起微信客户端，完成支付，h5_url的有效期为5分钟。
    /// 示例值：https://wx.tenpay.com/cgi-bin/mmpayweb-bin/checkmweb?prepay_id=wx2016121516420242444321ca0631331346&amp;package=1405458241
    /// </summary>
    [JsonPropertyName("h5_url")]
    public string H5Url { get; set; }
}
