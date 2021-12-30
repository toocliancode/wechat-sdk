namespace WeChat.Mp.Card;

public class UserGetCardModel
{
    /// <summary>
    /// 卡券Id
    /// </summary>
    [JsonPropertyName("card_id")]
    public string CardId { get; set; }

    /// <summary>
    /// 卡券code
    /// </summary>
    [JsonPropertyName("code")]
    public string Code { get; set; }
}
