namespace WeChat.Mp.Card;

/// <summary>
/// 【卡券】更改Code
/// <a href="https://developers.weixin.qq.com/doc/offiaccount/Cards_and_Offer/Managing_Coupons_Vouchers_and_Cards.html#6"></a>
/// </summary>
/// <remarks>
/// 为确保转赠后的安全性，微信允许自定义Code的商户对已下发的code进行更改。 
/// 注：为避免用户疑惑，建议仅在发生转赠行为后（发生转赠后，微信会通过事件推送的方式告知商户被转赠的卡券Code）对用户的Code进行更改。
/// </remarks>
public class WeChatMpCardCodeUpdateRequest
    : WeChatHttpRequest<WeChatHttpResponse>
    , IHasAccessToken
{
    public static string Endpoint = "/card/code/update?access_token={access_token}";

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpCardCodeUpdateRequest"/>
    /// </summary>
    public WeChatMpCardCodeUpdateRequest()
        : base(HttpMethod.Post)
    {

    }

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpCardCodeUpdateRequest"/>
    /// </summary>
    /// <param name="code">需变更的Code</param>
    /// <param name="newCode">变更后的有效Code</param>
    /// <param name="cardId">
    /// 卡券ID代表一类卡券。
    /// 自定义code卡券必填
    /// </param>
    /// <param name="accessToken"></param>
    public WeChatMpCardCodeUpdateRequest(
        string code,
        string newCode,
        string? cardId = default,
        string? accessToken = default)
        : base(HttpMethod.Post)
    {
        AccessToken = accessToken;
        Code = code;
        NewCode = newCode;
        CardId = cardId;
    }

    [JsonIgnore]
    public string? AccessToken { get; set; }

    /// <summary>
    /// 需变更的Code
    /// </summary>
    [JsonPropertyName("code")]
    public string Code { get; set; }

    /// <summary>
    /// 变更后的有效Code
    /// </summary>
    [JsonPropertyName("new_code")]
    public string NewCode { get; set; }

    /// <summary>
    /// 卡券ID代表一类卡券。
    /// 自定义code卡券必填
    /// </summary>
    [JsonPropertyName("CardId")]
    public string? CardId { get; set; }

    protected override string GetRequestUri() => $"{WeChatProperties.Domain}{Endpoint}"
        .Replace("{access_token}", AccessToken);
}