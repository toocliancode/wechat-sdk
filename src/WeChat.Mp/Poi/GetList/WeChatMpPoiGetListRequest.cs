namespace WeChat.Mp.Poi;

/// <summary>
/// 【门店】查询门店列表
/// <a href="https://developers.weixin.qq.com/doc/offiaccount/WeChat_Stores/WeChat_Store_Interface.html#10"></a>
/// </summary>
/// <remarks>
/// 商户可以通过该接口，批量查询自己名下的门店list，并获取已审核通过的poiid、商户自身sid 用于对应、商户名、分店名、地址字段
/// </remarks>
public class WeChatMpPoiGetListRequest
    : WeChatHttpRequest<WeChatMpPoiGetListResponse>
    , IHasAccessToken
{
    public static string Endpoint = "/cgi-bin/poi/getpoilist?access_token={access_token}&media_id={media_id}";

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpPoiGetListRequest"/>
    /// </summary>
    public WeChatMpPoiGetListRequest()
        : base(HttpMethod.Post)
    {

    }

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpPoiGetListRequest"/>
    /// </summary>
    /// <param name="begin">开始位置，0 即为从第一条开始查询</param>
    /// <param name="limit">返回数据条数，最大允许50，默认为20</param>
    /// <param name="accessToken"></param>
    public WeChatMpPoiGetListRequest(
        int begin,
        int? limit = default,
        string? accessToken = default)
         : base(HttpMethod.Post)
    {
        AccessToken = accessToken;
        Begin = begin;
        Limit = limit;
    }

    /// <inheritdoc/>
    [JsonIgnore]
    public string? AccessToken { get; set; }

    /// <summary>
    /// 开始位置，0 即为从第一条开始查询
    /// </summary>
    [JsonPropertyName("begin")]
    public int Begin { get; set; }

    /// <summary>
    /// 返回数据条数，最大允许50，默认为20
    /// </summary>
    [JsonPropertyName("limit")]
    public int? Limit { get; set; }

    protected override string GetRequestUri() => $"{WeChatProperties.Domain}{Endpoint}"
        .Replace("{access_token}", AccessToken);
}