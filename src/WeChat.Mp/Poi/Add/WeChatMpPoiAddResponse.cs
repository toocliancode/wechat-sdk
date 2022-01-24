namespace WeChat.Mp.Poi;

public class WeChatMpPoiAddResponse
    : WeChatHttpResponse
{
    /// <summary>
    /// 门店Id
    /// </summary>
    [JsonPropertyName("poi_id")]
    public long PoiId { get; set; }
}
