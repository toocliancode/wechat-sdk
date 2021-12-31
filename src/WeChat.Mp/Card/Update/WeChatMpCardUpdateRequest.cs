namespace WeChat.Mp.Card;

/// <summary>
/// 【卡券】更改卡券信息
/// <a href="https://developers.weixin.qq.com/doc/offiaccount/Cards_and_Offer/Managing_Coupons_Vouchers_and_Cards.html#4"></a>
/// </summary>
/// <remarks>
/// <para>支持更新所有卡券类型的部分通用字段及特殊卡券（会员卡、飞机票、电影票、会议门票）中特定字段的信息。</para>
/// <b>开发者注意事项注：</b>
/// <para>1. 请开发者注意需要重新提审的字段，开发者调用更新接口时，若传入了提审字段则卡券需要重新进入审核状态；</para>
/// <para>2. 接口更新方式为覆盖更新：即开发者只需传入需要更改的字段，其他字段无需填入，否则可能导致卡券重新提审；</para>
/// <para>3. 若开发者置空某些字段，可直接在更新时传“”（空）；</para>
/// <para>4. 调用该接口后更改卡券信息后，请务必调用 首页验证是否已成功更改；</para>
/// <para>5.未列出的字段不支持修改更新。</para>
/// </remarks>
public class WeChatMpCardUpdateRequest
    : WeChatHttpRequest<WeChatMpCardUpdateResponse>
    , IHasAccessToken
{
    public static string Endpoint = "/card/update?access_token={access_token}";

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpCardUpdateRequest"/>
    /// </summary>
    public WeChatMpCardUpdateRequest()
        : base(HttpMethod.Post)
    {
        BaseInfo = new();
        Special = new();
    }

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpCardUpdateRequest"/>
    /// </summary>
    /// <param name="cardId">修改的卡券Id</param>
    /// <param name="cardType">卡券类型（<see cref="CardTypes"/>）</param>
    /// <param name="baseInfo">通用(base_info)字段修改</param>
    /// <param name="special">卡券专用字段修改</param>
    /// <param name="accessToken"></param>
    public WeChatMpCardUpdateRequest(
        string cardId,
        string cardType,
        WeChatDictionary<object?> baseInfo,
        WeChatDictionary<object?> special,
        string? accessToken = default)
        : base(HttpMethod.Post)
    {
        CardId = cardId;
        CardType = cardType;
        BaseInfo = baseInfo;
        Special = special;
        AccessToken = accessToken;
    }

    [JsonIgnore]
    public string? AccessToken { get; set; }

    /// <summary>
    /// 修改的卡券Id
    /// </summary>
    [JsonPropertyName("card_id")]
    public string CardId { get; set; }

    /// <summary>
    /// 卡券类型（<see cref="CardTypes"/>）
    /// </summary>
    [JsonPropertyName("card_type")]
    public string CardType { get; set; }

    /// <summary>
    /// 通用（base_info）字段修改
    /// </summary>
    public WeChatDictionary<object?> BaseInfo { get; set; }

    /// <summary>
    /// 卡券专用字段修改
    /// </summary>
    public WeChatDictionary<object?> Special { get; set; }

    protected override string GetRequestUri() => $"{WeChatProperties.Domain}{Endpoint}"
        .Replace("{access_token}", AccessToken);

    /// <summary>
    /// 设置修改通用（base_info）字段
    /// </summary>
    /// <param name="key">字段名称</param>
    /// <param name="value">字段的值</param>
    /// <returns></returns>
    public WeChatMpCardUpdateRequest UpdateBaseInfo(string key, object? value)
    {
        BaseInfo[key] = value;
        return this;
    }

    /// <summary>
    /// 设置修改卡券专用字段
    /// </summary>
    /// <param name="key">字段名称</param>
    /// <param name="value">字段的值</param>
    /// <returns></returns>
    public WeChatMpCardUpdateRequest UpdateSpecial(string key, object? value)
    {
        Special[key] = value;
        return this;
    }
}