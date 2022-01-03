namespace WeChat.Mp.Card;

public class WeChatMpCardGiftPageBatchGetResponse
    : WeChatHttpResponse
{
    /// <summary>
    /// 礼品卡货架id列表
    /// </summary>
    public List<string> PageIds { get; set; }
}
