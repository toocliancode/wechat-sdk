namespace WeChat.Mp.Card;

public class WeChatMpCardCodeGetDepositCountResponse
    : WeChatHttpResponse
{
    /// <summary>
    /// 已经成功存入的code数目
    /// </summary>
    [JsonPropertyName("count")]
    public int Count { get; set; }
}
