namespace WeChat.Mp.Poi;

public class WeChatMpPoiGetListResponse
    : WeChatHttpResponse
{
    [JsonPropertyName("business_list")]
    public List<PoiBaseInfo> Items { get; set; }

    /// <summary>
    /// 门店总数量
    /// </summary>
    [JsonPropertyName("total_count")]
    public string TotalCount { get; set; }
}
