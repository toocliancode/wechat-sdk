namespace WeChat.Mp.Card;

/// <summary>
/// 【卡券】获取免费券数据
/// <a href="https://developers.weixin.qq.com/doc/offiaccount/Cards_and_Offer/Managing_Coupons_Vouchers_and_Cards.html#11"></a>
/// </summary>
/// <remarks>
/// 支持开发者调用该接口拉取免费券（优惠券、团购券、折扣券、礼品券）在固定时间区间内的相关数据
/// </remarks>
public class WeChatMpDataCubeGetCardInfoRequest
    : WeChatHttpRequest<WeChatMpDataCubeGetCardInfoResponse>
    , IHasAccessToken
{
    public static string Endpoint = "/datacube/getcardcardinfo?access_token={access_token}";

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpDataCubeGetCardInfoRequest"/>
    /// </summary>
    public WeChatMpDataCubeGetCardInfoRequest()
        : base(HttpMethod.Post)
    {

    }

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpDataCubeGetCardInfoRequest"/>
    /// </summary>
    /// <param name="beginDate">查询数据的起始时间</param>
    /// <param name="endDate">查询数据的截至时间</param>
    /// <param name="condSource">卡券来源</param>
    /// <param name="cardId">卡券Id。填写后，指定拉出该卡券的相关数据</param>
    /// <param name="accessToken"></param>
    public WeChatMpDataCubeGetCardInfoRequest(
        string beginDate,
        string endDate,
        ushort condSource,
        string? cardId = default,
        string? accessToken = default)
        : base(HttpMethod.Post)
    {
        BeginDate = beginDate;
        EndDate = endDate;
        CondSource = condSource;
        CardId = cardId;
        AccessToken = accessToken;
    }

    [JsonIgnore]
    public string? AccessToken { get; set; }

    /// <summary>
    /// 查询数据的起始时间
    /// </summary>
    /// <value>
    /// 示例值："2015-06-15"
    /// </value>
    [JsonPropertyName("begin_date")]
    public string BeginDate { get; set; }

    /// <summary>
    /// 查询数据的截至时间
    /// </summary>
    /// <value>
    /// 示例值："2015-06-30"
    /// </value>
    [JsonPropertyName("end_date")]
    public string EndDate { get; set; }

    /// <summary>
    /// 卡券来源
    /// </summary>
    /// <value>
    /// 0：公众平台创建的卡券数据；
    /// 1：API创建的卡券数据；
    /// </value>
    [JsonPropertyName("cond_source")]
    public ushort CondSource { get; set; }

    /// <summary>
    /// 卡券Id。填写后，指定拉出该卡券的相关数据
    /// </summary>
    [JsonPropertyName("card_id")]
    public string? CardId { get; set; }

    protected override string GetRequestUri() => $"{WeChatProperties.Domain}{Endpoint}"
        .Replace("{access_token}", AccessToken);
}