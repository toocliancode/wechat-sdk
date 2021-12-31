namespace WeChat.Mp.Card;

public class WeChatMpDataCubeGetCardInfoResponse
    : WeChatHttpResponse
{
    /// <summary>
    /// 指标信息
    /// </summary>
    [JsonPropertyName("list")]
    public List<DataCubeGetCardInfo> List { get; set; }
}
