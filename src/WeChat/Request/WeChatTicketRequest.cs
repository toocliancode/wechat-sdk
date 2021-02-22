
using System;
using System.Text.Json.Serialization;

using WeChat.Response;

namespace WeChat.Request
{
    /// <summary>
    /// 微信 ticket 请求
    /// 
    /// https://developers.weixin.qq.com/doc/offiaccount/WeChat_Invoice/Nontax_Bill/API_list.html#2.1%20%E8%8E%B7%E5%8F%96ticket
    /// </summary>
    public class WeChatTicketRequest : WeChatHttpRequestBase<WeChatTicketResponse>, IEnableAccessToken
    {

        /// <summary>
        /// 实例化一个新的 微信ticket请求
        /// </summary>
        /// <param name="type">凭证类型： jsapi、wx_card</param>
        public WeChatTicketRequest(string type= "jsapi")
        {
            Type = type;
        }

        /// <summary>
        /// 凭证类型： jsapi、wx_card
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; } = "jsapi";

        protected override string EndpointName => WeChatEndpoints.Ticket;
    }
}
