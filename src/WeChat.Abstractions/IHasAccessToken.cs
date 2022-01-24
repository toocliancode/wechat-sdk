namespace WeChat;

/// <summary>
/// 需要 access_token
/// </summary>
public interface IHasAccessToken
{
    /// <summary>
    /// 微信API access_token,不设置则自动获取
    /// </summary>
    string? AccessToken { get; set; }
}
