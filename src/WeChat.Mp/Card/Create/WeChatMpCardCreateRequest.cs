namespace WeChat.Mp.Card;

/// <summary>
/// 【卡券】创建卡券
/// <a href="https://developers.weixin.qq.com/doc/offiaccount/Cards_and_Offer/Create_a_Coupon_Voucher_or_Card.html"></a>
/// </summary>
public class WeChatMpCardCreateRequest
    : WeChatHttpRequest<WeChatMpCardCreateResponse>
    , IHasAccessToken
{
    public static string Endpoint = "/card/create?access_token={access_token}";

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpCardCreateRequest"/>
    /// </summary>
    public WeChatMpCardCreateRequest()
    {

    }

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpCardCreateRequest"/>
    /// </summary>
    /// <param name="baseInfo">基本的卡券信息</param>
    /// <param name="advancedInfo">卡券高级信息</param>
    /// <param name="accessToken">微信API access_token，不传自动获取</param>
    public WeChatMpCardCreateRequest(
        CardBaseInfo baseInfo,
        CardAdvancedInfo? advancedInfo,
        string? accessToken)
    {
        BaseInfo = baseInfo;
        AdvancedInfo = advancedInfo;
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
    public CardBaseInfo BaseInfo { get; set; }

    /// <summary>
    /// 卡券高级信息
    /// </summary>
    [JsonPropertyName("advanced_info")]
    public CardAdvancedInfo? AdvancedInfo { get; set; }

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
    /// 折扣券（<see cref="CardType"/> = <see cref="CardTypes.DISCOUNT"/>、<see cref="CardTypes.MEMBER_CARD"/>）专用，表示打折额度（百分比）。
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

    #region 会员卡(MEMBER_CARD)

    /// <summary>
    /// 商家自定义会员卡背景图，须先调用[上传图片接口]将背景图上传至CDN，否则报错。
    /// 卡面设计请遵循微信会员卡自定义背景设计规范 ,像素大小控制在 1000像素*600像素以下
    /// </summary>
    [JsonPropertyName("background_pic_url")]
    public string? BackgroundPicUrl { get; set; }

    /// <summary>
    /// 会员卡特权说明,限制1024汉字
    /// </summary>
    [JsonPropertyName("prerogative")]
    public string Prerogative { get; set; }

    /// <summary>
    /// 设置为true时用户领取会员卡后系统自动将其激活，无需调用激活接口，详情见：<a href="https://developers.weixin.qq.com/doc/offiaccount/Cards_and_Offer/Membership_Cards/Create_a_membership_card.html#17">自动激活</a>
    /// </summary>
    [JsonPropertyName("auto_activate")]
    public bool? AutoActivate { get; set; }

    /// <summary>
    /// 设置为true时会员卡支持一键开卡，不允许同时传入activate_url字段，否则设置wx_activate失效。
    /// 填入该字段后仍需调用接口设置开卡项方可生效，详情见：<a href="https://developers.weixin.qq.com/doc/offiaccount/Cards_and_Offer/Membership_Cards/Create_a_membership_card.html#16">一键激活</a>
    /// </summary>
    [JsonPropertyName("auto_activate")]
    public bool? WxActivite { get; set; }

    /// <summary>
    /// 显示积分，填写true或false，
    /// 如填写true，积分相关字段均为【必填】。
    /// 若设置为true则后续不可以被关闭
    /// </summary>
    [JsonPropertyName("supply_bonus")]
    public bool SupplyBonus { get; set; }

    /// <summary>
    /// 设置跳转外链查看积分详情。
    /// 仅适用于积分无法通过激活接口同步的情况下使用该字段。
    /// </summary>
    [JsonPropertyName("bonus_url")]
    public string? BonusUrl { get; set; }

    /// <summary>
    /// 是否支持储值，填写true或false。
    /// 如填写true，储值相关字段均为【必填】。
    /// 若设置为true则后续不可以被关闭。
    /// 该字段须开通储值功能后方可使用，详情见：获取特殊权限
    /// </summary>
    [JsonPropertyName("supply_balance")]
    public bool SupplyBlance { get; set; }

    /// <summary>
    /// 设置跳转外链查看余额详情。
    /// 仅适用于余额无法通过激活接口同步的情况下使用该字段
    /// </summary>
    [JsonPropertyName("balance_url")]
    public string? BalanceUrl { get; set; }

    /// <summary>
    /// 自定义会员信息类目，会员卡激活后显示,包含name_type (name) 和url字段
    /// </summary>
    [JsonPropertyName("custom_field1")]
    public CardCustomField? CustomField1 { get; set; }

    /// <summary>
    /// 自定义会员信息类目，会员卡激活后显示,包含name_type (name) 和url字段
    /// </summary>
    [JsonPropertyName("custom_field2")]
    public CardCustomField? CustomField2 { get; set; }

    /// <summary>
    /// 自定义会员信息类目，会员卡激活后显示,包含name_type (name) 和url字段
    /// </summary>
    [JsonPropertyName("custom_field3")]
    public CardCustomField? CustomField3 { get; set; }

    /// <summary>
    /// 积分清零规则
    /// </summary>
    [JsonPropertyName("bonus_cleared")]
    public string? BonusCleared { get; set; }

    /// <summary>
    /// 积分规则
    /// </summary>
    [JsonPropertyName("bonus_rules")]
    public string? BonusRules { get; set; }

    /// <summary>
    /// 储值说明
    /// </summary>
    [JsonPropertyName("balance_rules")]
    public string? BalanceRules { get; set; }

    /// <summary>
    /// 激活会员卡的url
    /// </summary>
    [JsonPropertyName("activate_url")]
    public string? ActivateUrl { get; set; }

    /// <summary>
    /// 激活会员卡url对应的小程序user_name，仅可跳转该公众号绑定的小程序
    /// </summary>
    [JsonPropertyName("activate_app_brand_user_name")]
    public string? ActivateAppBrandUserName { get; set; }

    /// <summary>
    /// 激活会员卡url对应的小程序path
    /// </summary>
    [JsonPropertyName("activate_app_brand_pass")]
    public string? ActivateAppBrandPass { get; set; }

    /// <summary>
    /// 自定义会员信息类目，会员卡激活后显示
    /// </summary>
    [JsonPropertyName("custom_cell1")]
    public CardCustomCell? CustomCell1 { get; set; }

    /// <summary>
    /// 积分规则
    /// </summary>
    [JsonPropertyName("bonus_rule")]
    public CardBonusRule? BonusRule { get; set; }

    #endregion

    protected override string GetRequestUri() => $"{WeChatProperties.Domain}{Endpoint}"
        .Replace("{access_token}", AccessToken);

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
