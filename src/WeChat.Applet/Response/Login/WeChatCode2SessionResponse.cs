using System.Text.Json.Serialization;

namespace WeChat.Applet.Response
{
    /// <summary>
    /// 登录凭证校验
    /// </summary>
    public class WeChatCode2SessionResponse : WeChatResponse
    {
        /// <summary>
        /// 用户唯一标识
        /// </summary>
        [JsonPropertyName("openid")]
        public string OpenId { get; set; }

        /// <summary>
        /// 会话密钥
        /// </summary>
        [JsonPropertyName("session_key")]
        public string SessionKey { get; set; }

        /// <summary>
        /// 用户在开放平台的唯一标识符，在满足 UnionID 下发条件的情况下会返回
        /// </summary>
        [JsonPropertyName("unionid")]
        public string UnionId { get; set; }
    }
}
