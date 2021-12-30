namespace WeChat.Mp.Card;

/// <summary>
/// 【卡券】查询导入code数目
/// <a href="https://developers.weixin.qq.com/doc/offiaccount/Cards_and_Offer/Distributing_Coupons_Vouchers_and_Cards.html#5"></a>
/// </summary>
/// <remarks>
/// 支持开发者调用该接口查询code导入微信后台成功的数目
/// </remarks>
public class WeChatMpCardCodeGetDepositCountRequest
    : WeChatHttpRequest<WeChatMpCardCodeGetDepositCountResponse>
    , IHasAccessToken
{
    public static string Endpoint = "/card/code/getdepositcount?access_token={access_token}";

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpCardCodeGetDepositCountRequest"/>
    /// </summary>
    public WeChatMpCardCodeGetDepositCountRequest()
        : base(HttpMethod.Post)
    {
    }

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpCardCodeGetDepositCountRequest"/>
    /// </summary>
    /// <param name="cardId">卡券Id</param>
    public WeChatMpCardCodeGetDepositCountRequest(string cardId)
        : base(HttpMethod.Post)
    {
        CardId = cardId;
    }

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpCardCodeGetDepositCountRequest"/>
    /// </summary>
    /// <param name="cardId">卡券Id</param>
    /// <param name="accessToken"></param>
    public WeChatMpCardCodeGetDepositCountRequest(
        string cardId,
        string accessToken)
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
    [JsonPropertyName("CardId")]
    public string CardId { get; set; }

    protected override string GetRequestUri() => $"{WeChatProperties.Domain}{Endpoint}"
        .Replace("{access_token}", AccessToken);
}