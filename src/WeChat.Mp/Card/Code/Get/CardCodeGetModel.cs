namespace WeChat.Mp.Card;

public class CardCodeGetModel
{
    /// <summary>
    /// 卡券Id
    /// </summary>
    [JsonPropertyName("card_id")]
    public string CardId { get; set; }

    /// <summary>
    /// 起始使用时间
    /// </summary>
    [JsonPropertyName("begin_time")]
    public ulong BeginTime { get; set; }

    /// <summary>
    /// 起始使用时间
    /// </summary>
    [JsonPropertyName("end_time")]
    public ulong EndTime { get; set; }
}
