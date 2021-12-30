namespace WeChat.Mp.Card;

public class WeChatMpCardCreateResponse
    : WeChatHttpResponse
{
    /// <summary>
    /// 卡券Id
    /// </summary>
    [JsonPropertyName("card_id")]
    public string CardId { get; set; }
}
