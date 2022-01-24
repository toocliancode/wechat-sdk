namespace WeChat.Mp.Poi;

/// <summary>
/// 【门店】查询门店信息
/// <a href="https://developers.weixin.qq.com/doc/offiaccount/WeChat_Stores/WeChat_Store_Interface.html#9"></a>
/// </summary>
/// <remarks>
/// 创建门店后获取poi_id 后，商户可以利用poi_id，查询具体某条门店的信息。
/// 若在查询时，update_status 字段为1，表明在5个工作日内曾用update接口修改过门店扩展字段，该扩展字段为最新的修改字段，尚未经过审核采纳，因此不是最终结果。
/// 最终结果会在5 个工作日内，最终确认是否采纳，并前端生效（但该扩展字段的采纳过程不影响门店的可用性，即available_state仍为审核通过状态）
/// </remarks>
public class WeChatMpPoiGetRequest
    : WeChatHttpRequest<WeChatMpPoiGetResponse>
    , IHasAccessToken
{
    public static string Endpoint = "/cgi-bin/poi/getpoi?access_token={access_token}&media_id={media_id}";

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpPoiGetRequest"/>
    /// </summary>
    public WeChatMpPoiGetRequest()
        : base(HttpMethod.Post)
    {

    }

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpPoiGetRequest"/>
    /// </summary>
    /// <param name="poiId">门店Id</param>
    /// <param name="accessToken"></param>
    public WeChatMpPoiGetRequest(string poiId, string? accessToken = default)
         : base(HttpMethod.Post)
    {
        AccessToken = accessToken;
        PoiId = poiId;
    }

    /// <inheritdoc/>
    [JsonIgnore]
    public string? AccessToken { get; set; }

    /// <summary>
    /// 门店Id
    /// </summary>
    [JsonPropertyName("poi_id")]
    public string PoiId { get; set; }

    protected override string GetRequestUri() => $"{WeChatProperties.Domain}{Endpoint}"
        .Replace("{access_token}", AccessToken);
}