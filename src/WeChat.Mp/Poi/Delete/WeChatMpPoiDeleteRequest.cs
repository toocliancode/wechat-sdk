namespace WeChat.Mp.Poi;

/// <summary>
/// 【门店】删除门店
/// <a href="https://developers.weixin.qq.com/doc/offiaccount/WeChat_Stores/WeChat_Store_Interface.html#12"></a>
/// </summary>
/// <remarks>
/// 商户可以通过该接口，删除已经成功创建的门店。请商户慎重调用该接口
/// </remarks>
public class WeChatMpPoiDeleteRequest
    : WeChatHttpRequest<WeChatHttpResponse>
    , IHasAccessToken
{

    public static string Endpoint = "/cgi-bin/poi/delpoi?access_token={access_token}&media_id={media_id}";

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpPoiDeleteRequest"/>
    /// </summary>
    public WeChatMpPoiDeleteRequest()
        : base(HttpMethod.Post)
    {

    }

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpPoiDeleteRequest"/>
    /// </summary>
    /// <param name="poiId">门店Id</param>
    /// <param name="accessToken"></param>
    public WeChatMpPoiDeleteRequest(string poiId, string? accessToken = default)
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