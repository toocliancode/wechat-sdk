namespace WeChat.Mp.Card;

/// <summary>
/// 卡券基础信息
/// </summary>
public class CardBaseInfo
{
    #region 必填

    /// <summary>
    /// 卡券的商户logo，建议像素为300*300。
    /// </summary>
    /// <remarks>
    /// 示例值：http://mmbiz.qpic.cn/
    /// </remarks>
    [JsonPropertyName("logo_url")]
    public string LogoUrl { get; set; }

    /// <summary>
    /// 码型（<see cref="CodeTypes"/>）
    /// </summary>
    /// <remarks>
    /// 示例值：<see cref="CodeTypes.CODE_TYPE_TEXT"/>
    /// </remarks>
    /// <value>
    /// "CODE_TYPE_TEXT"：文本； 
    /// "CODE_TYPE_BARCODE"：一维码；
    /// "CODE_TYPE_QRCODE"二维码；
    /// "CODE_TYPE_ONLY_QRCODE"：二维码无code显示；
    /// "CODE_TYPE_ONLY_BARCODE"：一维码无code显示；
    /// CODE_TYPE_NONE：不显示code和条形码类型
    /// </value>
    [JsonPropertyName("code_type")]
    public string CodeType { get; set; }

    /// <summary>
    /// 商户名字,字数上限为12个汉字
    /// </summary>
    /// <remarks>
    /// 示例值："海底捞"
    /// </remarks>
    [JsonPropertyName("brand_name")]
    public string BrandName { get; set; }

    /// <summary>
    /// 卡券名，字数上限为9个汉字。(建议涵盖卡券属性、服务及金额)
    /// </summary>
    /// <remarks>
    /// 示例值："双人套餐100元兑换券"
    /// </remarks>
    [JsonPropertyName("title")]
    public string Title { get; set; }

    /// <summary>
    /// 券颜色。
    /// 按色彩规范标注填写Color010-Color100。
    /// </summary>
    /// <remarks>
    /// 示例值："Color010"
    /// </remarks>
    [JsonPropertyName("coloe")]
    public string Color { get; set; }

    /// <summary>
    /// 卡券使用提醒，字数上限为16个汉字
    /// </summary>
    /// <remarks>
    /// 示例值："请出示二维码"
    /// </remarks>
    [JsonPropertyName("notice")]
    public string Notice { get; set; }

    /// <summary>
    /// 卡券使用说明，字数上限为1024个汉字
    /// </summary>
    /// <remarks>
    /// 示例值：不可与其他优惠同享
    /// </remarks>
    [JsonPropertyName("description")]
    public string Description { get; set; }

    /// <summary>
    /// 商品库存信息
    /// </summary>
    [JsonPropertyName("sku")]
    public CardSku Sku { get; set; }

    /// <summary>
    /// 使用日期，有效期的信息。
    /// </summary>
    [JsonPropertyName("date_info")]
    public CardDateInfo DateInfo { get; set; }

    #endregion

    #region 非必填

    /// <summary>
    /// 是否自定义Code码 。填写true或false，默认为false。 
    /// 通常自有优惠码系统的开发者选择 自定义Code码，并在卡券投放时带入 Code码，详情见 是否自定义Code码
    /// </summary>
    [JsonPropertyName("use_custom_code")]
    public bool? UseCustomCode { get; set; }

    /// <summary>
    /// 填入 GET_CUSTOM_CODE_MODE_DEPOSIT 表示该卡券为预存code模式卡券，
    /// 须导入超过库存数目的自定义code后方可投放，填入该字段后，quantity字段须为0,须导入code 后再增加库存
    /// </summary>
    /// <value>
    /// GET_CUSTOM_CODE_MODE_DEPOSIT
    /// </value>
    [JsonPropertyName("get_custom_code_mode")]
    public string? GetCustomCodeMode { get; set; }

    /// <summary>
    /// 是否指定用户领取，填写true或false。
    /// 默认为false。通常指定特殊用户群体 投放卡券或防止刷券时选择指定用户领取。
    /// </summary>
    [JsonPropertyName("bind_openid")]
    public bool? BindOpenId { get; set; }

    /// <summary>
    /// 客服电话
    /// </summary>
    [JsonPropertyName("service_phone")]
    public string? ServicePhone { get; set; }

    /// <summary>
    /// 门店位置poiid。 
    /// 调用 POI门店管理接 口 获取门店位置poiid。
    /// 具备线下门店 的商户为必填
    /// </summary>
    [JsonPropertyName("location_id_list")]
    public List<long>? LocationIdList { get; set; }

    /// <summary>
    /// 设置本卡券支持全部门店，与location_id_list互斥
    /// </summary>
    [JsonPropertyName("use_all_locations")]
    public bool? UseAllLocations { get; set; }

