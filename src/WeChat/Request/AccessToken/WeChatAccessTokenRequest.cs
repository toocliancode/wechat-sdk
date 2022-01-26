namespace WeChat.AccessToken;

/// <summary>
/// 微信 access_token 请求
/// 
/// https://developers.weixin.qq.com/doc/offiaccount/Basic_Information/Get_access_token.html
/// </summary>
public class WeChatAccessTokenRequest
    : WeChatHttpRequest<WeChatAccessTokenResponse>
    , IHasAppId
    , IHasSecret
{
    public static string Endpoint = "/cgi-bin/token?appId={appid}&secret={secret}&grant_type={grant_type}";

    /// <summary>
    /// 微信应用号
    /// </summary>
    public string? AppId { get; set; }

    /// <summary>
    /// 应用号密钥
    /// </summary>
    public string? Secret { get; set; }

    /// <summary>
    /// 授权类型。
    /// 默认值："client_credential"
    /// </summary>
    public string GrantType { get; set; } = "client_credential";

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatAccessTokenRequest"/>
    /// </summary>
    public WeChatAccessTokenRequest()
    {
    }

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatAccessTokenRequest"/>
    /// </summary>
    /// <param name="appId">应用号</param>
    /// <param name="secret">密钥</param>
    /// <param name="grantType">授权方式，默认值："client_credential"</param>
    public WeChatAccessTokenRequest(
        string appId,
        string secret,
        string grantType = "client_credential")
    {
        AppId = appId;
        Secret = secret;
        GrantType = grantType;
    }

    protected override string GetRequestUri()
        => $"{WeChatProperties.Domain}{Endpoint}"
            .Replace("{appid}", AppId)
            .Replace("{secret}", Secret)
            .Replace("{grant_type}", GrantType);
}
