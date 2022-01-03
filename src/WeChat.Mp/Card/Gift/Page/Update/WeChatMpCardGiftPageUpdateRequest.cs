namespace WeChat.Mp.Card;

/// <summary>
/// 【卡券】修改礼品卡货架信息
/// <a href="https://developers.weixin.qq.com/doc/offiaccount/Cards_and_Offer/gift_card.html#_7-4-%E4%BF%AE%E6%94%B9-%E7%A4%BC%E5%93%81%E5%8D%A1%E8%B4%A7%E6%9E%B6%E4%BF%A1%E6%81%AF%E6%8E%A5%E5%8F%A3"></a>
/// </summary>
/// <remarks>
/// 开发者可以通过该接口更新礼品卡货架信息
/// </remarks>
public class WeChatMpCardGiftPageUpdateRequest
    : WeChatHttpRequest<WeChatHttpResponse>
    , IHasAccessToken
{
    public static string Endpoint = "/card/giftcard/page/update?access_token={access_token}";

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpCardGiftPageUpdateRequest"/>
    /// </summary>
    public WeChatMpCardGiftPageUpdateRequest()
        : base(HttpMethod.Post)
    {
        Themes = new();
        Categories = new();
    }

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpCardGiftPageUpdateRequest"/>
    /// </summary>
    /// <param name="pageId">要修改的货架id</param>
    /// <param name="bannerPicUrl">礼品卡货架主题页顶部banner图片，须先将图片上传至CDN，建议尺寸为750px*630px</param>
    /// <param name="themes">主题</param>
    /// <param name="categories">主题分类</param>
    /// <param name="address">商家地址</param>
    /// <param name="servicePhone">商家服务电话</param>
    /// <param name="bizDescription">商家使用说明，用于描述退款、发票等流程</param>
    /// <param name="cell1">商家自定义链接，用于承载退款、发票等流程</param>
    /// <param name="cell2">商家自定义链接，用于承载退款、发票等流程</param>
    /// <param name="accessToken"></param>
    public WeChatMpCardGiftPageUpdateRequest(
        string pageId,
        string bannerPicUrl,
        List<CardGiftTheme> themes,
        List<CardGiftThemeCategory> categories,
        string address,
        string servicePhone,
        string bizDescription,
        CardGiftCell cell1,
        CardGiftCell cell2,
        string? accessToken = default)
        : base(HttpMethod.Post)
    {
        AccessToken = accessToken;
        PageId = pageId;
        BannerPicUrl = bannerPicUrl;
        Themes = themes;
        Categories = categories;
        Address = address;
        ServicePhone = servicePhone;
        BizDescription = bizDescription;
        Cell1 = cell1;
        Cell2 = cell2;
    }

    [JsonIgnore]
    public string? AccessToken { get; set; }

    /// <summary>
    /// 要修改的货架id
    /// </summary>
    [JsonPropertyName("pagg_id")]
    public string PageId { get; set; }

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