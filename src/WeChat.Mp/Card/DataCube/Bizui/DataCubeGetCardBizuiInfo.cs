namespace WeChat.Mp.Card;

/// <summary>
/// 指标信息
/// </summary>
public class DataCubeGetCardBizuiInfo
{
    /// <summary>
    /// 日期信息
    /// </summary>
    [JsonPropertyName("ref_date")]
    public string Date { get; set; }

    /// <summary>
    /// 浏览次数
    /// </summary>
    [JsonPropertyName("view_cnt")]
    public string ViewCount { get; set; }

    /// <summary>
    /// 浏览人数
    /// </summary>
    [JsonPropertyName("view_user")]
    public string ViewUser { get; set; }

    /// <summary>
    /// 领取次数
    /// </summary>
    [JsonPropertyName("receive_cnt")]
    public string ReceiveCount { get; set; }

    /// <summary>
    /// 领取人数
    /// </summary>
    [JsonPropertyName("receive_user")]
    public string ReceiveUser { get; set; }

    /// <summary>
    /// 使用次数
    /// </summary>
    [JsonPropertyName("verify_cnt")]
    public string VerifyCount { get; set; }

    /// <summary>
    /// 使用人数
    /// </summary>
    [JsonPropertyName("verify_user")]
    public string VerifyUser { get; set; }

    /// <summary>
    /// 转赠次数
    /// </summary>
    [JsonPropertyName("given_cnt")]
    public string GivenCount { get; set; }

    /// <summary>
    /// 转赠人数
    /// </summary>
    [JsonPropertyName("given_user")]
    public string GivenUser { get; set; }

    /// <summary>
    /// 过期次数
    /// </summary>
    [JsonPropertyName("expire_cnt")]
    public string ExpireCount { get; set; }

    /// <summary>
    /// 过期人数
    /// </summary>
    [JsonPropertyName("expire_user")]
    public string ExpireUser { get; set; }
}
