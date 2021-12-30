namespace WeChat.Mp.Card;

/// <summary>
/// 【卡券】创建货架
/// <a href="https://developers.weixin.qq.com/doc/offiaccount/Cards_and_Offer/Distributing_Coupons_Vouchers_and_Cards.html#3"></a>
/// </summary>
/// <remarks>
/// 开发者需调用该接口创建货架链接，用于卡券投放。
/// 创建货架时需填写投放路径的场景字段
/// </remarks>
public class WeChatMpCardLandingPageRequest
    : WeChatHttpRequest<WeChatMpCardLandingPageResponse>
    , IHasAccessToken
{
    public static string Endpoint = "/card/landingpage/create?access_token={access_token}";

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpCardLandingPageRequest"/>
    /// </summary>
    public WeChatMpCardLandingPageRequest()
        : base(HttpMethod.Post)
    {
        Cards = new();
    }

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpCardLandingPageRequest"/>
    /// </summary>
    /// <param name="banner">
    /// 页面的banner图片链接，建议尺寸为640*300。
    /// <para>
    /// 须使用 <see cref="Media.WeChatMpMediaUploadImgRequest"/> 获取的图片链接
    /// </para>
    /// </param>
    /// <param name="title">页面的title</param>
    /// <param name="canShare">页面是否可以分享</param>
    /// <param name="scene">投放页面的场景值（<see cref="CardLandingPageScenes"/>）</param>
    /// <param name="cards">卡券列表</param>
    public WeChatMpCardLandingPageRequest(
        string banner,
        string title,
        bool canShare,
        string scene,
        params CardLandingPageModel[] cards)
        : base(HttpMethod.Post)
    {
        Banner = banner;
        Title = title;
        CanShare = canShare;
        Scene = scene;
        Cards = new(cards);
    }

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpCardLandingPageRequest"/>
    /// </summary>
    /// <param name="banner">
    /// 页面的banner图片链接，建议尺寸为640*300。
    /// <para>
    /// 须使用 <see cref="Media.WeChatMpMediaUploadImgRequest"/> 获取的图片链接
    /// </para>
    /// </param>
    /// <param name="title">页面的title</param>
    /// <param name="canShare">页面是否可以分享</param>
    /// <param name="scene">投放页面的场景值（<see cref="CardLandingPageScenes"/>）</param>
    /// <param name="accessToken"></param>
    /// <param name="cards">卡券列表</param>
    public WeChatMpCardLandingPageRequest(
        string banner,
        string title,
        bool canShare,
        string scene,
        string accessToken,
        params CardLandingPageModel[] cards)
        : base(HttpMethod.Post)
    {
        AccessToken = accessToken;
        Banner = banner;
        Title = title;
        CanShare = canShare;
        Scene = scene;
        Cards = new(cards);
    }

    [JsonIgnore]
    public string? AccessToken { get; set; }

    /// <summary>
    /// 页面的banner图片链接，建议尺寸为640*300
    /// </summary>
    /// <remarks>
    /// 须使用 <see cref="Media.WeChatMpMediaUploadImgRequest"/> 获取的图片链接
    /// </remarks>
    [JsonPropertyName("banner")]
    public string Banner { get; set; }

    /// <summary>
    /// 页面的title
    /// </summary>
    [JsonPropertyName("title")]
    public string Title { get; set; }

    /// <summary>
    /// 页面是否可以分享
    /// </summary>
    [JsonPropertyName("can_share")]
    public bool CanShare { get; set; }

    /// <summary>
    /// 投放页面的场景值（<see cref="CardLandingPageScenes"/>）
    /// </summary>
    /// <value>
    /// SCENE_NEAR_BY：附近；
    /// SCENE_MENU：自定义菜单；
    /// SCENE_QRCODE：二维码；
    /// SCENE_ARTICLE：公众号文章；
    /// SCENE_H5：h5页面；
    /// SCENE_IVR：自动回复；
    /// SCENE_CARD_CUSTOM_CELL：卡券自定义cell
    /// </value>
    [JsonPropertyName("scene")]
    public string Scene { get; set; }

    /// <summary>
    /// 卡券列表
    /// </summary>
    [JsonPropertyName("card_list")]
    public List<CardLandingPageModel> Cards { get; set; }

    protected override string GetRequestUri() => $"{WeChatProperties.Domain}{Endpoint}"
        .Replace("{access_token}", AccessToken);
}
