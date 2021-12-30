namespace WeChat.Mp.Card;

public class WeChatMpCardMpNewsGetHtmlResponse
    : WeChatHttpResponse
{
    /// <summary>
    /// 返回一段html代码，可以直接嵌入到图文消息的正文里。
    /// 即可以把这段代码嵌入到[上传图文消息素材接口]中的content字段里
    /// </summary>
    [JsonPropertyName("cotent")]
    public string Content { get; set; }
}
