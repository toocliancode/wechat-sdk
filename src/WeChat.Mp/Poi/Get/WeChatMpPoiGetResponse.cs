namespace WeChat.Mp.Poi;

public class WeChatMpPoiGetResponse
    : WeChatHttpResponse
{
    /// <summary>
    /// 门店信息
    /// </summary>
    [JsonPropertyName("business")]
    public PoiBusiness Business { get; set; }
}
