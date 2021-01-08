using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json.Serialization;

namespace WeChat.Applet.Request.Message
{
    /// <summary>
    /// 发送订阅消息 请求
    /// https://developers.weixin.qq.com/miniprogram/dev/api-backend/open-api/subscribe-message/subscribeMessage.send.html
    /// </summary>
    public class WeChatSubscribeMessageSendRequest : WeChatHttpRequestBase<WeChatResponse>, IEnableAccessToken
    {
        /// <summary>
        /// 实例化一个发送订阅消息 请求
        /// </summary>
        /// <param name="toUser">接收者（用户）的 openid</param>
        /// <param name="templateId">所需下发的订阅模板id</param>
        /// <param name="page">点击模板卡片后的跳转页面，仅限本小程序内的页面。支持带参数,（示例index?foo=bar）。该字段不填则模板无跳转。</param>
        /// <param name="data"> 模板内容，格式形如 { "key1": { "value": any }, "key2": { "value": any } }</param>
        /// <param name="miniProgramState">跳转小程序类型：developer为开发版；trial为体验版；formal为正式版；默认为正式版</param>
        /// <param name="lang">进入小程序查看”的语言类型，支持zh_CN(简体中文)、en_US(英文)、zh_HK(繁体中文)、zh_TW(繁体中文)，默认为zh_CN</param>
        public WeChatSubscribeMessageSendRequest(
            string toUser,
            string templateId,
            string page,
            IDictionary<string, IDictionary<string, string>> data,
            string miniProgramState = null,
            string lang = null)
        {
            ToUser = toUser;
            TemplateId = templateId;
            Page = page;
            Data = data;
            MiniProgramState = miniProgramState;
            Lang = lang;
        }

        protected override string GetEndpointName() => WeChatAppletEndpoints.SubscribeMessageSend;
        protected override HttpMethod GetHttpMethod() => HttpMethod.Post;

        /// <summary>
        /// 接收者（用户）的 openid
        /// </summary>
        [JsonPropertyName("touser")]
        public string ToUser { get; set; }

        /// <summary>
        /// 所需下发的订阅模板id
        /// </summary>
        [JsonPropertyName("template_id")]
        public string TemplateId { get; set; }

        /// <summary>
        /// 点击模板卡片后的跳转页面，仅限本小程序内的页面。支持带参数,（示例index?foo=bar）。该字段不填则模板无跳转。
        /// </summary>
        [JsonPropertyName("page")]
        public string Page { get; set; }

        /// <summary>
        /// 模板内容，格式形如 { "key1": { "value": any }, "key2": { "value": any } }
        /// </summary>
        [JsonPropertyName("data")]
        public IDictionary<string, IDictionary<string, string>> Data { get; set; }

        /// <summary>
        /// 跳转小程序类型：developer为开发版；trial为体验版；formal为正式版；默认为正式版
        /// </summary>
        [JsonPropertyName("miniprogram_state")]
        public string MiniProgramState { get; set; }

        /// <summary>
        /// 进入小程序查看”的语言类型，支持zh_CN(简体中文)、en_US(英文)、zh_HK(繁体中文)、zh_TW(繁体中文)，默认为zh_CN
        /// </summary>
        [JsonPropertyName("lang")]
        public string Lang { get; set; }

        protected override void ParameterHandler(WeChatConfiguration configuration)
        {
            Body
                .Set("touser", ToUser)
                .Set("template_id", TemplateId)
                .Set("page", Page)
                .Set("data", Data)
                .Set("miniprogram_state", MiniProgramState)
                .Set("lang", Lang);
        }
    }
}
