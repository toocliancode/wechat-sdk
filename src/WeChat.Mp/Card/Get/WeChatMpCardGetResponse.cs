namespace WeChat.Mp.Card;

public class WeChatMpCardGetResponse
    : WeChatHttpResponse
{
    /// <summary>
    /// 卡券信息
    /// </summary>
    [JsonPropertyName("card")]
    public CardInfo Card { get; set; }
}
