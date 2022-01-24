namespace WeChat.Ticket;

public class WeChatTicketResponse : WeChatHttpResponse
{
    /// <summary>
    /// 获取到的凭证
    /// </summary>
    [JsonPropertyName("ticket")]
    public string Ticket { get; set; }

    /// <summary>
    /// 凭证有效时间，单位：秒
    /// </summary>
    [JsonPropertyName("expires_in")]
    public int ExpiresIn { get; set; }
}
