namespace WeChat.Applet.Checks;

public class WeChatAppletMediaCheckAsyncResponse
    : WeChatHttpResponse
{
    /// <summary>
    /// 唯一请求标识，标记单次请求，用于匹配异步推送结果
    /// </summary>
    [JsonPropertyName("trace_id")]
    public string TraceId { get; set; }
}
