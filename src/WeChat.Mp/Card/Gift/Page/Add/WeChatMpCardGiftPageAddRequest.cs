namespace WeChat.Mp.Card;

/// <summary>
/// 【卡券】创建礼品卡货架
/// <a href="https://developers.weixin.qq.com/doc/offiaccount/Cards_and_Offer/gift_card.html"></a>
/// </summary>
public class WeChatMpCardGiftPageAddRequest
    : WeChatHttpRequest<WeChatMpCardGiftPageAddResponse>
    , IHasAccessToken
{
    public static string Endpoint = "/card/giftcard/page/get?access_token={access_token}";

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpCardGiftPageAddRequest"/>
    /// </summary>
    public WeChatMpCardGiftPageAddRequest()
        : base(HttpMethod.Post)
    {
        Themes = new();
        Categories = new();
    }

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpCardGiftPageAddRequest"/>
    /// </summary>
    /// <param name="pageTitle">礼品卡货架名称</param>
    /// <param name="supportMulti">是否支持一次购买多张及发送至群，填true或者false，若填true则支持，默认为false</param>
    /// <param name="supportBuyForSelf">礼品卡货架是否支持买给自己，填true或者false，若填true则支持，默认为false</param>
    /// <param name="bannerPicUrl">礼品卡货架主题页顶部banner图片，须先将图片上传至CDN，建议尺寸为750px*630px</param>
    /// <param name="themes">主题</param>
    /// <param name="categories">主题分类</param>
    /// <param name="address">商家地址</param>
    /// <param name="servicePhone">商家服务电话</param>
    /// <param name="bizDescription">商家使用说明，用于描述退款、发票等流程</param>
    /// <param name="needReceipt">该货架的订单是否支持开发票，填true或者false，若填true则需要调试文档2.2的流程，默认为false</param>
    /// <param name="cell1">商家自定义链接，用于承载退款、发票等流程</param>
    /// <param name="cell2">商家自定义链接，用于承载退款、发票等流程</param>
    /// <param name="accessToken"></param>
    public WeChatMpCardGiftPageAddRequest(
        string pageTitle,
        bool? supportMulti,
        bool? supportBuyForSelf,
        string bannerPicUrl,
        List<CardGiftTheme> themes,
        List<CardGiftThemeCategory> categories,
        string address,
        string servicePhone,
        string bizDescription,
        bool? needReceipt,
        CardGiftCell cell1,
        CardGiftCell cell2,
        string? accessToken = default)
    {
        AccessToken = accessToken;
        PageTitle = pageTitle;
        SupportMulti = supportMulti;
        SupportBuyForSelf = supportBuyForSelf;
        BannerPicUrl = bannerPicUrl;
        Themes = themes;
        Categories = categories;
        Address = address;
        ServicePhone = servicePhone;
        BizDescription = bizDescription;
        NeedReceipt = needReceipt;
        Cell1 = cell1;
        Cell2 = cell2;
    }

    [JsonIgnore]
    public string? AccessToken { get; set; }

    /// <summary>
    /// 礼品卡货架名称
    /// </summary>
    [JsonPropertyName("page_title")]
    public string PageTitle { get; set; }

    /// <summary>
    /// 是否支持一次购买多张及发送至群，填true或者false，若填true则支持，默认为false
    /// </summary>
    [JsonPropertyName("support_multi")]
    public bool? SupportMulti { get; set; }

    /// <summary>
    /// 礼品卡货架是否支持买给自己，填true或者false，若填true则支持，默认为false
    /// </summary>
    [JsonPropertyName("support_buy_for_self")]
    public bool? SupportBuyForSelf { get; set; }

    /// <summary>
    /// 礼品卡货架主题页顶部banner图片，须先将图片上传至CDN，建议尺寸为750px*630px
    /// </summary>
    [JsonPropertyName("banner_pic_url")]
    public string BannerPicUrl { get; set; }

    /// <summary>
    /// 主题
    /// </summary>
    [JsonPropertyName("theme_list")]
    public List<CardGiftTheme> Themes { get; set; }

    /// <summary>
    /// 主题分类列表
    /// </summary>
    [JsonPropertyName("category_list")]
    public List<CardGiftThemeCategory> Categories { get; set; }

    /// <summary>
    /// 商家地址
    /// </summary>
    [JsonPropertyName("address")]
    public string Address { get; set; }

    /// <summary>
    /// 商家服务电话
    /// </summary>
    [JsonPropertyName("service_phone")]
    public string ServicePhone { get; set; }

    /// <summary>
    /// 商家使用说明，用于描述退款、发票等流程
    /// </summary>
    [JsonPropertyName("biz_description")]
    public string BizDescription { get; set; }

    /// <summary>
    /// 该货架的订单是否支持开发票，填true或者false，若填true则需要调试文档2.2的流程，默认为false
    /// </summary>
    [JsonPropertyName("need_receipt")]
    public bool? NeedReceipt { get; set; }

    /// <summary>
    /// 商家自定义链接，用于承载退款、发票等流程
    /// </summary>
    [JsonPropertyName("cell_1")]
    public CardGiftCell Cell1 { get; set; }

    /// <summary>
    /// 商家自定义链接，用于承载退款、发票等流程
    /// </summary>
    [JsonPropertyName("cell_2")]
    public CardGiftCell Cell2 { get; set; }

    protected override string GetRequestUri() => $"{WeChatProperties.Domain}{Endpoint}"
        .Replace("{access_token}", AccessToken);

    protected override async Task<HttpContent?> GetContent()
    {
        await Task.CompletedTask;

        var body = new WeChatDictionary<object>
        {
            ["page"] = this
        };
        return new StringContent(JsonSerializer.Serialize(body, JsonSerializerOptions));
    }
}
