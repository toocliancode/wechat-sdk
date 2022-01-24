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

    #region 团购券（GROUPON）

    /// <summary>
    /// 团购券（<see cref="CardType"/> = <see cref="CardTypes.GROUPON"/>）专用（必填），团购详情
    /// </summary>
    /// <remarks>
    /// 示例值："双人套餐\n -进口红酒一支。\n孜然牛肉一份。"
    /// </remarks>
    [JsonPropertyName("deal_detail")]
    public string? DealDetail { get; set; }

    /// <summary>
    /// 设置团购券参数
    /// </summary>
    /// <param name="dealDetail">
    /// 团购详情
    /// <code>示例值："双人套餐\n -进口红酒一支。\n孜然牛肉一份。"</code>
    /// </param>
    public void WithGroupon(string dealDetail)
    {
        CardType = CardTypes.GROUPON;
        DealDetail = dealDetail;
    }

    /// <summary>
    /// 设置团购券参数
    /// </summary>
    /// <param name="baseInfo">基本的卡券信息</param>
    /// <param name="advancedInfo">卡券高级信息</param>
    /// <param name="dealDetail">
    /// 团购详情
    /// <code>示例值："双人套餐\n -进口红酒一支。\n孜然牛肉一份。"</code>
    /// </param>
    public void WithGroupon(
        CardBaseInfo baseInfo,
        CardAdvancedInfo? advancedInfo,
        string dealDetail)
    {
        CardType = CardTypes.GROUPON;
        BaseInfo = baseInfo;
        AdvancedInfo = advancedInfo;
        DealDetail = dealDetail;
    }

    #endregion

    #region 代金券（CASH）

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
    /// 设置代金券参数
    /// </summary>
    /// <param name="leastCost">表示起用金额（单位为分）,如果无起用门槛则填0</param>
    /// <param name="reduceCost">表示减免金额。（单位为分）</param>
    public void WithCash(int leastCost, int reduceCost)
    {
        CardType = CardTypes.CASH;
        LeastCost = leastCost;
        ReduceCost = reduceCost;
    }

    /// <summary>
    /// 设置代金券参数
    /// </summary>
    /// <param name="baseInfo">基本的卡券信息</param>
    /// <param name="advancedInfo">卡券高级信息</param>
    /// <param name="leastCost">表示起用金额（单位为分）,如果无起用门槛则填0</param>
    /// <param name="reduceCost">表示减免金额。（单位为分）</param>
    public void WithCash(
        CardBaseInfo baseInfo,
        CardAdvancedInfo? advancedInfo,
        int leastCost,
        int reduceCost)
    {
        CardType = CardTypes.CASH;
        BaseInfo = baseInfo;
        AdvancedInfo = advancedInfo;
        LeastCost = leastCost;
        ReduceCost = reduceCost;
    }

    #endregion

    #region 折扣券（DISCOUNT）

    /// <summary>
    /// 折扣券、会员卡（<see cref="CardType"/> = <see cref="CardTypes.DISCOUNT"/>、<see cref="CardTypes.MEMBER_CARD"/>）专用，表示打折额度（百分比）。
    /// 填30就是七折
    /// </summary>
    [JsonPropertyName("discount")]
    public int? Discount { get; set; }

    /// <summary>
    /// 设置折扣券参数
    /// </summary>
    /// <param name="discount">表示打折额度（百分比）。填30就是七折</param>
    public void WithDiscount(int discount)
    {
        CardType = CardTypes.DISCOUNT;
        Discount = discount;
    }

    /// <summary>
    /// 设置折扣券参数
    /// </summary>
    /// <param name="baseInfo">基本的卡券信息</param>
    /// <param name="advancedInfo">卡券高级信息</param>
    /// <param name="discount">表示打折额度（百分比）。填30就是七折</param>
    public void WithDiscount(
        CardBaseInfo baseInfo,
        CardAdvancedInfo? advancedInfo,
        int discount)
    {
        CardType = CardTypes.CASH;
        BaseInfo = baseInfo;
        AdvancedInfo = advancedInfo;
        Discount = discount;
    }

    #endregion

    #region 兑换券（GIFT）

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

    /// <summary>
    /// 设置兑换券参数
    /// </summary>
    /// <param name="gift">填写兑换内容的名称</param>
    /// <param name="defaultDetail">填写兑换内容的名称 <code>示例值："可兑换音乐木盒一个"</code></param>
    public void WithGift(
        string gift,
        string defaultDetail)
    {
        CardType = CardTypes.CASH;
        Gift = gift;
        DefaultDetail = defaultDetail;
    }

    /// <summary>
    /// 设置兑换券参数
    /// </summary>
    /// <param name="baseInfo">基本的卡券信息</param>
    /// <param name="advancedInfo">卡券高级信息</param>
    /// <param name="gift">填写兑换内容的名称</param>
    /// <param name="defaultDetail">填写兑换内容的名称 <code>示例值："可兑换音乐木盒一个"</code></param>
    public void WithGift(
        CardBaseInfo baseInfo,
        CardAdvancedInfo? advancedInfo,
        string gift,
        string defaultDetail)
    {
        CardType = CardTypes.CASH;
        BaseInfo = baseInfo;
        AdvancedInfo = advancedInfo;
        Gift = gift;
        DefaultDetail = defaultDetail;
    }

    #endregion

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
    public bool SupplyBalance { get; set; }

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

    /// <summary>
    /// 设置会员卡参数
    /// </summary>
    /// <param name="backgroundPicUrl">
    /// 商家自定义会员卡背景图，须先调用[上传图片接口]将背景图上传至CDN，否则报错。
    /// 卡面设计请遵循微信会员卡自定义背景设计规范 ,像素大小控制在 1000像素*600像素以下
    /// </param>
    /// <param name="prerogative">会员卡特权说明,限制1024汉字</param>
    /// <param name="autoActivate">
    /// 设置为true时用户领取会员卡后系统自动将其激活，无需调用激活接口，
    /// 详情见：<a href="https://developers.weixin.qq.com/doc/offiaccount/Cards_and_Offer/Membership_Cards/Create_a_membership_card.html#17">自动激活</a>
    /// </param>
    /// <param name="wxActivate">
    /// 设置为true时会员卡支持一键开卡，不允许同时传入activate_url字段，否则设置wx_activate失效。
    /// 填入该字段后仍需调用接口设置开卡项方可生效，
    /// 详情见：<a href="https://developers.weixin.qq.com/doc/offiaccount/Cards_and_Offer/Membership_Cards/Create_a_membership_card.html#16">一键激活</a>
    /// </param>
    /// <param name="supplyBonus">
    /// 显示积分，填写true或false，
    /// 如填写true，积分相关字段均为【必填】。
    /// 若设置为true则后续不可以被关闭
    /// </param>
    /// <param name="bonusUrl">
    /// 设置跳转外链查看余额详情。
    /// 仅适用于余额无法通过激活接口同步的情况下使用该字段
    /// </param>
    /// <param name="supplyBalance">
    /// 是否支持储值，填写true或false。
    /// 如填写true，储值相关字段均为【必填】。
    /// 若设置为true则后续不可以被关闭。
    /// 该字段须开通储值功能后方可使用，详情见：获取特殊权限
    /// </param>
    /// <param name="balanceUrl">
    /// 设置跳转外链查看余额详情。
    /// 仅适用于余额无法通过激活接口同步的情况下使用该字段
    /// </param>
    /// <param name="customField1">自定义会员信息类目，会员卡激活后显示,包含name_type (name) 和url字段</param>
    /// <param name="customField2">自定义会员信息类目，会员卡激活后显示,包含name_type (name) 和url字段</param>
    /// <param name="customField3">自定义会员信息类目，会员卡激活后显示,包含name_type (name) 和url字段</param>
    /// <param name="bonusCleared">积分清零规则</param>
    /// <param name="bonusRules">积分规则</param>
    /// <param name="balanceRules">储值说明</param>
    /// <param name="activateUrl">激活会员卡的url</param>
    /// <param name="activateAppBrandUserName">激活会员卡url对应的小程序user_name，仅可跳转该公众号绑定的小程序</param>
    /// <param name="activateAppBrandPass">激活会员卡url对应的小程序path</param>
    /// <param name="customCell1">自定义会员信息类目，会员卡激活后显示</param>
    /// <param name="bonusRule">积分规则</param>
    /// <param name="discount">折扣，该会员卡享受的折扣优惠,填10就是九折。</param>
    public void WithMemberCard(
        string? backgroundPicUrl = default,
        string prerogative = "",
        bool? autoActivate = default,
        bool? wxActivate = default,
        bool supplyBonus = false,
        string bonusUrl = "",
        bool supplyBalance = false,
        string? balanceUrl = default,
        CardCustomField? customField1 = default,
        CardCustomField? customField2 = default,
        CardCustomField? customField3 = default,
        string? bonusCleared = default,
        string? bonusRules = default,
        string? balanceRules = default,
        string? activateUrl = default,
        string? activateAppBrandUserName = default,
        string? activateAppBrandPass = default,
        CardCustomCell? customCell1 = default,
        CardBonusRule? bonusRule = default,
        int? discount = default
        )
    {
        CardType = CardTypes.MEMBER_CARD;
        BackgroundPicUrl = backgroundPicUrl;
        Prerogative = prerogative;
        AutoActivate = autoActivate;
        WxActivite = wxActivate;
        SupplyBonus = supplyBonus;
        BonusUrl = bonusUrl;
        SupplyBalance = supplyBalance;
        BalanceUrl = balanceUrl;
        CustomField1 = customField1;
        CustomField2 = customField2;
        CustomField3 = customField3;
        BonusCleared = bonusCleared;
        BonusRules = bonusRules;
        BalanceRules = balanceRules;
        ActivateUrl = activateUrl;
        ActivateAppBrandUserName = activateAppBrandUserName;
        ActivateAppBrandPass = activateAppBrandPass;
        CustomCell1 = customCell1;
        BonusRule = bonusRule;
        Discount = discount;
    }

    #endregion

    #region 礼品卡（GENERAL_CARD）

    /// <summary>
    /// 卡类型
    /// </summary>
    /// <value>
    /// GIFT_CARD：礼品卡；
    /// VOUCHER：兑换卡
    /// </value>
    [JsonPropertyName("sub_card_type")]
    public string SubCardType { get; set; }

    /// <summary>
    /// 初始余额，用户购买礼品卡后卡面上显示的初始余额
    /// </summary>
    [JsonPropertyName("init_balance")]
    public int? InitBalance { get; set; }

    /// <summary>
    /// 设置礼品卡参数
    /// </summary>
    /// <param name="subCardType">卡类型,目前支持GIFT_CARD：礼品卡、VOUCHER：兑换卡</param>
    /// <param name="backgroundPicUrl">
    /// 商家自定义会员卡背景图，须先调用[上传图片接口]将背景图上传至CDN，否则报错。
    /// 卡面设计请遵循微信会员卡自定义背景设计规范 ,像素大小控制在 1000像素*600像素以下
    /// </param>
    /// <param name="prerogative">会员卡特权说明,限制1024汉字</param>
    /// <param name="autoActivate">
    /// 设置为true时用户领取会员卡后系统自动将其激活，无需调用激活接口，
    /// 详情见：<a href="https://developers.weixin.qq.com/doc/offiaccount/Cards_and_Offer/Membership_Cards/Create_a_membership_card.html#17">自动激活</a>
    /// </param>
    /// <param name="wxActivate">
    /// 设置为true时会员卡支持一键开卡，不允许同时传入activate_url字段，否则设置wx_activate失效。
    /// 填入该字段后仍需调用接口设置开卡项方可生效，
    /// 详情见：<a href="https://developers.weixin.qq.com/doc/offiaccount/Cards_and_Offer/Membership_Cards/Create_a_membership_card.html#16">一键激活</a>
    /// </param>
    /// <param name="supplyBonus">
    /// 显示积分，填写true或false，
    /// 如填写true，积分相关字段均为【必填】。
    /// 若设置为true则后续不可以被关闭
    /// </param>
    /// <param name="bonusUrl">
    /// 设置跳转外链查看余额详情。
    /// 仅适用于余额无法通过激活接口同步的情况下使用该字段
    /// </param>
    /// <param name="supplyBalance">
    /// 是否支持储值，填写true或false。
    /// 如填写true，储值相关字段均为【必填】。
    /// 若设置为true则后续不可以被关闭。
    /// 该字段须开通储值功能后方可使用，详情见：获取特殊权限
    /// </param>
    /// <param name="initBalance">初始余额，用户购买礼品卡后卡面上显示的初始余额</param>
    /// <param name="balanceUrl">
    /// 设置跳转外链查看余额详情。
    /// 仅适用于余额无法通过激活接口同步的情况下使用该字段
    /// </param>
    /// <param name="customField1">自定义会员信息类目，会员卡激活后显示,包含name_type (name) 和url字段</param>
    /// <param name="customField2">自定义会员信息类目，会员卡激活后显示,包含name_type (name) 和url字段</param>
    /// <param name="customField3">自定义会员信息类目，会员卡激活后显示,包含name_type (name) 和url字段</param>
    /// <param name="bonusCleared">积分清零规则</param>
    /// <param name="bonusRules">积分规则</param>
    /// <param name="balanceRules">储值说明</param>
    /// <param name="activateUrl">激活会员卡的url</param>
    /// <param name="activateAppBrandUserName">激活会员卡url对应的小程序user_name，仅可跳转该公众号绑定的小程序</param>
    /// <param name="activateAppBrandPass">激活会员卡url对应的小程序path</param>
    /// <param name="customCell1">自定义会员信息类目，会员卡激活后显示</param>
    /// <param name="bonusRule">积分规则</param>
    /// <param name="discount">折扣，该会员卡享受的折扣优惠,填10就是九折。</param>
    public void WithGeneralCard(
        string subCardType,
        string? backgroundPicUrl = default,
        string prerogative = "",
        bool? autoActivate = default,
        bool? wxActivate = default,
        bool supplyBonus = false,
        string bonusUrl = "",
        bool supplyBalance = false,
        int? initBalance = default,
        string? balanceUrl = default,
        CardCustomField? customField1 = default,
        CardCustomField? customField2 = default,
        CardCustomField? customField3 = default,
        string? bonusCleared = default,
        string? bonusRules = default,
        string? balanceRules = default,
        string? activateUrl = default,
        string? activateAppBrandUserName = default,
        string? activateAppBrandPass = default,
        CardCustomCell? customCell1 = default,
        CardBonusRule? bonusRule = default,
        int? discount = default
        )
    {
        CardType = CardTypes.GENERAL_CARD;
        SubCardType = subCardType;
        BackgroundPicUrl = backgroundPicUrl;
        Prerogative = prerogative;
        AutoActivate = autoActivate;
        WxActivite = wxActivate;
        SupplyBonus = supplyBonus;
        InitBalance = initBalance;
        BonusUrl = bonusUrl;
        SupplyBalance = supplyBalance;
        BalanceUrl = balanceUrl;
        CustomField1 = customField1;
        CustomField2 = customField2;
        CustomField3 = customField3;
        BonusCleared = bonusCleared;
        BonusRules = bonusRules;
        BalanceRules = balanceRules;
        ActivateUrl = activateUrl;
        ActivateAppBrandUserName = activateAppBrandUserName;
        ActivateAppBrandPass = activateAppBrandPass;
        CustomCell1 = customCell1;
        BonusRule = bonusRule;
        Discount = discount;
    }
    #endregion

    #region 会议门票（MEETING_TICKET）

    /// <summary>
    /// 会议详情
    /// </summary>
    /// <value>
    /// 示例值：" 本次会议于2015年5月10号在广州举行，会场地点：xxxx。"
    /// </value>
    [JsonPropertyName("meeting_detail")]
    public string MeetingDetail { get; set; }

    /// <summary>
    /// 会场导览图
    /// </summary>
    /// <value>
    /// 示例值："xxx.com"
    /// </value>
    [JsonPropertyName("map_url")]
    public string? MapUrl { get; set; }

    /// <summary>
    /// 设置会议门票参数
    /// </summary>
    /// <param name="meetingDetail">会议详情</param>
    /// <param name="mapUrl">会场导览图</param>
    public void WithMeetingTicket(
        string meetingDetail,
        string? mapUrl = default)
    {
        CardType = CardTypes.MEETING_TICKET;
        MeetingDetail = meetingDetail;
        MapUrl = mapUrl;
    }

    #endregion

    #region 景区门票（SCENIC_TICKET）

    /// <summary>
    /// 票类型，例如平日全票，套票等
    /// </summary>
    /// <value>
    /// 示例值："平日全票"
    /// </value>
    [JsonPropertyName("ticket_class")]
    public string TicketClass { get; set; }

    /// <summary>
    /// 导览图url
    /// </summary>
    [JsonPropertyName("guide_url")]
    public string? GuideUrl { get; set; }

    /// <summary>
    /// 设置景区门票参数
    /// </summary>
    /// <param name="ticketClass">票类型，例如平日全票，套票等</param>
    /// <param name="guideUrl">导览图url</param>
    public void WithScenicTicket(
        string ticketClass,
        string? guideUrl = default)
    {
        CardType = CardTypes.SCENIC_TICKET;
        TicketClass = ticketClass;
        GuideUrl = guideUrl;
    }

    #endregion

    #region 电影票（MOVIE_TICKET）

    /// <summary>
    /// 电影票详情
    /// </summary>
    /// <value>
    /// 示例值："电影名：xxx，电影简介：xxx"
    /// </value>
    [JsonPropertyName("detail")]
    public string Detail { get; set; }

    public void WithMovieTicket(string detail)
    {
        CardType = CardTypes.MOVIE_TICKET;
        Detail = detail;
    }

    #endregion

    #region 飞机票（BOARDING_PASS）

    /// <summary>
    /// 起点，上限为18个汉字
    /// </summary>
    /// <value>
    /// 示例值："成都"
    /// </value>
    [JsonPropertyName("from")]
    public string From { get; set; }

    /// <summary>
    /// 终点，上限为18个汉字
    /// </summary>
    ///  <value>
    /// 示例值："广州"
    /// </value>
    [JsonPropertyName("to")]
    public string To { get; set; }

    /// <summary>
    /// 航班
    /// </summary>
    /// <value>
    /// 示例值："CE123"
    /// </value>
    [JsonPropertyName("flight")]
    public string Flight { get; set; }

    /// <summary>
    /// 入口，上限为4个汉字
    /// </summary>
    /// <value>
    /// 示例值："A11"
    /// </value>
    [JsonPropertyName("gate")]
    public string? Gate { get; set; }

    /// <summary>
    /// 在线值机的链接
    /// </summary>
    [JsonPropertyName("check_in_url")]
    public string? CheckInUrl { get; set; }

    /// <summary>
    /// 机型，上限为8个汉字
    /// </summary>
    /// <value>
    /// 示例值："空客A320"
    /// </value>
    [JsonPropertyName("air_model")]
    public string? AirModel { get; set; }

    /// <summary>
    /// 起飞时间。Unix时间戳格式
    /// </summary>
    /// <value>
    /// 示例值："1434507901"
    /// </value>
    [JsonPropertyName("departure_time")]
    public string DepartureTime { get; set; }

    /// <summary>
    /// 降落时间。Unix时间戳格式
    /// </summary>
    /// <value>
    /// 示例值："1434909901"
    /// </value>
    [JsonPropertyName("")]
    public string LandingTime { get; set; }

    /// <summary>
    /// 设置飞机票参数
    /// </summary>
    /// <param name="from">起点，上限为18个汉字</param>
    /// <param name="to">终点，上限为18个汉字</param>
    /// <param name="flight">航班</param>
    /// <param name="airModel">机型，上限为8个汉字</param>
    /// <param name="departureTime">起飞时间。Unix时间戳格式</param>
    /// <param name="landingTime">降落时间。Unix时间戳格式</param>
    /// <param name="gate">入口，上限为4个汉字</param>
    /// <param name="checkInUrl">在线值机的链接</param>
    public void WithBoardingPass(
        string from,
        string to,
        string flight,
        string airModel,
        string departureTime,
        string landingTime,
        string? gate = default,
        string? checkInUrl = default)
    {
        CardType = CardTypes.BOARDING_PASS;
        From = from;
        To = to;
        Flight = flight;
        AirModel = airModel;
        DepartureTime = departureTime;
        LandingTime = landingTime;
        Gate = gate;
        CheckInUrl = checkInUrl;
    }

    #endregion

    protected override string GetRequestUri() => $"{WeChatProperties.Domain}{Endpoint}"
        .Replace("{access_token}", AccessToken);

    protected override async Task<HttpContent?> GetContent()
    {
        await Task.CompletedTask;

        var card = new WeChatDictionary<object?>
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
                card["least_cost"] = LeastCost ?? throw new ArgumentNullException(nameof(LeastCost));
                card["reduce_cost"] = ReduceCost ?? throw new ArgumentNullException(nameof(ReduceCost));
                break;
            case CardTypes.DISCOUNT:
                card["discount"] = Discount ?? throw new ArgumentNullException(nameof(Discount));
                break;
            case CardTypes.GIFT:
                card["gift"] = Gift ?? throw new ArgumentNullException(nameof(Gift));
                break;
            case CardTypes.GENERAL_COUPON:
                card["default_detail"] = DefaultDetail ?? throw new ArgumentNullException(nameof(DefaultDetail));
                break;
            case CardTypes.MEMBER_CARD:
                card["background_pic_url"] = BackgroundPicUrl;
                card["prerogative"] = Prerogative;
                card["auto_activate"] = AutoActivate;
                card["wx_activate"] = WxActivite;
                card["supply_bonus"] = SupplyBonus;
                card["bonus_url"] = BonusUrl;
                card["supply_balance"] = SupplyBalance;
                card["balance_url"] = BalanceUrl;
                card["custom_field1"] = CustomField1;
                card["custom_field2"] = CustomField2;
                card["custom_field3"] = CustomField3;
                card["bonus_cleared"] = BonusCleared;
                card["balance_rules"] = BalanceRules;
                card["activate_url"] = ActivateUrl;
                card["activate_app_brand_user_name"] = ActivateAppBrandUserName;
                card["activate_app_brand_pass"] = ActivateAppBrandPass;
                card["custom_cell1"] = CustomCell1;
                card["bonus_rule"] = BonusRule;
                card["discount"] = Discount;
                break;
            case CardTypes.GENERAL_CARD:
                card["subCardType"] = SubCardType;
                card["background_pic_url"] = BackgroundPicUrl;
                card["prerogative"] = Prerogative;
                card["auto_activate"] = AutoActivate;
                card["wx_activate"] = WxActivite;
                card["supply_bonus"] = SupplyBonus;
                card["bonus_url"] = BonusUrl;
                card["supply_balance"] = SupplyBalance;
                card["init_balance"] = InitBalance;
                card["balance_url"] = BalanceUrl;
                card["custom_field1"] = CustomField1;
                card["custom_field2"] = CustomField2;
                card["custom_field3"] = CustomField3;
                card["bonus_cleared"] = BonusCleared;
                card["balance_rules"] = BalanceRules;
                card["activate_url"] = ActivateUrl;
                card["activate_app_brand_user_name"] = ActivateAppBrandUserName;
                card["activate_app_brand_pass"] = ActivateAppBrandPass;
                card["custom_cell1"] = CustomCell1;
                card["bonus_rule"] = BonusRule;
                card["discount"] = Discount;
                break;
            case CardTypes.MEETING_TICKET:
                card["meeting_detail"] = MeetingDetail;
                card["map_url"] = MapUrl;
                break;
            case CardTypes.SCENIC_TICKET:
                card["ticket_class"] = TicketClass;
                card["guide_url"] = GuideUrl;
                break;
            case CardTypes.MOVIE_TICKET:
                card["detail"] = Detail;
                break;
            case CardTypes.BOARDING_PASS:
                card["from"] = From;
                card["to"] = To;
                card["flight"] = Flight;
                card["gate"] = Gate;
                card["check_in_url"] = CheckInUrl;
                card["air_model"] = AirModel;
                card["departure_time"] = DepartureTime;
                card["landing_time"] = LandingTime;
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
