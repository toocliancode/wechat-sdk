namespace WeChat.Mp.Card;

/// <summary>
/// 【卡券】删除卡券
/// <a href="https://developers.weixin.qq.com/doc/offiaccount/Cards_and_Offer/Managing_Coupons_Vouchers_and_Cards.html#7"></a>
/// </summary>
/// <remarks>
/// 删除卡券接口允许商户删除任意一类卡券。
/// 删除卡券后，该卡券对应已生成的领取用二维码、添加到卡包JS API均会失效。
/// 
/// 注意：如用户在商家删除卡券前已领取一张或多张该卡券依旧有效。
/// 即删除卡券不能删除已被用户领取，保存在微信客户端中的卡券。
/// </remarks>
public class WeChatMpCardDeleteRequest
    : WeChatHttpRequest<WeChatHttpResponse>
    , IHasAccessToken
{
    public static string Endpoint = "/card/delete?access_token={access_token}";

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpCardDeleteRequest"/>
    /// </summary>
    public WeChatMpCardDeleteRequest()
        : base(HttpMethod.Post)
    {

    }

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpCardDeleteRequest"/>
    /// </summary>
    /// <param name="cardId">卡券Id</param>
    /// <param name="accessToken"></param>
    public WeChatMpCardDeleteRequest(
        string cardId,
        string? accessToken = default)
        : base(HttpMethod.Post)
    {
        AccessToken = accessToken;
        CardId = cardId;
    }

    [JsonIgnore]
    public string? AccessToken { get; set; }

    /// <summary>
    /// 卡券Id
    /// </summary>
    [JsonPropertyName("card_id")]
    public string CardId { get; set; }

    protected override string GetRequestUri() => $"{WeChatProperties.Domain}{Endpoint}"
        .Replace("{access_token}", AccessToken);
}