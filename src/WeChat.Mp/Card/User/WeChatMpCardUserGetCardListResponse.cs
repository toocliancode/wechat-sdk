namespace WeChat.Mp.Card;

public class WeChatMpCardUserGetCardListResponse
    : WeChatHttpResponse
{
    /// <summary>
    /// 卡券列表
    /// </summary>
    [JsonPropertyName("card_list")]
    public UserGetCardModel Cards { get; set; }

    /// <summary>
    /// 是否有可用的朋友的券
    /// </summary>
    [JsonPropertyName("has_share_card")]
    public bool HasShareCard { get; set; }
}
