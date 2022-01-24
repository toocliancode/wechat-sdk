namespace WeChat.Mp.Card;

/// <summary>
/// 【卡券】修改库存
/// <a href="https://developers.weixin.qq.com/doc/offiaccount/Cards_and_Offer/Managing_Coupons_Vouchers_and_Cards.html#5"></a>
/// </summary>
/// <remarks>
/// 调用修改库存接口增减某张卡券的库存
/// </remarks>
public class WeChatMpCardModifyStockRequest
    : WeChatHttpRequest<WeChatHttpResponse>
    , IHasAccessToken
{
    public static string Endpoint = "/card/modifystock?access_token={access_token}";

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpCardModifyStockRequest"/>
    /// </summary>
    public WeChatMpCardModifyStockRequest()
        : base(HttpMethod.Post)
    {

    }

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpCardModifyStockRequest"/>
    /// </summary>
    /// <param name="cardId">卡券Id</param>
    /// <param name="increaseStockValue">增加多少库存，支持不填或填0</param>
    /// <param name="reduceStockValue">减少多少库存，可以不填或填0。</param>
    /// <param name="accessToken"></param>
    public WeChatMpCardModifyStockRequest(
        string cardId,
        int? increaseStockValue = default,
        int? reduceStockValue = default,
        string? accessToken = default)
        : base(HttpMethod.Post)
    {
        AccessToken = accessToken;
        CardId = cardId;
        IncreaseStockValue = increaseStockValue;
        ReduceStockValue = reduceStockValue;
    }

    [JsonIgnore]
    public string? AccessToken { get; set; }

    /// <summary>
    /// 卡券Id
    /// </summary>
    [JsonPropertyName("card_id")]
    public string CardId { get; set; }

    /// <summary>
    /// 增加多少库存，支持不填或填0
    /// </summary>
    [JsonPropertyName("increase_stock_value")]
    public int? IncreaseStockValue { get; set; }

    /// <summary>
    /// 减少多少库存，可以不填或填0。
    /// </summary>
    [JsonPropertyName("reduce_stock_value")]
    public int? ReduceStockValue { get; set; }

    protected override string GetRequestUri() => $"{WeChatProperties.Domain}{Endpoint}"
        .Replace("{access_token}", AccessToken);
}