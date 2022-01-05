namespace WeChat.Mp.Poi;

/// <summary>
/// 【门店】获取门店类目
/// <a href="https://developers.weixin.qq.com/doc/offiaccount/WeChat_Stores/WeChat_Store_Interface.html#13"></a>
/// </summary>
/// <remarks>
/// 类目名称接口是为商户提供自己门店类型信息的接口。门店类目定位的越规范，能够精准的吸引更多用户，提高曝光率
/// </remarks>
public class WeChatMpPoiCategoryRequest
    : WeChatHttpRequest<WeChatMpPoiCategoryResponse>
    , IHasAccessToken
{
    public static string Endpoint = "/cgi-bin/poi/addpoi?access_token={access_token}&media_id={media_id}";

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpPoiCategoryRequest"/>
    /// </summary>
    /// <param name="accessToken"></param>
    public WeChatMpPoiCategoryRequest(string? accessToken = default)
    {
        AccessToken = accessToken;
    }

    /// <inheritdoc/>
    [JsonIgnore]
    public string? AccessToken { get; set; }

    protected override string GetRequestUri() => $"{WeChatProperties.Domain}{Endpoint}"
        .Replace("{access_token}", AccessToken);
}