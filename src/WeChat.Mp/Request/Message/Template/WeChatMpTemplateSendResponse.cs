using System.Text.Json.Serialization;

namespace WeChat.Mp.Message;

public class WeChatMpTemplateSendResponse : WeChatResponse
{
    /// <summary>
    /// 消息Id
    /// </summary>
    [JsonPropertyName("msgid")]
    public long MsgId { get; set; }
}
