
using WeChat.Response;

namespace WeChat.Request
{
    /// <summary>
    /// 微信 ticket 请求
    /// </summary>
    public class WeChatTicketRequest : WeChatHttpRequestBase<WeChatTicketResponse>, IEnableAccessToken
    {
        protected override string GetEndpointName() => WeChatEndpoints.Ticket;

        /// <summary>
        /// 凭证类型： jsapi、wx_card
        /// </summary>
        public string Type { get; set; } = "jsapi";

        protected override void ParameterHandler(WeChatConfiguration configuration)
        {
            Body.Set("type", Type);
        }
    }
}
