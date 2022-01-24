namespace WeChat.Applet.Urls;

/// <summary>
/// 小程序 URL Link  响应
/// </summary>
public class WeChatAppletGenerateUrlLinkResponse
    : WeChatHttpResponse
{

    [JsonPropertyName("url_link")]
    public string UrlLink { get; set; }
}
