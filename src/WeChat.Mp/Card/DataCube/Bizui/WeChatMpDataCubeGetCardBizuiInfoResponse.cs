namespace WeChat.Mp.Card;

public class WeChatMpDataCubeGetCardBizuiInfoResponse
    : WeChatHttpResponse
{
    /// <summary>
    /// 指标信息
    /// </summary>
    [JsonPropertyName("list")]
    public List<DataCubeGetCardBizuiInfo> List { get; set; }
}
