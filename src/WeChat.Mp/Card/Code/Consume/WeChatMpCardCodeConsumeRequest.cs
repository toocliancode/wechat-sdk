namespace WeChat.Mp.Card;

/// <summary>
/// 【卡券】核销Code
/// <a href="https://developers.weixin.qq.com/doc/offiaccount/Cards_and_Offer/Redeeming_a_coupon_voucher_or_card.html#2"></a>
/// </summary>
/// <remarks>
/// 消耗code接口是核销卡券的唯一接口,开发者可以调用当前接口将用户的优惠券进行核销，该过程不可逆
/// </remarks>
public class WeChatMpCardCodeConsumeRequest
    : WeChatHttpRequest<WeChatMpCardCodeConsumeResponse>
    , IHasAccessToken
{
    public static string Endpoint = "/card/code/consume?access_token={access_token}";

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpCardCodeConsumeRequest"/>
    /// </summary>
    public WeChatMpCardCodeConsumeRequest()
        : base(HttpMethod.Post)
    {

    }

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpCardCodeConsumeRequest"/>
    /// </summary>
    /// <param name="code">需核销的Code</param>
    /// <param name="cardId">
    /// 卡券ID。
    /// 创建卡券时use_custom_code填写true时必填。
    /// 非自定义Code不必填写。
    /// </param>
    /// <param name="accessToken"></param>
    public WeChatMpCardCodeConsumeRequest(
        string code,
        string? cardId = default,
        string? accessToken = default)
        : base(HttpMethod.Post)
    {
        AccessToken = accessToken;
        Code = code;
        CardId = cardId;
    }

    [JsonIgnore]
    public string? AccessToken { get; set; }

    /// <summary>
    /// 需核销的Code
    /// </summary>
    [JsonPropertyName("code")]
    public string Code { get; set; }

    /// <summary>
    /// 卡券ID。
    /// 创建卡券时use_custom_code填写true时必填。
    /// 非自定义Code不必填写。
    /// </summary>
    [JsonPropertyName("CardId")]
    public string? CardId { get; set; }

    protected override string GetRequestUri() => $"{WeChatProperties.Domain}{Endpoint}"
        .Replace("{access_token}", AccessToken);
}