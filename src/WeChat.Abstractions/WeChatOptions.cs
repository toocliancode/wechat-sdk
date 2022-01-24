namespace WeChat;

/// <summary>
/// 微信配置选项
/// </summary>
public class WeChatOptions
{
    /// <summary>
    /// 微信应用号(公众平台AppId/开放平台AppId/小程序AppId/企业微信CorpId)
    /// </summary>
    public string AppId { get; set; }

    /// <summary>
    /// 微信应用密钥
    /// </summary>
    public string Secret { get; set; }
}
