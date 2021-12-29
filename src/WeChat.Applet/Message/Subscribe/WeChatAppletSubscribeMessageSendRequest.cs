using System.Text.Json.Serialization;

namespace WeChat.Applet.Message;

/// <summary>
/// <b>[subscribeMessage.send]</b>
/// 发送订阅消息 请求
/// https://developers.weixin.qq.com/miniprogram/dev/api-backend/open-api/subscribe-message/subscribeMessage.send.html
/// </summary>
public class WeChatAppletSubscribeMessageSendRequest
    : WeChatHttpRequest<WeChatResponse>
    , IHasAccessToken
{
    public static string Endpoint = "https://api.weixin.qq.com/cgi-bin/message/subscribe/send";

    /// <inheritdoc/>
    [JsonIgnore]
    public string? AccessToken { get; set; }

    /// <summary>
    /// 接收者（用户）的 openid
    /// </summary>
    [JsonPropertyName("touser")]
    public string ToUser { get; set; }

    /// <summary>
    /// 所需下发的订阅模板id
    /// </summary>
    [JsonPropertyName("template_id")]
    public string TemplateId { get; set; }

    /// <summary>
    /// 点击模板卡片后的跳转页面，仅限本小程序内的页面。支持带参数,（示例index?foo=bar）。该字段不填则模板无跳转。
    /// </summary>
    [JsonPropertyName("page")]
    public string? Page { get; set; }

    /// <summary>
    /// 模板内容，格式形如 { "key1": { "value": any }, "key2": { "value": any } }
    /// </summary>
    [JsonPropertyName("data")]
    public IDictionary<string, IDictionary<string, string>> Data { get; set; }

    /// <summary>
    /// 跳转小程序类型：developer为开发版；trial为体验版；formal为正式版；默认为正式版
    /// </summary>
    [JsonPropertyName("miniprogram_state")]
    public string? MiniProgramState { get; set; }

    /// <summary>
    /// 进入小程序查看”的语言类型，支持zh_CN(简体中文)、en_US(英文)、zh_HK(繁体中文)、zh_TW(繁体中文)，默认为zh_CN
    /// </summary>
    [JsonPropertyName("lang")]
    public string? Lang { get; set; }

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatAppletSubscribeMessageSendRequest"/>
    /// </summary>
    public WeChatAppletSubscribeMessageSendRequest()
        : base(HttpMethod.Post)
    {

    }

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatAppletSubscribeMessageSendRequest"/>
    /// </summary>
    /// <param name="accessToken">微信API access_token</param>
    /// <param name="toUser">接收者（用户）的 openid</param>
    /// <param name="templateId">所需下发的订阅模板id</param>
    /// <param name="data"> 模板内容，格式形如 { "key1": { "value": any }, "key2": { "value": any } }</param>
    /// <param name="page">点击模板卡片后的跳转页面，仅限本小程序内的页面。支持带参数,（示例index?foo=bar）。该字段不填则模板无跳转。</param>
    /// <param name="miniProgramState">跳转小程序类型：developer为开发版；trial为体验版；formal为正式版；默认为正式版</param>
    /// <param name="lang">进入小程序查看”的语言类型，支持zh_CN(简体中文)、en_US(英文)、zh_HK(繁体中文)、zh_TW(繁体中文)，默认为zh_CN</param>
    public WeChatAppletSubscribeMessageSendRequest(
        string toUser,
        string templateId,
        IDictionary<string, IDictionary<string, string>> data,
        string? page,
        string? miniProgramState = default,
        string? lang = default,
        string? accessToken = default)
        : this()
    {
        AccessToken = accessToken;
        ToUser = toUser;
        TemplateId = templateId;
        Data = data;
        Page = page;
        MiniProgramState = miniProgramState;
        Lang = lang;
    }

    protected override string GetRequestUri()
    {
        return $"{Endpoint}?access_token={AccessToken}";
    }
}
