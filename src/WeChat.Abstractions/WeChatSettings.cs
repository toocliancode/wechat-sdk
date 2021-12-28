namespace WeChat;

/// <summary>
/// 微信配置
/// </summary>
public class WeChatSettings : IWeChatSettings
{
    public WeChatSettings()
    {
    }

    public WeChatSettings(string appId, string secret)
    {
        AppId = appId;
        Secret = secret;
    }

    /// <summary>
    /// 微信应用号(公众平台AppId/开放平台AppId/小程序AppId/企业微信CorpId)
    /// </summary>
    public string AppId { get; set; }

    /// <summary>
    /// 微信应用密钥
    /// </summary>
    public string Secret { get; set; }
}
