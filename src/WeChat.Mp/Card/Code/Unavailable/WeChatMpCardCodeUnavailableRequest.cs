namespace WeChat.Mp.Card;

/// <summary>
/// 【卡券】设置卡券失效
/// <a href="https://developers.weixin.qq.com/doc/offiaccount/Cards_and_Offer/Managing_Coupons_Vouchers_and_Cards.html#8"></a>
/// </summary>
/// <remarks>
/// 为满足改票、退款等异常情况，可调用卡券失效接口将用户的卡券设置为失效状态
/// </remarks>
public class WeChatMpCardCodeUnavailableRequest
    : WeChatHttpRequest<WeChatHttpResponse>
    , IHasAccessToken
{
    public static string Endpoint = "/card/code/unavailable?access_token={access_token}";

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpCardCodeUnavailableRequest"/>
    /// </summary>
    public WeChatMpCardCodeUnavailableRequest()
        : base(HttpMethod.Post)
    {

    }

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpCardCodeUnavailableRequest"/>
    /// </summary>
    /// <param name="cardId">卡券ID</param>
    /// <param name="code">设置失效的Code</param>
    /// <param name="reason">失效理由</param>
    /// <param name="accessToken"></param>
    public WeChatMpCardCodeUnavailableRequest(
        string cardId,
        string code,
        string? reason = default,
        string? accessToken = default)
        : base(HttpMethod.Post)
    {
        AccessToken = accessToken;
        Code = code;
        Reason = reason;
        CardId = cardId;
    }

    [JsonIgnore]
    public string? AccessToken { get; set; }

    /// <summary>
    /// 卡券ID
    /// </summary>
    [JsonPropertyName("CardId")]
    public string CardId { get; set; }

    /// <summary>
    /// 设置失效的Code
    /// </summary>
    [JsonPropertyName("code")]
    public string Code { get; set; }

    /// <summary>
    /// 失效理由
    /// </summary>
    /// <value>
    /// 示例值："失效理由"
    /// </value>
    [JsonPropertyName("reason")]
    public string? Reason { get; set; }


    protected override string GetRequestUri() => $"{WeChatProperties.Domain}{Endpoint}"
        .Replace("{access_token}", AccessToken);
}