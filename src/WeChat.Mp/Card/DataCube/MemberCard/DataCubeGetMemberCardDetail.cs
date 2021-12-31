namespace WeChat.Mp.Card;

/// <summary>
/// 指标信息
/// </summary>
public class DataCubeGetMemberCardDetail
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

    /// <summary>
    /// 新用户数
    /// </summary>
    [JsonPropertyName("new_user")]
    public int NewUser { get; set; }

    /// <summary>
    /// 应收金额（仅限使用快速买单的会员卡），单位分
    /// </summary>
    [JsonPropertyName("payOriginalFee")]
    public long PayOriginalFee { get; set; }

    /// <summary>
    /// 实收金额（仅限使用快速买单的会员卡），单位分
    /// </summary>
    [JsonPropertyName("fee")]
    public long Fee { get; set; }

    /// <summary>
    /// 商户类型
    /// </summary>
    [JsonPropertyName("merchanttype")]
    public int MerchantType { get; set; }

    /// <summary>
    /// 子商户ID
    /// </summary>
    [JsonPropertyName("submerchantid")]
    public int SubMerchantId { get; set; }
}
