namespace WeChat.Applet.Checks;

/// <summary>
/// <b>[security.msgSecCheck-v1]</b>
/// 文本安全内容检测接口
/// <a href="https://developers.weixin.qq.com/miniprogram/dev/framework/security.msgSecCheck-v1.html"></a>
/// </summary>
public class WeChatAppletMsgSecCheckV1Request
    : WeChatHttpRequest<WeChatAppletMsgSecCheckV1Response>
    , IHasAccessToken
{
    public static string Endpoint = "/wxa/msg_sec_check?access_token={access_token}";

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatAppletMsgSecCheckV1Request"/>
    /// </summary>
    /// <param name="content"></param>
    /// <param name="accessToken"></param>
    public WeChatAppletMsgSecCheckV1Request(
        string content,
        string? accessToken = default)
        : base(HttpMethod.Post)
    {
        Content = content;
        AccessToken = accessToken;
    }

    /// <inheritdoc/>
    [JsonIgnore]
    public string? AccessToken { get; set; }

    [JsonPropertyName("content")]
    public string Content { get; set; }

    protected override string GetRequestUri()
        => $"{WeChatProperties.Domain}{Endpoint}"
        .Replace("{access_token}", AccessToken);
}