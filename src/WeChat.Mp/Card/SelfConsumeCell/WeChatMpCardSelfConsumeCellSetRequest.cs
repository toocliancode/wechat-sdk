namespace WeChat.Mp.Card;

/// <summary>
/// 【卡券】设置自助核销
/// <a href="https://developers.weixin.qq.com/doc/offiaccount/Cards_and_Offer/Create_a_Coupon_Voucher_or_Card.html#14"></a>
/// </summary>
public class WeChatMpCardSelfConsumeCellSetRequest
    : WeChatHttpRequest<WeChatHttpResponse>
{
    public static string Endpoint = "/card/paycell/set?access_token={access_token}";

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpCardSelfConsumeCellSetRequest"/>
    /// </summary>
    public WeChatMpCardSelfConsumeCellSetRequest()
        : base(HttpMethod.Post)
    {

    }

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpCardSelfConsumeCellSetRequest"/>
    /// </summary>
    /// <param name="cardId">卡券Id</param>
    /// <param name="isOpen">是否开启自助核销功能，填true/false，默认为false</param>
    /// <param name="needVerifyCod">用户核销时是否需要输入验证码， 填true/false， 默认为false</param>
    /// <param name="needRemarkAmount">用户核销时是否需要备注核销金额， 填true/false， 默认为false</param>
    /// <param name="accessToken"></param>
    public WeChatMpCardSelfConsumeCellSetRequest(
        string cardId,
        bool? isOpen = default,
        bool? needVerifyCod = default,
        bool? needRemarkAmount = default,
        string? accessToken = default)
        : this()
    {
        AccessToken = accessToken;
        CardId = cardId;
        IsOpen = isOpen;
        NeedVerifyCod = needVerifyCod;
        NeedRemarkAmount = needRemarkAmount;
    }

    /// <inheritdoc/>
    [JsonIgnore]
    public string? AccessToken { get; set; }

    /// <summary>
    /// 卡券Id
    /// </summary>
    [JsonPropertyName("card_id")]
    public string CardId { get; set; }

    /// <summary>
    /// 是否开启自助核销功能，填true/false，默认为false
    /// </summary>
    [JsonPropertyName("is_open")]
    public bool? IsOpen { get; set; }

    /// <summary>
    /// 用户核销时是否需要输入验证码， 填true/false， 默认为false
    /// </summary>
    [JsonPropertyName("need_verify_cod")]
    public bool? NeedVerifyCod { get; set; }

    /// <summary>
    /// 用户核销时是否需要备注核销金额， 填true/false， 默认为false
    /// </summary>
    [JsonPropertyName("need_remark_amount")]
    public bool? NeedRemarkAmount { get; set; }

    protected override string GetRequestUri() => $"{WeChatProperties.Domain}{Endpoint}"
        .Replace("{access_token}", AccessToken);
}