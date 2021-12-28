using System.Text.Json.Serialization;

namespace WeChat.Applet.Urls;

/// <summary>
/// 小程序 scheme 码 响应
/// </summary>
public class WeChatAppletGenerateSchemeResponse
    : WeChatResponse
{
    [JsonPropertyName("openlink")]
    public string OpenLink { get; set; }
}
