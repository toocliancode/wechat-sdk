namespace WeChat.Applet.Urls;

/// <summary>
/// <b>[urlscheme.query]</b>
/// 查询小程序 scheme 码，及长期有效 quota。
/// 
/// https://developers.weixin.qq.com/miniprogram/dev/api-backend/open-api/url-scheme/urlscheme.query.html
/// </summary>
public class WeChatAppletQuerySchemeRequest
    : WeChatHttpRequest<WeChatAppletQuerySchemeResponse>
    , IHasAccessToken
{
    public static string Endpoint = "/wxa/queryscheme?access_token={access_token}";

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
        string scheme,
        string? accessToken = default)
        : this()
    {
        AccessToken = accessToken;
        Scheme = scheme;
    }

    /// <inheritdoc/>
    [JsonIgnore]
    public string? AccessToken { get; set; }

    /// <summary>
    /// 小程序 scheme 码
    /// </summary>
    [JsonPropertyName("scheme")]
    public string Scheme { get; set; }

    protected override string GetRequestUri()
    {
        return $"{WeChatProperties.Domain}{Endpoint}"
        .Replace("{access_token}", AccessToken);
    }
}