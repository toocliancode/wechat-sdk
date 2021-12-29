using System.Text.Json.Serialization;

namespace WeChat.Mp.Card;

public class WeChatMpCardCreateResponse
    : WeChatResponse
{
    /// <summary>
    /// 卡券Id
    /// </summary>
    [JsonPropertyName("card_id")]
    public string CardId { get; set; }
}
