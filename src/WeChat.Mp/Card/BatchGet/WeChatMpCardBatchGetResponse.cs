namespace WeChat.Mp.Card;

public class WeChatMpCardBatchGetResponse
    : WeChatHttpResponse
{
    /// <summary>
    /// 卡券ID列表
    /// </summary>
    [JsonPropertyName("card_id_list")]
    public List<string> CardIds { get; set; }

    /// <summary>
    /// 该商户名下卡券ID总数
    /// </summary>
    [JsonPropertyName("total_num")]
    public int Total { get; set; }
}
