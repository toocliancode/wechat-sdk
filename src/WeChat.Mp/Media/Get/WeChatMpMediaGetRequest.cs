﻿
using Mediation.HttpClient;

namespace WeChat.Mp.Media;

/// <summary>
/// 获取临时素材 请求
/// 
/// https://developers.weixin.qq.com/doc/offiaccount/Asset_Management/Get_temporary_materials.html
/// </summary>
public class WeChatMpMediaGetRequest
    : WeChatHttpRequest<WeChatMpMediaGetResponse>
    , IHasAccessToken
{
    public static string Endpoint = "/cgi-bin/media/get?access_token={access_token}&media_id={media_id}";

    /// <summary>
    /// 实例化一个新的 获取临时素材 请求
    /// </summary>
    /// <param name="mediaId">媒体文件Id</param>
    /// <param name="accessToken">微信API access_token</param>
    public WeChatMpMediaGetRequest(string mediaId, string? accessToken = default)
    {
        AccessToken = accessToken;
        MediaId = mediaId;
    }

    /// <inheritdoc/>
    [JsonIgnore]
    public string? AccessToken { get; set; }

    /// <summary>
    /// 媒体文件Id
    /// </summary>
    [JsonPropertyName("media_id")]
    public string MediaId { get; set; }

    protected override string GetRequestUri()
        => $"{WeChatProperties.Domain}{Endpoint}"
            .Replace("{access_token}", AccessToken)
            .Replace("{media_id}", MediaId);

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