using Mediation.HttpClient;

using System.Text.Json.Serialization;

namespace WeChat.Applet;

/// <summary>
/// 【微信小程序】小程序登录
/// 
/// <para>文档：<a href="https://developers.weixin.qq.com/miniprogram/dev/OpenApiDoc/user-login/code2Session.html"></a></para>
/// </summary>
public class Code2Session
{
    public static string Endpoint = "/sns/jscode2session?appid={appid}&secret={secret}&js_code={js_code}&grant_type=authorization_code";

    public class Response : WeChatAppletHttpResponse
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
        public string? UnionId { get; set; }
    }

    /// <param name="jsCode">登录时获取的 code，可通过wx.login获取</param>
    public class Request(string jsCode) : WeChatAppletHttpRequest<Response>
    {
        protected override Task InitializeRequestMessageAsync(IHttpRequestContext context)
        {
            var url = $"{WeChatAppletProperties.Domain}{Endpoint}"
                .Replace("{appid}", Options.AppId)
                .Replace("{secret}", Options.Secret)
                .Replace("{js_code}", jsCode);

            context.Message.Method = HttpMethod.Get;
            context.Message.RequestUri = new Uri(url);

            return Task.CompletedTask;
        }
    }

    /// <param name="jsCode">登录时获取的 code，可通过wx.login获取</param>
    public static Request ToRequest(string jsCode) => new(jsCode);
}
