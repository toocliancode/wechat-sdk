using Mediation.HttpClient;

using System.Text.Json.Serialization;

namespace WeChat.Mp;

/// <summary>
/// 【微信公众号】 access_token 请求
/// 
/// <para>文档：<a href="https://developers.weixin.qq.com/doc/offiaccount/Basic_Information/Get_access_token.html"></a></para>
/// </summary>
public class AccessToken
{
    public static string Endpoint = "/cgi-bin/token?appId={appid}&secret={secret}&grant_type=client_credential";

    /// <summary>
    /// 响应
    /// </summary>
    public class Response : WeChatMpHttpResponse
    {
        /// <summary>
        /// 获取到的凭证
        /// </summary>
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// 凭证有效时间，单位：秒
        /// </summary>
        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; set; }
    }

    /// <summary>
    /// 请求
    /// </summary>
    /// <param name="appId">应用号</param>
    /// <param name="secret">应用号密钥</param>
    public class Request(string appId, string secret) : WeChatHttpRequest<Response>
    {
        protected override Task InitializeRequestMessageAsync(IHttpRequestContext context)
        {
            context.Message.Method = HttpMethod.Get;
            context.Message.RequestUri = new Uri(
                $"{WeChatMpProperties.Domain}{Endpoint}"
                .Replace("{appid}", appId)
                .Replace("{secret}", secret));

            return Task.CompletedTask;
        }
    }
}
