namespace WeChat.Mp.Card;

/// <summary>
/// 【卡券】批量查询卡券Id
/// <a href="https://developers.weixin.qq.com/doc/offiaccount/Cards_and_Offer/Managing_Coupons_Vouchers_and_Cards.html#3"></a>
/// </summary>
public class WeChatMpCardBatchGetRequest
    : WeChatHttpRequest<WeChatMpCardBatchGetResponse>
    , IHasAccessToken
{
    public static string Endpoint = "/card/get?access_token={access_token}";

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpCardBatchGetRequest"/>
    /// </summary>
    public WeChatMpCardBatchGetRequest()
        : base(HttpMethod.Post)
    {

    }

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpCardBatchGetRequest"/>
    /// </summary>
    /// <param name="offset">查询卡列表的起始偏移量，从0开始，即offset: 5是指从从列表里的第六个开始读取</param>
    /// <param name="count">需要查询的卡片的数量（数量最大50）</param>
    /// <param name="accessToken"></param>
    /// <param name="status">支持开发者拉出指定状态的卡券列表（<see cref="CardStatus"/>）</param>
    public WeChatMpCardBatchGetRequest(
        int offset,
        int count,
        string? accessToken = default,
        params string[] status)
        : base(HttpMethod.Post)
    {
        Offset = offset;
        Count = count;
        AccessToken = accessToken;
        Status = new(status);
    }

    [JsonIgnore]
    public string? AccessToken { get; set; }

    /// <summary>
    /// 查询卡列表的起始偏移量，从0开始，即offset: 5是指从从列表里的第六个开始读取
    /// </summary>
    [JsonPropertyName("offset")]
    public int Offset { get; set; }

    /// <summary>
    /// 需要查询的卡片的数量（数量最大50）
    /// </summary>
    [JsonPropertyName("count")]
    public int Count { get; set; }

    /// <summary>
    /// 支持开发者拉出指定状态的卡券列表（<see cref="CardStatus"/>）
    /// </summary>
    /// <value>
    /// CARD_STATUS_NOT_VERIFY：待审核；
    /// CARD_STATUS_VERIFY_FAIL：审核失败;
    /// CARD_STATUS_VERIFY_OK：通过审核；
    /// CARD_STATUS_DELETE：卡券被商户删除；
    /// CARD_STATUS_DISPATCH：在公众平台投放过的卡券
    /// </value>
    [JsonPropertyName("status_list")]
    public List<string>? Status { get; set; }

    protected override string GetRequestUri() => $"{WeChatProperties.Domain}{Endpoint}"
        .Replace("{access_token}", AccessToken);
}