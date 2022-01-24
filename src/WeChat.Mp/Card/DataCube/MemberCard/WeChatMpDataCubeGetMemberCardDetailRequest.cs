namespace WeChat.Mp.Card;

/// <summary>
/// 【卡券】拉取单张会员卡数据
/// <a href="https://developers.weixin.qq.com/doc/offiaccount/Cards_and_Offer/Managing_Coupons_Vouchers_and_Cards.html#13"></a>
/// </summary>
/// <remarks>
/// 支持开发者调用该接口拉取API创建的会员卡数据情况
/// </remarks>
public class WeChatMpDataCubeGetMemberCardDetailRequest
    : WeChatHttpRequest<WeChatMpDataCubeGetMemberCardDetailResponse>
    , IHasAccessToken
{
    public static string Endpoint = "/datacube/getcardmembercarddetail?access_token={access_token}";

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpDataCubeGetMemberCardDetailRequest"/>
    /// </summary>
    public WeChatMpDataCubeGetMemberCardDetailRequest()
        : base(HttpMethod.Post)
    {

    }

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpDataCubeGetMemberCardDetailRequest"/>
    /// </summary>
    /// <param name="beginDate">查询数据的起始时间</param>
    /// <param name="endDate">查询数据的截至时间</param>
    /// <param name="cardId">卡券Id</param>
    /// <param name="accessToken"></param>
    public WeChatMpDataCubeGetMemberCardDetailRequest(
        string beginDate,
        string endDate,
        string cardId,
        string? accessToken = default)
        : base(HttpMethod.Post)
    {
        BeginDate = beginDate;
        EndDate = endDate;
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
    /// 卡券Id。填写后，指定拉出该卡券的相关数据
    /// </summary>
    [JsonPropertyName("card_id")]
    public string CardId { get; set; }

    protected override string GetRequestUri() => $"{WeChatProperties.Domain}{Endpoint}"
        .Replace("{access_token}", AccessToken);
}