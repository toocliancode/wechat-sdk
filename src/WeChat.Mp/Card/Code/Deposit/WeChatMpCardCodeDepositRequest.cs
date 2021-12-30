namespace WeChat.Mp.Card;

/// <summary>
/// 【卡券】导入code
/// <a href="https://developers.weixin.qq.com/doc/offiaccount/Cards_and_Offer/Distributing_Coupons_Vouchers_and_Cards.html#5"></a>
/// </summary>
/// <remarks>
/// 支持开发者调用该接口查询code导入微信后台成功的数目。
/// <para/>
/// 注：
/// <list type="number">
/// <item>单次调用接口传入code的数量上限为100个。</item>
/// <item>每一个 code 均不能为空串。</item>
/// <item>导入结束后系统会自动判断提供方设置库存与实际导入code的量是否一致。</item>
/// <item>导入失败支持重复导入，提示成功为止。</item>
/// </list>
/// </remarks>
public class WeChatMpCardCodeDepositRequest
    : WeChatHttpRequest<WeChatMpCardCodeDepositResponse>
    , IHasAccessToken
{
    public static string Endpoint = "/card/code/deposit?access_token={access_token}";

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpCardCodeDepositRequest"/>
    /// </summary>
    public WeChatMpCardCodeDepositRequest()
        : base(HttpMethod.Post)
    {
        Codes = new();
    }

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpCardCodeDepositRequest"/>
    /// </summary>
    /// <param name="cardId">需要进行导入code的卡券Id</param>
    /// <param name="codes"> 需导入微信卡券后台的自定义code，上限为100个</param>
    public WeChatMpCardCodeDepositRequest(
        string cardId,
        params string[] codes)
        : base(HttpMethod.Post)
    {
        CardId = cardId;
        Codes = new(codes);
    }

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpCardCodeDepositRequest"/>
    /// </summary>
    /// <param name="cardId">需要进行导入code的卡券Id</param>
    /// <param name="accessToken"></param>
    /// <param name="codes"> 需导入微信卡券后台的自定义code，上限为100个</param>
    public WeChatMpCardCodeDepositRequest(
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
    /// 需要进行导入code的卡券Id
    /// </summary>
    [JsonPropertyName("CardId")]
    public string CardId { get; set; }

    /// <summary>
    /// 需导入微信卡券后台的自定义code，上限为100个
    /// </summary>
    [JsonPropertyName("code")]
    public List<string> Codes { get; set; }

    protected override string GetRequestUri() => $"{WeChatProperties.Domain}{Endpoint}"
        .Replace("{access_token}", AccessToken);
}