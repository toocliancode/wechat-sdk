namespace WeChat.Mp.Card;

public class WeChatMpDataCubeGetMemberCardsInfoResponse
    : WeChatHttpResponse
{
    /// <summary>
    /// 指标信息
    /// </summary>
    [JsonPropertyName("list")]
    public List<DataCubeGetMemberCardsInfo> List { get; set; }
}
