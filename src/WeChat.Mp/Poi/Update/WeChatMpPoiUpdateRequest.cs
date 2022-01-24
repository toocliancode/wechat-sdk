namespace WeChat.Mp.Poi;

/// <summary>
/// 【门店】修改门店服务信息
/// <a href="https://developers.weixin.qq.com/doc/offiaccount/WeChat_Stores/WeChat_Store_Interface.html#11"></a>
/// </summary>
/// <remarks>
/// 商户可以通过该接口，修改门店的服务信息，包括：sid、图片列表、营业时间、推荐、特色服务、简介、人均价格、电话8个字段（名称、坐标、地址等不可修改）修改后需要人工审核
/// </remarks>
public class WeChatMpPoiUpdateRequest
    : WeChatHttpRequest<WeChatHttpResponse>
    , IHasAccessToken
{
    public static string Endpoint = "/cgi-bin/poi/updatepoi?access_token={access_token}&media_id={media_id}";

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpPoiUpdateRequest"/>
    /// </summary>
    public WeChatMpPoiUpdateRequest()
        : base(HttpMethod.Post)
    {

    }

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpPoiUpdateRequest"/>
    /// </summary>
    /// <param name="poiId">门店Id</param>
    /// <param name="telephone">门店的电话（纯数字，区号、分机号均由“-”隔开）</param>
    /// <param name="sid">商户自己的id，用于后续审核通过收到poi_id 的通知时，做对应关系。请商户自己保证唯一识别性</param>
    /// <param name="photos">图片列表，url 形式，可以有多张图片，尺寸为 640*340px。必须为上一接口生成的url。 图片内容不允许与门店不相关，不允许为二维码、员工合照（或模特肖像）、营业执照、无门店正门的街景、地图截图、公交地铁站牌、菜单截图等</param>
    /// <param name="recommend">推荐品，餐厅可为推荐菜；酒店为推荐套房；景点为推荐游玩景点等，针对自己行业的推荐内容 200字以内</param>
    /// <param name="special">特色服务，如免费wifi，免费停车，送货上门等商户能提供的特色功能或服务</param>
    /// <param name="introduction">商户简介，主要介绍商户信息等 300字以内</param>
    /// <param name="openTime">营业时间，24 小时制表示，用“-”连接，如 8:00-20:00</param>
    /// <param name="avgPrice">人均价格，大于0 的整数</param>
    /// <param name="accessToken"></param>
    public WeChatMpPoiUpdateRequest(
        string poiId,
        string? telephone = default,
        string? sid = default,
        List<PoiPhoto>? photos = default,
        string? recommend = default,
        string? special = default,
        string? introduction = default,
        string? openTime = default,
        int? avgPrice = default,
        string? accessToken = default)
        : base(HttpMethod.Post)
    {
        AccessToken = accessToken;
        Sid = sid;
        PoiId = poiId;
        Telephone = telephone;
        Photos = photos;
        Recommend = recommend;
        Special = special;
        Introduction = introduction;
        OpenTime = openTime;
        AvgPrice = avgPrice;
    }

    /// <inheritdoc/>
    [JsonIgnore]
    public string? AccessToken { get; set; }

    /// <summary>
    /// 门店Id
    /// </summary>
    [JsonPropertyName("poi_id")]
    public string PoiId { get; set; }

    /// <summary>
    /// 商户自己的id，用于后续审核通过收到poi_id 的通知时，做对应关系。请商户自己保证唯一识别性
    /// </summary>
    /// <remarks>
    /// 示例值："33788392"
    /// </remarks>
    [JsonPropertyName("sid")]
    public string? Sid { get; set; }

    /// <summary>
    /// 门店的电话（纯数字，区号、分机号均由“-”隔开）
    /// </summary>
    [JsonPropertyName("telephone")]
    public string? Telephone { get; set; }

    /// <summary>
    /// 图片列表，url 形式，可以有多张图片，尺寸为 640*340px。必须为上一接口生成的url。 
    /// 图片内容不允许与门店不相关，不允许为二维码、员工合照（或模特肖像）、营业执照、无门店正门的街景、地图截图、公交地铁站牌、菜单截图等
    /// </summary>
    [JsonPropertyName("photo_list")]
    public List<PoiPhoto>? Photos { get; set; }

    /// <summary>
    /// 推荐品，餐厅可为推荐菜；酒店为推荐套房；景点为推荐游玩景点等，针对自己行业的推荐内容 200字以内
    /// </summary>
    [JsonPropertyName("recommend")]
    public string? Recommend { get; set; }

    /// <summary>
    /// 特色服务，如免费wifi，免费停车，送货上门等商户能提供的特色功能或服务
    /// </summary>
    [JsonPropertyName("special")]
    public string? Special { get; set; }

    /// <summary>
    /// 商户简介，主要介绍商户信息等 300字以内
    /// </summary>
    [JsonPropertyName("introduction")]
    public string? Introduction { get; set; }

    /// <summary>
    /// 营业时间，24 小时制表示，用“-”连接，如 8:00-20:00
    /// </summary>
    [JsonPropertyName("open_time")]
    public string? OpenTime { get; set; }

    /// <summary>
    /// 人均价格，大于0 的整数
    /// </summary>
    [JsonPropertyName("avg_price")]
    public int? AvgPrice { get; set; }

    protected override string GetRequestUri() => $"{WeChatProperties.Domain}{Endpoint}"
        .Replace("{access_token}", AccessToken);
}