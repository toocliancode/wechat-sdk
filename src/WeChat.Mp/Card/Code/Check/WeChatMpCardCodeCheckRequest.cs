namespace WeChat.Mp.Card;

/// <summary>
/// 【卡券】核查code
/// <a href="https://developers.weixin.qq.com/doc/offiaccount/Cards_and_Offer/Distributing_Coupons_Vouchers_and_Cards.html#5"></a>
/// </summary>
/// <remarks>
/// 为了避免出现导入差错，强烈建议开发者在查询完code数目的时候核查code接口校验code导入微信后台的情况
/// </remarks>
public class WeChatMpCardCodeCheckRequest
    : WeChatHttpRequest<WeChatMpCardCodeCheckResponse>
    , IHasAccessToken
{

    public static string Endpoint = "/card/code/checkcode?access_token={access_token}";

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpCardCodeCheckRequest"/>
    /// </summary>
    public WeChatMpCardCodeCheckRequest()
        : base(HttpMethod.Post)
    {
        Codes = new();
    }

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpCardCodeCheckRequest"/>
    /// </summary>
    /// <param name="cardId">卡券Id</param>
    /// <param name="codes">核查code</param>
    public WeChatMpCardCodeCheckRequest(
        string cardId,
        params string[] codes)
        : base(HttpMethod.Post)
    {
        CardId = cardId;
        Codes = new(codes);
    }

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpCardCodeCheckRequest"/>
    /// </summary>
    /// <param name="cardId">卡券Id</param>
    /// <param name="accessToken"></param>
    /// <param name="codes">核查code</param>
    public WeChatMpCardCodeCheckRequest(
        string cardId,
        string accessToken,
        params string[] codes)
        : base(HttpMethod.Post)
    {
        AccessToken = accessToken;
        CardId = cardId;
        Codes = new(codes);
    }

    [JsonIgnore]
    public string? AccessToken { get; set; }

    /// <summary>
    /// 卡券Id
    /// </summary>
    [JsonPropertyName("CardId")]
    public string CardId { get; set; }

    /// <summary>
    /// 核查code
    /// </summary>
    [JsonPropertyName("code")]
    public List<string> Codes { get; set; }

    protected override string GetRequestUri() => $"{WeChatProperties.Domain}{Endpoint}"
        .Replace("{access_token}", AccessToken);
}