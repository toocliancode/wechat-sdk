namespace WeChat.Mp.Poi;

/// <summary>
/// 【门店】创建门店
/// <a href="https://developers.weixin.qq.com/doc/offiaccount/WeChat_Stores/WeChat_Store_Interface.html#7"></a>
/// </summary>
/// <remarks>
/// 创建门店接口是为商户提供创建自己门店数据的接口，门店数据字段越完整，商户页面展示越丰富，越能够吸引更多用户，并提高曝光度
/// </remarks>
public class WeChatMpPoiAddRequest
    : WeChatHttpRequest<WeChatMpPoiAddResponse>
    , IHasAccessToken
{
    public static string Endpoint = "/cgi-bin/poi/addpoi?access_token={access_token}&media_id={media_id}";

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpPoiAddRequest"/>
    /// </summary>
    public WeChatMpPoiAddRequest()
        : base(HttpMethod.Post)
    {

    }

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpPoiAddRequest"/>
    /// </summary>
    /// <param name="businessName">门店名称（仅为商户名，如：国美、麦当劳，不应包含地区、地址、分店名等信息，错误示例：北京国美） 不能为空，15个汉字或30个英文字符内</param>
    /// <param name="branchName">分店名称（不应包含地区信息，不应与门店名有重复，错误示例：北京王府井店） 20 个字 以内</param>
    /// <param name="province">门店所在的省份（直辖市填城市名,如：北京 市） 10个字 以内</param>
    /// <param name="city">门店所在的城市 10个字 以内</param>
    /// <param name="district">门店所在地区 10个字 以内</param>
    /// <param name="address">门店所在的详细街道地址（不要填写省市信息）</param>
    /// <param name="telephone">门店的电话（纯数字，区号、分机号均由“-”隔开）</param>
    /// <param name="categories">门店的类型（不同级分类用“,”隔开，如：美食，川菜，火锅。详细分类参见附件：微信门店类目表）</param>
    /// <param name="offsetType">坐标类型： 1 为火星坐标 2 为sogou经纬度 3 为百度经纬度 4 为mapbar经纬度 5 为GPS坐标 6 为sogou墨卡托坐标 注：高德经纬度无需转换可直接使用</param>
    /// <param name="longitude">门店所在地理位置的经度</param>
    /// <param name="latitude">门店所在地理位置的纬度（经纬度均为火星坐标，最好选用腾讯地图标记的坐标）</param>
    /// <param name="sid">商户自己的id，用于后续审核通过收到poi_id 的通知时，做对应关系。请商户自己保证唯一识别性</param>
    /// <param name="photos">图片列表，url 形式，可以有多张图片，尺寸为 640*340px。必须为上一接口生成的url。 图片内容不允许与门店不相关，不允许为二维码、员工合照（或模特肖像）、营业执照、无门店正门的街景、地图截图、公交地铁站牌、菜单截图等</param>
    /// <param name="recommend">推荐品，餐厅可为推荐菜；酒店为推荐套房；景点为推荐游玩景点等，针对自己行业的推荐内容 200字以内</param>
    /// <param name="special">特色服务，如免费wifi，免费停车，送货上门等商户能提供的特色功能或服务</param>
    /// <param name="introduction">商户简介，主要介绍商户信息等 300字以内</param>
    /// <param name="openTime">营业时间，24 小时制表示，用“-”连接，如 8:00-20:00</param>
    /// <param name="avgPrice">人均价格，大于0 的整数</param>
    /// <param name="accessToken"></param>
    public WeChatMpPoiAddRequest(
        string businessName,
        string branchName,
        string province,
        string city,
        string district,
        string address,
        string telephone,
        List<string> categories,
        int offsetType,
        double longitude,
        double latitude,
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
        BusinessName = businessName;
        BranchName = branchName;
        Province = province;
        City = city;
        District = district;
        Address = address;
        Telephone = telephone;
        Categories = categories;
        OffsetType = offsetType;
        Longitude = longitude;
        Latitude = latitude;
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
    /// 商户自己的id，用于后续审核通过收到poi_id 的通知时，做对应关系。请商户自己保证唯一识别性
    /// </summary>
    /// <remarks>
    /// 示例值："33788392"
    /// </remarks>
    [JsonPropertyName("sid")]
    public string? Sid { get; set; }

    /// <summary>
    /// 门店名称（仅为商户名，如：国美、麦当劳，不应包含地区、地址、分店名等信息，错误示例：北京国美） 不能为空，15个汉字或30个英文字符内
    /// </summary>
    [JsonPropertyName("business_name")]
    public string BusinessName { get; set; }

    /// <summary>
    /// 分店名称（不应包含地区信息，不应与门店名有重复，错误示例：北京王府井店） 20 个字 以内
    /// </summary>
    [JsonPropertyName("branch_name")]
    public string BranchName { get; set; }

    /// <summary>
    /// 门店所在的省份（直辖市填城市名,如：北京 市） 10个字 以内
    /// </summary>
    [JsonPropertyName("province")]
    public string Province { get; set; }

    /// <summary>
    /// 门店所在的城市 10个字 以内
    /// </summary>
    [JsonPropertyName("city")]
    public string City { get; set; }

    /// <summary>
    /// 门店所在地区 10个字 以内
    /// </summary>
    [JsonPropertyName("district")]
    public string District { get; set; }

    /// <summary>
    /// 门店所在的详细街道地址（不要填写省市信息）
    /// </summary>
    [JsonPropertyName("address")]
    public string Address { get; set; }

    /// <summary>
    /// 门店的电话（纯数字，区号、分机号均由“-”隔开）
    /// </summary>
    [JsonPropertyName("telephone")]
    public string Telephone { get; set; }

    /// <summary>
    /// 门店的类型（不同级分类用“,”隔开，如：美食，川菜，火锅。详细分类参见附件：微信门店类目表）
    /// </summary>
    /// <remarks>
    /// 示例值：["美食,小吃快餐"]
    /// </remarks>
    [JsonPropertyName("categories")]
    public List<string> Categories { get; set; }

    /// <summary>
    /// 坐标类型
    /// </summary>
    /// <value>
    /// 1：火星坐标；
    /// 2：sogou经纬度；
    /// 3：百度经纬度；
    /// 4：mapbar经纬度；
    /// 5：GPS坐标；
    /// 6：sogou墨卡托坐标 注：高德经纬度无需转换可直接使用
    /// </value>
    [JsonPropertyName("offset_type")]
    public int OffsetType { get; set; }

    /// <summary>
    /// 门店所在地理位置的经度
    /// </summary>
    [JsonPropertyName("longitude")]
    public double Longitude { get; set; }

    /// <summary>
    /// 门店所在地理位置的纬度（经纬度均为火星坐标，最好选用腾讯地图标记的坐标）
    /// </summary>
    [JsonPropertyName("latitude")]
    public double Latitude { get; set; }

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

    protected override async Task<HttpContent?> GetContent()
    {
        await Task.CompletedTask;

        var body = new WeChatDictionary<object>
        {
            ["business"] = new
            {
                base_info = this
            }
        };
        var json = JsonSerializer.Serialize(body, JsonSerializerOptions);
        return new StringContent(json);
    }
}
