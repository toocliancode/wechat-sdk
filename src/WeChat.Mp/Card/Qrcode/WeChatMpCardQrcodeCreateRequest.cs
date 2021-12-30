namespace WeChat.Mp.Card;

/// <summary>
/// 【卡券】创建二维码
/// <a href="https://developers.weixin.qq.com/doc/offiaccount/Cards_and_Offer/Distributing_Coupons_Vouchers_and_Cards.html#0"></a>
/// </summary>
/// <remarks>
/// 开发者可调用该接口生成一张卡券二维码供用户扫码后添加卡券到卡包。
/// 自定义Code码的卡券调用接口时，POST数据中需指定code，非自定义code不需指定，指定openid同理。
/// 指定后的二维码只能被用户扫描领取一次
/// </remarks>
public class WeChatMpCardQrcodeCreateRequest
    : WeChatHttpRequest<WeChatMpCardQrcodeCreateResponse>
    , IHasAccessToken
{
    public static string Endpoint = "/card/qrcode/create?access_token={access_token}";

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpCardQrcodeCreateRequest"/>
    /// </summary>
    public WeChatMpCardQrcodeCreateRequest()
        : base(HttpMethod.Post)
    {
        Cards = new();
    }

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpCardQrcodeCreateRequest"/>
    /// </summary>
    /// <param name="openId">
    /// （指定后，统一设置 <see cref="Cards"/>[].OpenId）指定领取者的openid，只有该用户能领取。
    /// bind_openid字段为true的卡券必须填写，非指定openid不必填写
    /// </param>
    /// <param name="accessToken"></param>
    /// <param name="cards">
    /// 扫描二维码领取的卡券。
    /// 如果只有一组，则生成领取单张卡券的二维码。
    /// 如果有多组，则生成领取多张卡券的二维码
    /// </param>
    public WeChatMpCardQrcodeCreateRequest(
        string? openId = default,
        string? accessToken = default,
        params WeChatMpCardQrcodeCreateModel[] cards)
        : base(HttpMethod.Post)
    {
        OpenId = openId;
        AccessToken = accessToken;
        Cards = new();

        Cards.AddRange(cards);
    }

    [JsonIgnore]
    public string? AccessToken { get; set; }

    /// <summary>
    /// 指定二维码的有效时间，范围是60 ~ 1800秒。
    /// 不填默认为365天有效
    /// </summary>
    [JsonPropertyName("expire_seconds")]
    public uint? ExpireSeconds { get; set; }

    /// <summary>
    /// （指定后，统一设置 <see cref="Cards"/>[].OpenId）指定领取者的openid，只有该用户能领取。
    /// bind_openid字段为true的卡券必须填写，非指定openid不必填写
    /// </summary>
    /// <value>
    /// 示例值："oXch-jkrxp42VQu8ldweCwDt97qo"
    /// </value>
    [JsonPropertyName("openid")]
    public string? OpenId { get; set; }

    /// <summary>
    /// 扫描二维码领取的卡券。
    /// 如果只有一组，则生成领取单张卡券的二维码。
    /// 如果有多组，则生成领取多张卡券的二维码
    /// </summary>
    public List<WeChatMpCardQrcodeCreateModel> Cards { get; set; }

    protected override string GetRequestUri()
        => $"{WeChatProperties.Domain}{Endpoint}"
        .Replace("{access_token}", AccessToken);

    protected override async Task<HttpContent?> GetContent()
    {
        await Task.CompletedTask;

        var body = new Dictionary<string, object>();

        if (ExpireSeconds.HasValue && ExpireSeconds.Value >= 60 && ExpireSeconds.Value <= 180)
        {
            body["expire_seconds"] = ExpireSeconds.Value;
        }

        if (!string.IsNullOrWhiteSpace(OpenId))
        {

            foreach (var item in Cards)
            {
                item.OpenId = OpenId;
            }
        }

        if (Cards.Count == 1)
        {
            body["action_name"] = "QR_CARD";
            body["action_info"] = new
            {
                card = Cards[0],
            };
        }
        else
        {
            body["action_name"] = "QR_MULTIPLE_CARD";
            body["action_info"] = new
            {
                multiple_card = new
                {
                    card_list = Cards
                },
            };
        }

        var json = JsonSerializer.Serialize(body, JsonSerializerOptions);

        return new StringContent(json);
    }
}
