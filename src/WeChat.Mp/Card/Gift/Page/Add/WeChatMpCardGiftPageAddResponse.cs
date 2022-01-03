namespace WeChat.Mp.Card;

public class WeChatMpCardGiftPageAddResponse
    : WeChatHttpResponse
{
    /// <summary>
    /// 货架的id，用于查询货架详情以及获得货架访问链接
    /// </summary>
    [JsonPropertyName("page_id")]
    public string PageId { get; set; }
}
