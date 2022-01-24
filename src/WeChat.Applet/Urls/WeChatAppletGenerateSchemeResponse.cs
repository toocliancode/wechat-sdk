namespace WeChat.Applet.Urls;

/// <summary>
/// 小程序 scheme 码 响应
/// </summary>
public class WeChatAppletGenerateSchemeResponse
    : WeChatHttpResponse
{
    [JsonPropertyName("openlink")]
    public string OpenLink { get; set; }
}
