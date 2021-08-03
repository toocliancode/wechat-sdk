using System.Text.Json.Serialization;

namespace WeChat.Applet.Response
{
    /// <summary>
    /// 小程序 URL Link  响应
    /// </summary>
    public class WeChatAppletGenerateUrlLinkResponse
        : WeChatResponse
    {

        [JsonPropertyName("url_link")]
        public string UrlLink { get; set; }
    }
}
