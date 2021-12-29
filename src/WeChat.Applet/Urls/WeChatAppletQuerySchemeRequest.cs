using System.Text.Json.Serialization;

namespace WeChat.Applet.Urls;

/// <summary>
/// <b>[urlscheme.query]</b>
/// 查询小程序 scheme 码，及长期有效 quota。
/// 
/// https://developers.weixin.qq.com/miniprogram/dev/api-backend/open-api/url-scheme/urlscheme.query.html
/// </summary>
public class WeChatAppletQuerySchemeRequest
    : WeChatHttpRequest<WeChatAppletQuerySchemeResponse>
{
    public static string Endpoint = "https://api.weixin.qq.com/wxa/queryscheme";

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatAppletQuerySchemeRequest"/>
    /// </summary>
    public WeChatAppletQuerySchemeRequest()
        : base(HttpMethod.Post)
    {

    }

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatAppletQuerySchemeRequest"/>
    /// </summary>
    /// <param name="accessToken">微信API access_token</param>
    /// <param name="scheme">小程序 scheme 码</param>
    public WeChatAppletQuerySchemeRequest(
        string accessToken,
        string scheme)
        : this()
    {
        AccessToken = accessToken;
        Scheme = scheme;
    }

    /// <summary>
    /// 微信API access_token
    /// </summary>
    [JsonIgnore]
    public string AccessToken { get; set; }

    /// <summary>
    /// 小程序 scheme 码
    /// </summary>
    [JsonPropertyName("scheme")]
    public string Scheme { get; set; }

    protected override string GetRequestUri()
    {
        return $"{Endpoint}?access_token={AccessToken}";
    }
}