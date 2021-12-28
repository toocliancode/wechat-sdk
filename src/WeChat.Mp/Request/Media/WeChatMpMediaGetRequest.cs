
using Mediator.HttpClient;

using System.Text.Json;
using System.Text.Json.Serialization;

namespace WeChat.Mp.Media;

/// <summary>
/// 获取临时素材 请求
/// 
/// https://developers.weixin.qq.com/doc/offiaccount/Asset_Management/Get_temporary_materials.html
/// </summary>
public class WeChatMpMediaGetRequest
    : WeChatHttpRequest<WeChatMpMediaGetResponse>
{
    public static string Endpoint = "https://api.weixin.qq.com/cgi-bin/media/get";

    /// <summary>
    /// 实例化一个新的 获取临时素材 请求
    /// </summary>
    /// <param name="accessToken">微信API access_token</param>
    /// <param name="mediaId">媒体文件Id</param>
    public WeChatMpMediaGetRequest(string accessToken, string mediaId)
    {
        AccessToken = accessToken;
        MediaId = mediaId;
    }

    /// <summary>
    /// 微信API access_token
    /// </summary>
    [JsonIgnore]
    public string AccessToken { get; set; }

    /// <summary>
    /// 媒体文件Id
    /// </summary>
    [JsonPropertyName("media_id")]
    public string MediaId { get; set; }

    protected override string GetRequestUri()
    {
        var body = new Dictionary<string, string>
        {
            ["access_token"] = AccessToken,
            ["media_id"] = MediaId,
        };

        return $"{Endpoint}?{HttpUtility.ToQuery(body)}";
    }

    public override async Task<WeChatMpMediaGetResponse> Response(IHttpResponseContext context)
    {
        var content = await context.Message.Content.ReadAsByteArrayAsync();
        var response = JsonSerializer.Deserialize<WeChatMpMediaGetResponse>(content) ?? new();

        response.Raw = content;
        response.StatusCode = context.Message.StatusCode;
        response.ContentType = context.Message.Content?.Headers?.ContentType?.MediaType;
        return response;
    }
}
