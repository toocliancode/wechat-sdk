using Mediation.HttpClient;

using Microsoft.Extensions.DependencyInjection;

using System.Text.Json.Serialization;

namespace WeChat.Applet;

/// <summary>
/// 【微信小程序】重置登录态
/// 
/// <para>文档：<a href="https://developers.weixin.qq.com/miniprogram/dev/OpenApiDoc/user-login/ResetUserSessionKey.html"></a></para>
/// </summary>
public class ResetSession
{
    public static string Endpoint = "/wxa/resetusersessionkey?access_token={access_token}&signature={signature}&openid={openid}&sig_method=hmac_sha256";

    public class Response : WeChatAppletHttpResponse
    {
        /// <summary>
        /// 用户唯一标识符
        /// </summary>
        [JsonPropertyName("openid")]
        public string OpenId { get; set; }

        /// <summary>
        /// 重置后的用户登录态
        /// </summary>
        [JsonPropertyName("session_key")]
        public string SessionKey { get; set; }
    }

    /// <param name="openid">用户唯一标识符</param>
    /// <param name="sessionKey">用户登录态</param>
    public class Request(string openid, string sessionKey) : WeChatAppletHttpRequest<Response>
    {
        protected override async Task InitializeRequestMessageAsync(IHttpRequestContext context)
        {
            var token = await context.RequestServices.GetRequiredService<IWeChatAppletAccessTokenStore>().GetAsync();
            var dictionary = new SortedDictionary<string, string>()
            {
                {sessionKey,"" }
            };
            var signature = WeChatSignature.Sign(dictionary, WeChatSignType.HMAC_SHA256);

            var url = $"{WeChatAppletProperties.Domain}{Endpoint}"
                .Replace("{access_token}", token)
                .Replace("{openid}", openid)
                .Replace("{signature}", signature);

            context.Message.Method = HttpMethod.Get;
            context.Message.RequestUri = new Uri(url);
        }
    }

    /// <param name="openid">用户唯一标识符</param>
    /// <param name="sessionKey">用户登录态</param>
    public static Request ToRequest(string openid, string sessionKey) => new(openid, sessionKey);
}
