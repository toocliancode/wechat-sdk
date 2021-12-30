namespace WeChat.Mp.Card;

/// <summary>
/// 【卡券】查询Code
/// <a href="https://developers.weixin.qq.com/doc/offiaccount/Cards_and_Offer/Redeeming_a_coupon_voucher_or_card.html#1"></a>
/// </summary>
/// <remarks>
/// 我们强烈建议开发者在调用核销code接口之前调用查询code接口，并在核销之前对非法状态的code(如转赠中、已删除、已核销等)做出处理
/// </remarks>
public class WeChatMpCardCodeGetRequest
    : WeChatHttpRequest<WeChatMpCardCodeGetResponse>
    , IHasAccessToken
{
    public static string Endpoint = "/card/code/get?access_token={access_token}";

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpCardCodeGetRequest"/>
    /// </summary>
    public WeChatMpCardCodeGetRequest()
        : base(HttpMethod.Post)
    {

    }

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpCardCodeGetRequest"/>
    /// </summary>
    /// <param name="code"> 单张卡券的唯一Code</param>
    /// <param name="cardId">
    /// 卡券ID代表一类卡券。
    /// 自定义code卡券必填。
    /// </param>
    /// <param name="checkConsume">是否校验code核销状态，填入true和false时的code异常状态返回数据不同。</param>
    /// <param name="accessToken"></param>
    public WeChatMpCardCodeGetRequest(
        string code,
        string? cardId = default,
        bool? checkConsume = default,
        string? accessToken = default)
        : base(HttpMethod.Post)
    {
        AccessToken = accessToken;
        Code = code;
        CardId = cardId;
        CheckConsume = checkConsume;
    }

    [JsonIgnore]
    public string? AccessToken { get; set; }

    /// <summary>
    /// 单张卡券的唯一Code
    /// </summary>
    [JsonPropertyName("code")]
    public string Code { get; set; }

    /// <summary>
    /// 卡券ID代表一类卡券。
    /// 自定义code卡券必填
    /// </summary>
    [JsonPropertyName("CardId")]
    public string? CardId { get; set; }

    /// <summary>
    /// 是否校验code核销状态，填入true和false时的code异常状态返回数据不同。
    /// </summary>
    [JsonPropertyName("check_consume")]
    public bool? CheckConsume { get; set; }

    protected override string GetRequestUri() => $"{WeChatProperties.Domain}{Endpoint}"
        .Replace("{access_token}", AccessToken);
}