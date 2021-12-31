namespace WeChat.Mp.Card;

/// <summary>
/// 【卡券】获取卡券详情
/// <a href="https://developers.weixin.qq.com/doc/offiaccount/Cards_and_Offer/Managing_Coupons_Vouchers_and_Cards.html#2"></a>
/// </summary>
/// <remarks>
/// 开发者可以调用该接口查询某个card_id的创建信息、审核状态以及库存数量
/// </remarks>
public class WeChatMpCardGetRequest
    : WeChatHttpRequest<WeChatMpCardGetResponse>
    , IHasAccessToken
{
    public static string Endpoint = "/card/get?access_token={access_token}";

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpCardGetRequest"/>
    /// </summary>
    public WeChatMpCardGetRequest()
        : base(HttpMethod.Post)
    {

    }

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpCardGetRequest"/>
    /// </summary>
    /// <param name="cardId">卡券Id</param>
    /// <param name="accessToken"></param>
    public WeChatMpCardGetRequest(
        string cardId,
        string? accessToken = default)
        : base(HttpMethod.Post)
    {
        CardId = cardId;
        AccessToken = accessToken;
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