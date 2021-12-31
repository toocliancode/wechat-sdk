namespace WeChat.Mp.Card;

public class WeChatMpDataCubeGetMemberCardDetailResponse
    : WeChatHttpResponse
{
    /// <summary>
    /// 指标信息
    /// </summary>
    [JsonPropertyName("list")]
    public List<DataCubeGetMemberCardDetail> List { get; set; }
}
