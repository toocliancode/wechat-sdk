namespace WeChat.Mp.Card;

public class WeChatMpCardLandingPageResponse
    : WeChatHttpResponse
{
    /// <summary>
    /// 货架链接
    /// </summary>
    [JsonPropertyName("url")]
    public string Url { get; set; }

    /// <summary>
    /// 货架Id。货架的唯一标识
    /// </summary>
    [JsonPropertyName("page_id")]
    public string PageId { get; set; }
}
