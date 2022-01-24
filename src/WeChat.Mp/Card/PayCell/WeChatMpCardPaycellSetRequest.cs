namespace WeChat.Mp.Card;

/// <summary>
/// 【卡券】卡券设置买单
/// <a href="https://developers.weixin.qq.com/doc/offiaccount/Cards_and_Offer/Create_a_Coupon_Voucher_or_Card.html#12"></a>
/// </summary>
public class WeChatMpCardPayCellSetRequest
    : WeChatHttpRequest<WeChatHttpResponse>
    , IHasAccessToken
{
    public static string Endpoint = "/card/paycell/set?access_token={access_token}";

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpCardPayCellSetRequest"/>
    /// </summary>
    public WeChatMpCardPayCellSetRequest()
        : base(HttpMethod.Post)
    {

    }

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpCardPayCellSetRequest"/>
    /// </summary>
    /// <param name="cardId">卡券Id</param>
    /// <param name="isOpen">是否开启买单功能，填true/false</param>
    /// <param name="accessToken"></param>
    public WeChatMpCardPayCellSetRequest(string cardId, bool isOpen, string? accessToken = default)
        : this()
    {
        AccessToken = accessToken;
        CardId = cardId;
        IsOpen = isOpen;
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
    /// 是否开启买单功能，填true/false
    /// </summary>
    [JsonPropertyName("is_open")]
    public bool IsOpen { get; set; }

    protected override string GetRequestUri() => $"{WeChatProperties.Domain}{Endpoint}"
        .Replace("{access_token}", AccessToken);
}