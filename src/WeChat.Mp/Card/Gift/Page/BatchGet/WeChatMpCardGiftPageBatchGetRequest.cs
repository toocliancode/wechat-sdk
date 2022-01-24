namespace WeChat.Mp.Card;

/// <summary>
/// 【卡券】 查询礼品卡货架列表
/// <a href="https://developers.weixin.qq.com/doc/offiaccount/Cards_and_Offer/gift_card.html#_7-5-%E6%9F%A5%E8%AF%A2-%E7%A4%BC%E5%93%81%E5%8D%A1%E8%B4%A7%E6%9E%B6%E5%88%97%E8%A1%A8%E6%8E%A5%E5%8F%A3"></a>
/// </summary>
/// <remarks>
/// 开发者可以通过该接口查询当前商户下所有的礼品卡货架id
/// </remarks>
public class WeChatMpCardGiftPageBatchGetRequest
    : WeChatHttpRequest<WeChatHttpResponse>
    , IHasAccessToken
{
    public static string Endpoint = "/card/giftcard/page/batchget?access_token={access_token}";

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpCardGiftPageBatchGetRequest"/>
    /// </summary>
    public WeChatMpCardGiftPageBatchGetRequest()
        : base(HttpMethod.Post)
    {
    }

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpCardGiftPageBatchGetRequest"/>
    /// </summary>
    /// <param name="accessToken"></param>
    public WeChatMpCardGiftPageBatchGetRequest(string? accessToken)
        : base(HttpMethod.Post)
    {
        AccessToken = accessToken;
    }

    [JsonIgnore]
    public string? AccessToken { get; set; }

    protected override string GetRequestUri() => $"{WeChatProperties.Domain}{Endpoint}"
        .Replace("{access_token}", AccessToken);

    protected override async Task<HttpContent?> GetContent()
    {
        await Task.CompletedTask;

        return new StringContent("{}");
    }
}