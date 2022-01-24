namespace WeChat.Mp.Poi;

public class WeChatMpPoiCategoryResponse
    : WeChatHttpResponse
{
    [JsonPropertyName("category_list")]
    public List<string> Categories { get; set; }
}
