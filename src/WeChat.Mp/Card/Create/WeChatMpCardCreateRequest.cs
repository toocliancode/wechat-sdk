using System.Text.Json;
using System.Text.Json.Serialization;

namespace WeChat.Mp.Card;

/// <summary>
/// 创建卡券
/// 
/// https://developers.weixin.qq.com/doc/offiaccount/Cards_and_Offer/Create_a_Coupon_Voucher_or_Card.html
/// </summary>
public class WeChatMpCardCreateRequest
    : WeChatHttpRequest<WeChatMpCardCreateResponse>
    , IHasAccessToken
{
    public static string Endpoint = "https://api.weixin.qq.com/card/create";

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpCardCreateRequest"/>
    /// </summary>
    public WeChatMpCardCreateRequest()
    {

    }

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpCardCreateRequest"/>
    /// </summary>
    /// <param name="cardType">卡券类型（<see cref="CardTypes"/>）</param>
    /// <param name="baseInfo">基本的卡券信息</param>
    /// <param name="advancedInfo">卡券高级信息</param>
    /// <param name="dealDetail">团购券（<see cref="CardType"/> = <see cref="CardTypes.GROUPON"/>）专用（必填），团购详情</param>
    /// <param name="leastCost">代金券（<see cref="CardType"/> = <see cref="CardTypes.CASH"/>）专用，表示起用金额（单位为分）,如果无起用门槛则填0</param>
    /// <param name="reduceCost">代金券（<see cref="CardType"/> = <see cref="CardTypes.CASH"/>）专用，表示减免金额。（单位为分）</param>
    /// <param name="discount">
    /// 折扣券（<see cref="CardType"/> = <see cref="CardTypes.DISCOUNT"/>）专用，表示打折额度（百分比）。
    /// 填30就是七折</param>
    /// <param name="gift">兑换券（<see cref="CardType"/> = <see cref="CardTypes.GIFT"/>）专用，填写兑换内容的名称</param>
    /// <param name="defaultDetail">兑换券（<see cref="CardType"/> = <see cref="CardTypes.GENERAL_COUPON"/>）专用，填写优惠详情</param>
    /// <param name="accessToken">微信API access_token，不传自动获取</param>
    public WeChatMpCardCreateRequest(
        string cardType,
        WeChatMpCardCreateBaseInfo baseInfo,
        WeChatMpCardCreateAdvancedInfo? advancedInfo,
        string? dealDetail,
        int? leastCost,
        int? reduceCost,
        int? discount,
        string? gift,
        string? defaultDetail,
        string? accessToken)
    {
        CardType = cardType;
        BaseInfo = baseInfo;
        AdvancedInfo = advancedInfo;
        DealDetail = dealDetail;
        LeastCost = leastCost;
        ReduceCost = reduceCost;
        Discount = discount;
        Gift = gift;
        DefaultDetail = defaultDetail;
        AccessToken = accessToken;
    }

    /// <inheritdoc/>
    [JsonIgnore]
    public string? AccessToken { get; set; }

    /// <summary>
    /// 卡券类型（<see cref="CardTypes"/>）
    /// </summary>
    [JsonPropertyName("card_type")]
    public string CardType { get; set; }

    /// <summary>
    /// 基本的卡券信息
    /// </summary>
    [JsonPropertyName("base_info")]
    public WeChatMpCardCreateBaseInfo BaseInfo { get; set; }

    /// <summary>
    /// 卡券高级信息
    /// </summary>
    [JsonPropertyName("advanced_info")]
    public WeChatMpCardCreateAdvancedInfo? AdvancedInfo { get; set; }

    /// <summary>
    /// 团购券（<see cref="CardType"/> = <see cref="CardTypes.GROUPON"/>）专用（必填），团购详情
    /// </summary>
    /// <remarks>
    /// 示例值："双人套餐\n -进口红酒一支。\n孜然牛肉一份。"
    /// </remarks>
    [JsonPropertyName("deal_detail")]
    public string? DealDetail { get; set; }

    /// <summary>
    /// 代金券（<see cref="CardType"/> = <see cref="CardTypes.CASH"/>）专用，表示起用金额（单位为分）,如果无起用门槛则填0
    /// </summary>
    [JsonPropertyName("least_cost")]
    public int? LeastCost { get; set; }

    /// <summary>
    /// 代金券（<see cref="CardType"/> = <see cref="CardTypes.CASH"/>）专用，表示减免金额。（单位为分）
    /// </summary>
    [JsonPropertyName("reduce_cost")]
    public int? ReduceCost { get; set; }

    /// <summary>
    /// 折扣券（<see cref="CardType"/> = <see cref="CardTypes.DISCOUNT"/>）专用，表示打折额度（百分比）。
    /// 填30就是七折
    /// </summary>
    [JsonPropertyName("discount")]
    public int? Discount { get; set; }

    /// <summary>
    /// 兑换券（<see cref="CardType"/> = <see cref="CardTypes.GIFT"/>）专用，填写兑换内容的名称
    /// </summary>
    /// <remarks>
    /// 示例值："可兑换音乐木盒一个"
    /// </remarks>
    [JsonPropertyName("gift")]
    public string? Gift { get; set; }

    /// <summary>
    /// 兑换券（<see cref="CardType"/> = <see cref="CardTypes.GENERAL_COUPON"/>）专用，填写优惠详情
    /// </summary>
    /// <remarks>
    /// 示例值："可兑换音乐木盒一个"
    /// </remarks>
    [JsonPropertyName("default_detail")]
    public string? DefaultDetail { get; set; }

    protected override string GetRequestUri() => $"{Endpoint}?access_token={AccessToken}";

    protected override async Task<HttpContent?> GetContent()
    {
        await Task.CompletedTask;

        var card = new Dictionary<string, object>
        {
            ["base_info"] = BaseInfo,
            ["advanced_info"] = AdvancedInfo ?? new()
        };

        switch (CardType)
        {
            case CardTypes.GROUPON:
                card["deal_detail"] = DealDetail ?? throw new ArgumentNullException(nameof(DealDetail));
                break;
            case CardTypes.CASH:
                card["least_cost"] = LeastCost ?? 0;
                card["reduce_cost"] = LeastCost ?? 1;
                break;
            case CardTypes.DISCOUNT:
                card["discount"] = LeastCost ?? 99;
                break;
            case CardTypes.GIFT:
                card["gift"] = Gift ?? throw new ArgumentNullException(nameof(Gift));
                break;
            case CardTypes.GENERAL_COUPON:
                card["default_detail"] = DefaultDetail ?? throw new ArgumentNullException(nameof(DefaultDetail));
                break;
            default:
                break;
        }

        var body = new Dictionary<string, object>
        {
            ["card"] = new Dictionary<string, object>
            {
                ["card_type"] = CardType,
                [CardType.ToLowerInvariant()] = card
            }
        };

        var json = JsonSerializer.Serialize(body, JsonSerializerOptions);

        return new StringContent(json);
    }
}
