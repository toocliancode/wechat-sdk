namespace WeChat.Applet.Checks;

/// <summary>
/// <b>[security.msgSecCheck]</b>
/// 检查一段文本是否含有违法违规内容
/// <a href="https://developers.weixin.qq.com/miniprogram/dev/api-backend/open-api/sec-check/security.msgSecCheck.html"></a>
/// </summary>
public class WeChatAppletMsgSecCheckRequest
: WeChatHttpRequest<WeChatAppletMsgSecCheckResponse>
, IHasAccessToken
{
    public static string Endpoint = "/wxa/msg_sec_check?access_token={access_token}";

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatAppletMsgSecCheckRequest"/>
    /// </summary>
    public WeChatAppletMsgSecCheckRequest()
    : base(HttpMethod.Post)
    {
    }

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatAppletMsgSecCheckRequest"/>
    /// </summary>
    /// <param name="openId">用户的openid（用户需在近两小时访问过小程序）</param>
    /// <param name="scene">场景枚举值（1 资料；2 评论；3 论坛；4 社交日志）</param>
    /// <param name="content">需检测的文本内容，文本字数的上限为2500字，需使用UTF-8编码</param>
    /// <param name="nickName">用户昵称，需使用UTF-8编码</param>
    /// <param name="title">文本标题，需使用UTF-8编码</param>
    /// <param name="signature">个性签名，该参数仅在资料类场景有效(scene=1)，需使用UTF-8编码</param>
    /// <param name="accessToken">自定义token</param>
    public WeChatAppletMsgSecCheckRequest(
        string openId,
        int scene,
        string content,
        string? nickName = default,
        string? title = default,
        string? signature = default,
        string? accessToken = default)
        : this()
    {
        OpenId = openId;
        Scene = scene;
        Content = content;
        NickName = nickName;
        Title = title;
        Signature = signature;
        AccessToken = accessToken;
    }

    /// <inheritdoc/>
    [JsonIgnore]
    public string? AccessToken { get; set; }

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

    /// <summary>
    /// 需检测的文本内容，文本字数的上限为2500字，需使用UTF-8编码
    /// </summary>
    [JsonPropertyName("content")]
    public string Content { get; set; }

    /// <summary>
    /// 用户昵称，需使用UTF-8编码
    /// </summary>
    [JsonPropertyName("nickname")]
    public string? NickName { get; set; }

    /// <summary>
    /// 文本标题，需使用UTF-8编码
    /// </summary>
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    /// <summary>
    /// 个性签名，该参数仅在资料类场景有效(scene=1)，需使用UTF-8编码
    /// </summary>
    [JsonPropertyName("signature")]
    public string? Signature { get; set; }

    protected override string GetRequestUri()
            => $"{WeChatProperties.Domain}{Endpoint}"
            .Replace("{access_token}", AccessToken);
}