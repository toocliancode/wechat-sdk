namespace WeChat.Mp.Poi;

public class PoiBaseInfo
{
    /// <summary>
    /// 门店Id，只有审核通过（<see cref="AvailableState"/> = 3）才有值
    /// </summary>
    [JsonPropertyName("poi_id")]
    public string? PoiId { get; set; }

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

    /// <summary>
    /// 门店是否可用状态。
    /// 当该字段为1、2、4 状态时，poi_id 为空
    /// </summary>
    /// <value>
    /// 1：系统错误；
    /// 2：表示审核中；
    /// 3：审核通过；
    /// 4：审核驳回
    /// </value>
    [JsonPropertyName("available_state")]
    public int AvailableState { get; set; }

    /// <summary>
    /// 扩展字段是否正在更新中
    /// </summary>
    /// <value>
    /// 1：扩展字段正在更新中，尚未生效，不允许再次更新；
    /// 0：扩展字段没有在更新中或更新已生效，可以再次更新
    /// </value>
    [JsonPropertyName("update_status")]
    public int UpdateStatus { get; set; }
}