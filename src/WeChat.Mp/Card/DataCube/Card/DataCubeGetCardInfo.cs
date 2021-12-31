namespace WeChat.Mp.Card;

/// <summary>
/// 指标信息
/// </summary>
public class DataCubeGetCardInfo
{
    /// <summary>
    /// 卡券ID
    /// </summary>
    [JsonPropertyName("卡券Id")]
    public int CardId { get; set; }

    /// <summary>
    /// 卡券类型（<see cref="CardTypes"/>）0：折扣券， 1：代金券，2：礼品券，3：优惠券，4：团购券
    /// </summary>
    /// <remarks>
    /// 暂不支持拉取特殊票券类型数据，电影票、飞机票、会议门票、景区门票
    /// </remarks>
    [JsonPropertyName("card_type")]
    public int CardType2 { get; set; }

    /// <summary>
    /// 卡券类型（<see cref="CardTypes"/>）
    /// </summary>
    public string CardType => CardType2 switch
    {
        0 => CardTypes.DISCOUNT,
        1 => CardTypes.CASH,
        2 => CardTypes.GIFT,
        3 => CardTypes.GENERAL_COUPON,
        4 => CardTypes.GROUPON,
        _ => string.Empty
    };

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
    /// 转赠次数
    /// </summary>
    [JsonPropertyName("given_cnt")]
    public int GivenCount { get; set; }

    /// <summary>
    /// 转赠人数
    /// </summary>
    [JsonPropertyName("given_user")]
    public int GivenUser { get; set; }

    /// <summary>
    /// 过期次数
    /// </summary>
    [JsonPropertyName("expire_cnt")]
    public int ExpireCount { get; set; }

    /// <summary>
    /// 过期人数
    /// </summary>
    [JsonPropertyName("expire_user")]
    public int ExpireUser { get; set; }
}
