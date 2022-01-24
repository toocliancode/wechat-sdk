namespace WeChat.Mp.Card;

/// <summary>
/// 【卡券】拉取卡券概况数据
/// <a href="https://developers.weixin.qq.com/doc/offiaccount/Cards_and_Offer/Managing_Coupons_Vouchers_and_Cards.html#10"></a>
/// </summary>
/// <remarks>
/// 支持调用该接口拉取本商户的总体数据情况，包括时间区间内的各指标总量
/// </remarks>
public class WeChatMpDataCubeGetCardBizuiInfoRequest
    : WeChatHttpRequest<WeChatMpDataCubeGetCardBizuiInfoResponse>
    , IHasAccessToken
{
    public static string Endpoint = "/datacube/getcardbizuininfo?access_token={access_token}";

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpDataCubeGetCardBizuiInfoRequest"/>
    /// </summary>
    public WeChatMpDataCubeGetCardBizuiInfoRequest()
        : base(HttpMethod.Post)
    {

    }

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpDataCubeGetCardBizuiInfoRequest"/>
    /// </summary>
    /// <param name="beginDate">查询数据的起始时间</param>
    /// <param name="endDate">查询数据的截至时间</param>
    /// <param name="condSource">卡券来源</param>
    /// <param name="accessToken"></param>
    public WeChatMpDataCubeGetCardBizuiInfoRequest(
        string beginDate,
        string endDate,
        ushort condSource,
        string? accessToken = default)
        : base(HttpMethod.Post)
    {
        BeginDate = beginDate;
        EndDate = endDate;
        CondSource = condSource;
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

    protected override string GetRequestUri() => $"{WeChatProperties.Domain}{Endpoint}"
        .Replace("{access_token}", AccessToken);
}