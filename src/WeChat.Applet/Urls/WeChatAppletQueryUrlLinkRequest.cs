namespace WeChat.Applet.Urls;

/// <summary>
/// <b>[urllink.query]</b>
/// 查询小程序 url_link 配置，及长期有效 quota。
/// 
/// https://developers.weixin.qq.com/miniprogram/dev/api-backend/open-api/url-link/urllink.query.html
/// </summary>
public class WeChatAppletQueryUrlLinkRequest
    : WeChatHttpRequest<WeChatAppletQueryUrlLinkResponse>
    , IHasAccessToken
{
    public static string Endpoint = "/wxa/query_urllink?access_token={access_token}";

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatAppletQuerySchemeRequest"/>
    /// </summary>
    public WeChatAppletQueryUrlLinkRequest()
        : base(HttpMethod.Post)
    {

    }

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatAppletQueryUrlLinkRequest"/>
    /// </summary>
    /// <param name="accessToken">微信API access_token</param>
    /// <param name="urlLink">小程序 url_link</param>
    public WeChatAppletQueryUrlLinkRequest(
        string urlLink,
        string? accessToken = default)
        : this()
    {
        AccessToken = accessToken;
        UrlLink = urlLink;
    }

    /// <inheritdoc/>
    [JsonIgnore]
    public string? AccessToken { get; set; }

    /// <summary>
    /// 小程序 scheme 码
    /// </summary>
    [JsonPropertyName("url_link")]
    public string UrlLink { get; set; }

    protected override string GetRequestUri()
    {
        return $"{WeChatProperties.Domain}{Endpoint}"
        .Replace("{access_token}", AccessToken);
    }
}
