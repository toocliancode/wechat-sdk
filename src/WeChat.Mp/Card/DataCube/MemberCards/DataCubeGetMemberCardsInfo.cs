namespace WeChat.Mp.Card;

/// <summary>
/// 指标信息
/// </summary>
public class DataCubeGetMemberCardsInfo
{
    /// <summary>
    /// 日期信息
    /// </summary>
    [JsonPropertyName("ref_date")]
    public int Date { get; set; }

    /// <summary>
    /// 浏览次数
    /// </summary>
    [JsonPropertyName("view_cnt")]
    public int ViewCount { get; set; }

    /// <summary>
    /// 浏览人数
    /// </summary>
    [JsonPropertyName("view_user")]
    public int ViewUser { get; set; }

    /// <summary>
    /// 领取次数
    /// </summary>
    [JsonPropertyName("receive_cnt")]
    public int ReceiveCount { get; set; }

    /// <summary>
    /// 领取人数
    /// </summary>
    [JsonPropertyName("receive_user")]
    public int ReceiveUser { get; set; }

    /// <summary>
    /// 使用次数
    /// </summary>
    [JsonPropertyName("verify_cnt")]
    public int VerifyCount { get; set; }

    /// <summary>
    /// 使用人数
    /// </summary>
    [JsonPropertyName("verify_user")]
    public int VerifyUser { get; set; }

    /// <summary>
    /// 激活人数
    /// </summary>
    [JsonPropertyName("active_user")]
    public int ActiveUser { get; set; }

    /// <summary>
    /// 有效会员总人数
    /// </summary>
    [JsonPropertyName("total_user")]
    public int TotalUser { get; set; }

    /// <summary>
    /// 历史领取会员卡总人数
    /// </summary>
    [JsonPropertyName("total_receive_user")]
    public int TotalReceiveUser { get; set; }
}
