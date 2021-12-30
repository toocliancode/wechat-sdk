namespace WeChat.AccessToken;

/// <summary>
/// 响应 access_token 请求
/// </summary>
public class WeChatAccessTokenResponse : WeChatHttpResponse
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