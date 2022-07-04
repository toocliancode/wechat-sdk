namespace WeChat.Applet.Checks;

/// <summary>
/// <b>[security.mediaCheckAsync]</b>
/// 异步校验图片/音频是否含有违法违规内容。
/// <a href="https://developers.weixin.qq.com/miniprogram/dev/api-backend/open-api/sec-check/security.mediaCheckAsync.html"></a>
/// </summary>
public class WeChatAppletMediaCheckAsyncRequest
    : WeChatHttpRequest<WeChatAppletMediaCheckAsyncResponse>
    , IHasAccessToken
{

    public static string Endpoint = "/wxa/media_check_async?access_token={access_token}";

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatAppletMediaCheckAsyncRequest"/>
    /// </summary>
    public WeChatAppletMediaCheckAsyncRequest()
    : base(HttpMethod.Post)
    {
    }

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatAppletMediaCheckAsyncRequest"/>
    /// </summary>
    /// <param name="mediaUrl">要检测的图片或音频的url，支持图片格式包括 jpg , jepg, png, bmp, gif（取首帧），支持的音频格式包括mp3, aac, ac3, wma, flac, vorbis, opus, wav</param>
    /// <param name="mediaType">1:音频;2:图片</param>
    /// <param name="openId">用户的openid（用户需在近两小时访问过小程序）</param>
    /// <param name="scene">场景枚举值（1 资料；2 评论；3 论坛；4 社交日志）</param>
    /// <param name="accessToken">自定义token</param>
    public WeChatAppletMediaCheckAsyncRequest(
        string mediaUrl,
        int mediaType,
        string openId,
        int scene,
        string? accessToken = default)
        : this()
    {
        MediaUrl = mediaUrl;
        MediaType = mediaType;
        OpenId = openId;
        Scene = scene;
        AccessToken = accessToken;
    }

    /// <inheritdoc/>
    [JsonIgnore]
    public string? AccessToken { get; set; }

    /// <summary>
    /// 要检测的图片或音频的url，支持图片格式包括 jpg , jepg, png, bmp, gif（取首帧），支持的音频格式包括mp3, aac, ac3, wma, flac, vorbis, opus, wav
    /// </summary>
    [JsonPropertyName("media_url")]
    public string MediaUrl { get; set; }

    /// <summary>
    /// 1:音频;2:图片
    /// </summary>
    [JsonPropertyName("media_type")]
    public int MediaType { get; set; }

    /// <summary>
    /// 接口版本号，2.0版本为固定值2
    /// </summary>
    [JsonPropertyName("version")]
    public int Version { get; set; } = 2;

    /// <summary>
    /// 用户的openid（用户需在近两小时访问过小程序）
    /// </summary>
    [JsonPropertyName("openid")]
    public string OpenId { get; set; }

    /// <summary>
    /// 场景枚举值（1 资料；2 评论；3 论坛；4 社交日志）
    /// </summary>
    [JsonPropertyName("scene")]
    public int Scene { get; set; }

    protected override string GetRequestUri()
            => $"{WeChatProperties.Domain}{Endpoint}"
            .Replace("{access_token}", AccessToken);
}