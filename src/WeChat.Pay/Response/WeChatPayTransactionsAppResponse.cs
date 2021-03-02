
using System.Text.Json.Serialization;

namespace WeChat.Pay.Response
{
    /// <summary>
    /// APP下单API 响应
    /// https://pay.weixin.qq.com/wiki/doc/apiv3/wxpay/pay/transactions/chapter3_1.shtml
    /// </summary>
    public class WeChatPayTransactionsAppResponse : WeChatResponseBase
    {
        /// <summary>
        /// 预支付交易会话标识
        /// </summary>
        [JsonPropertyName("prepay_id")]
        public string PrepayId { get; set; }
    }
}
