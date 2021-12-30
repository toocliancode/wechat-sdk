namespace WeChat.Mp.Message;

public class WeChatMpTemplateSendResponse : WeChatHttpResponse
{
    /// <summary>
    /// 消息Id
    /// </summary>
    [JsonPropertyName("msgid")]
    public long MsgId { get; set; }
}
