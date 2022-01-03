namespace WeChat.Mp.Card;

/// <summary>
/// 【卡券】下架礼品卡货架
/// <a href="https://developers.weixin.qq.com/doc/offiaccount/Cards_and_Offer/gift_card.html#_7-6-%E4%B8%8B%E6%9E%B6-%E7%A4%BC%E5%93%81%E5%8D%A1%E8%B4%A7%E6%9E%B6%E6%8E%A5%E5%8F%A3"></a>
/// </summary>
/// <remarks>
/// 开发者可以通过该接口查询当前商户下所有的礼品卡货架id
/// </remarks>
public class WeChatMpCardMaintainSetRequest
    : WeChatHttpRequest<WeChatMpCardMaintainSetResponse>
    , IHasAccessToken
{
    public static string Endpoint = "/card/giftcard/maintain/set?access_token={access_token}";

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpCardMaintainSetRequest"/>
    /// </summary>
    public WeChatMpCardMaintainSetRequest()
        : base(HttpMethod.Post)
    {

    }

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpCardMaintainSetRequest"/>
    /// </summary>
    /// <param name="pageId">需要下架的page_id,设置单个时需要指定</param>
    /// <param name="all">
    /// 将该商户下所有的货架设置为下架
    /// 
    /// <code>
    /// {
    ///     "all": true,
    ///     "maintain": true
    /// }
    /// </code>
    /// </param>
    /// <param name="maintain">
    /// 将某个货架设置为下架
    /// 
    /// <code>
    /// {
    ///     "page_id": "abcedfghifk=+Uasdaseq14fadkf8123h4jk",
    ///     "maintain": true
    /// }
    /// </code>
    /// </param>
    /// <param name="accessToken"></param>
    public WeChatMpCardMaintainSetRequest(
        string? pageId = default,
        bool? all = default,
        bool? maintain = default,
        string? accessToken = default)
        : base(HttpMethod.Post)
    {
        AccessToken = accessToken;
        PageId = pageId;
        All = all;
        Maintain = maintain;
    }

    [JsonIgnore]
    public string? AccessToken { get; set; }

    /// <summary>
    /// 需要下架的page_id,设置单个时需要指定
    /// </summary>
    [JsonPropertyName("pagg_id")]
    public string? PageId { get; set; }

    /// <summary>
    /// 将该商户下所有的货架设置为下架
    /// 
    /// <code>
    /// {
    ///     "all": true,
    ///     "maintain": true
    /// }
    /// </code>
    /// </summary>
    [JsonPropertyName("all")]
    public bool? All { get; set; }

    /// <summary>
    /// 将某个货架设置为下架
    /// 
    /// <code>
    /// {
    ///     "page_id": "abcedfghifk=+Uasdaseq14fadkf8123h4jk",
    ///     "maintain": true
    /// }
    /// </code>
    /// </summary>
    [JsonPropertyName("maintain")]
    public bool? Maintain { get; set; }

    protected override string GetRequestUri() => $"{WeChatProperties.Domain}{Endpoint}"
        .Replace("{access_token}", AccessToken);
}