    /// <summary>
    /// 卡券顶部居中的按钮，仅在卡券状 态正常(可以核销)时显示
    /// </summary>
    /// <remarks>
    /// 示例值："立即使用"
    /// </remarks>
    [JsonPropertyName("center_title")]
    public string? CenterTitle { get; set; }

    /// <summary>
    /// 显示在入口下方的提示语 ，仅在卡券状态正常(可以核销)时显示。
    /// </summary>
    /// <remarks>
    /// 示例值："立即享受优惠"
    /// </remarks>
    [JsonPropertyName("center_sub_title")]
    public string? CenterSubTitle { get; set; }

    /// <summary>
    /// 顶部居中的url ，仅在卡券状态正常(可以核销)时显示。
    /// </summary>
    /// <remarks>
    /// 示例值："www.qq.com"
    /// </remarks>
    [JsonPropertyName("center_url")]
    public string? CenterUrl { get; set; }

    /// <summary>
    /// 卡券跳转的小程序的user_name，仅可跳转该 公众号绑定的小程序 。
    /// </summary>
    /// <remarks>
    /// 示例值："gh_86a091e50ad4@app"
    /// </remarks>
    [JsonPropertyName("center_app_brand_user_name")]
    public string? CenterAppBrandUserName { get; set; }

    /// <summary>
    /// 卡券跳转的小程序的path
    /// </summary>
    /// <remarks>
    /// 示例值："pages/card"
    /// </remarks>
    [JsonPropertyName("center_app_brand_pass")]
    public string? CenterAppBrandPass { get; set; }

    /// <summary>
    /// 显示在入口右侧的提示语。
    /// </summary>
    /// <remarks>
    /// 示例值："更多惊喜"
    /// </remarks>
    [JsonPropertyName("custom_url_sub_title")]
    public string? CustomUrlSubTitle { get; set; }

    /// <summary>
    /// 卡券跳转的小程序的user_name，仅可跳转该 公众号绑定的小程序 。
    /// </summary>
    /// <remarks>
    /// 示例值："gh_86a091e50ad4@app"
    /// </remarks>
    [JsonPropertyName("custom_app_brand_user_name")]
    public string? CustomAppBrandUserName { get; set; }

    /// <summary>
    /// 卡券跳转的小程序的path
    /// </summary>
    /// <remarks>
    /// 示例值："pages/card"
    /// </remarks>
    [JsonPropertyName("custom_app_brand_pass")]
    public string? CustomAppBrandPass { get; set; }

    /// <summary>
    /// 营销场景的自定义入口名称
    /// </summary>
    /// <remarks>
    /// 示例值："产品介绍"
    /// </remarks>
    [JsonPropertyName("promotion_url_name")]
    public string? PromotionUrlName { get; set; }

    /// <summary>
    /// 入口跳转外链的地址链接
    /// </summary>
    /// <remarks>
    /// 示例值："www.qq.com"
    /// </remarks>
    [JsonPropertyName("promotion_url")]
    public string? PromotionUrl { get; set; }

    /// <summary>
    /// 显示在营销入口右侧的提示语
    /// </summary>
    /// <remarks>
    /// 示例值："卖场大优惠"
    /// </remarks>
    [JsonPropertyName("promotion_url_sub_title")]
    public string? PromotionUrlSubTitle { get; set; }

    /// <summary>
    /// 卡券跳转的小程序的user_name，仅可跳转该 公众号绑定的小程序 
    /// </summary>
    /// <remarks>
    /// 示例值："gh_86a091e50ad4@app"
    /// </remarks>
    [JsonPropertyName("promotion_app_brand_user_name")]
    public string? PromotionAooBrandUserName { get; set; }

    /// <summary>
    /// 卡券跳转的小程序的path
    /// </summary>
    /// <remarks>
    /// 示例值："pages/card"
    /// </remarks>
    [JsonPropertyName("promotion _app_brand_pass")]
    public string? PromotionAppBrandPass { get; set; }

    /// <summary>
    /// 每人可领券的数量限制,不填写默认为50
    /// </summary>
    [JsonPropertyName("get_limit")]
    public int? GetLimit { get; set; }

    /// <summary>
    /// 每人可核销的数量限制,不填写默认为50
    /// </summary>
    [JsonPropertyName("use_limit")]
    public int? UseLimit { get; set; }

    /// <summary>
    /// 卡券领取页面是否可分享。
    /// </summary>
    [JsonPropertyName("can_share")]
    public bool? CanShare { get; set; }

    /// <summary>
    /// 卡券是否可转赠
    /// </summary>
    [JsonPropertyName("can_give_friend")]
    public bool? CanGiveFriend { get; set; }

    #endregion
}
