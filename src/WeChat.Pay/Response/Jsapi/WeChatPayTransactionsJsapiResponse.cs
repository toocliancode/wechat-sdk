using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.Json.Serialization;

namespace WeChat.Pay.Response.Jsapi
{
    /// <summary>
    /// JSAPI 统一下单API
    /// </summary>
    public class WeChatPayTransactionsJsapiResponse:WeChatResponseBase
    {
        /// <summary>
        /// 预支付交易会话标识
        /// </summary>
        [JsonPropertyName("prepay_id")]
        public string PrepayId { get; set; }
    }
}
