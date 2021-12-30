namespace WeChat.Mp.Card;

/// <summary>
/// 【卡券】获取用户已领取卡券
/// <a href="https://developers.weixin.qq.com/doc/offiaccount/Cards_and_Offer/Managing_Coupons_Vouchers_and_Cards.html#1"></a>
/// </summary>
/// <remarks>
/// 用于获取用户卡包里的，属于该appid下所有可用卡券，包括正常状态和异常状态。
/// </remarks>
public class WeChatMpCardUserGetCardListRequest
    : WeChatHttpRequest<WeChatMpCardUserGetCardListResponse>
    , IHasAccessToken
{
    public static string Endpoint = "/card/mpnews/gethtml?access_token={access_token}";

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpCardUserGetCardListRequest"/>
    /// </summary>
    public WeChatMpCardUserGetCardListRequest()
        : base(HttpMethod.Post)
    {

    }

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpCardUserGetCardListRequest"/>
    /// </summary>
    /// <param name="openId">需要查询的用户openid</param>
    /// <param name="cardId">
    /// 卡券ID。
    /// 不填写时默认查询当前appid下的卡券
    /// </param>
    /// <param name="accessToken"></param>
    public WeChatMpCardUserGetCardListRequest(
        string openId,
        string? cardId = default,
        string? accessToken = default)
        : this()
    {
        AccessToken = accessToken;
        OpenId = openId;
        CardId = cardId;
    }

    [JsonIgnore]
    public string? AccessToken { get; set; }

    /// <summary>
    /// 需要查询的用户openid
    /// </summary>
    [JsonPropertyName("openip")]
    public string OpenId { get; set; }

    /// <summary>
    /// 卡券ID。
    /// 不填写时默认查询当前appid下的卡券
    /// </summary>
    [JsonPropertyName("card_id")]
    public string? CardId { get; set; }

    protected override string GetRequestUri() => $"{WeChatProperties.Domain}{Endpoint}"
        .Replace("{access_token}", AccessToken);
}