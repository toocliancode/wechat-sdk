
using System;
using System.Text.Json.Serialization;

using WeChat.Response;

namespace WeChat.Request
{
    /// <summary>
    /// 微信 ticket 请求
    /// </summary>
    public class WeChatTicketRequest : WeChatHttpRequestBase<WeChatTicketResponse>, IEnableAccessToken
    {
        /// <summary>
        /// 实例化一个新的 微信ticket请求
        /// </summary>
        /// <param name="type">凭证类型： jsapi、wx_card</param>
        public WeChatTicketRequest(string type)
        {
            Type = type;
        }

        /// <summary>
        /// 实例化一个新的 微信ticket请求
        /// </summary>
        /// <param name="configurationFactory"></param>
        public WeChatTicketRequest(Func<IServiceProvider, string, WeChatConfiguration> configurationFactory) : base(configurationFactory)
        {
        }

        /// <summary>
        /// 实例化一个新的 微信ticket请求
        /// </summary>
        /// <param name="configurationFactory"></param>
        /// <param name="type">凭证类型： jsapi、wx_card</param>
        public WeChatTicketRequest(Func<IServiceProvider, string, WeChatConfiguration> configurationFactory,string type) : base(configurationFactory)
        {
            Type = type;
        }

        protected override string GetEndpointName() => WeChatEndpoints.Ticket;

        /// <summary>
        /// 凭证类型： jsapi、wx_card
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; } = "jsapi";

        protected override void ParameterHandler(WeChatConfiguration configuration)
        {
            Body.Set("type", Type); 
        }
    }
}
