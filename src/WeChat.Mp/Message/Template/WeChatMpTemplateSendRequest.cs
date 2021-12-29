using System.Text.Json.Serialization;

namespace WeChat.Mp.Message;

/// <summary>
/// 发送模板消息
/// 
/// https://developers.weixin.qq.com/doc/offiaccount/Message_Management/Template_Message_Interface.html#5
/// </summary>
public class WeChatMpTemplateSendRequest
    : WeChatHttpRequest<WeChatMpTemplateSendResponse>
    , IHasAccessToken
{
    public static string Endpoint = "https://api.weixin.qq.com/cgi-bin/media/get";

    public WeChatMpTemplateSendRequest()
        : base(HttpMethod.Post)
    {
    }

    /// <summary>
    /// 实例化一个新的 发送模板消息 请求
    /// </summary>
    /// <param name="accessToken">微信API access_token</param>
    /// <param name="toUser">接收者openid</param>
    /// <param name="templateId">模板Id</param>
    /// <param name="appId">所需跳转到的小程序appid（该小程序appid必须与发模板消息的公众号是绑定关联关系，暂不支持小游戏）</param>
    /// <param name="url">模板跳转链接（海外帐号没有跳转能力）</param>
    /// <param name="data">
    /// 模板数据
    /// name:{
    ///     value:"",
    ///     color:""
    /// }
    /// </param>
    /// <param name="miniProgram">
    /// 跳小程序所需数据，不需跳小程序可不用传该数据
    /// appid:所需跳转到的小程序appid（该小程序appid必须与发模板消息的公众号是绑定关联关系，暂不支持小游戏）
    /// pagepath:所需跳转到小程序的具体页面路径，支持带参数,（示例index?foo=bar），要求该小程序已发布，暂不支持小游戏
    /// </param>
    /// <param name="pagePath">所需跳转到小程序的具体页面路径，支持带参数,（示例index?foo=bar），要求该小程序已发布，暂不支持小游戏</param>
    /// <param name="color">模板内容字体颜色，不填默认为黑色</param>
    public WeChatMpTemplateSendRequest(
        string toUser,
        string templateId,
        string appId,
        IDictionary<string, IDictionary<string, string>> data,
        string? url = default,
        IDictionary<string, string>? miniProgram = default,
        string? pagePath = default,
        string? color = default,
        string? accessToken = default)
        : this()
    {
        AccessToken = accessToken;
        ToUser = toUser;
        TemplateId = templateId;
        Url = url;
        MiniProgram = miniProgram;
        AppId = appId;
        PagePath = pagePath;
        Data = data;
        Color = color;
    }

    /// <inheritdoc/>
    [JsonIgnore]
    public string? AccessToken { get; set; }

    /// <summary>
    /// 接收者openid
    /// </summary>
    [JsonPropertyName("touser")]
    public string ToUser { get; set; }

    /// <summary>
    /// 模板Id
    /// </summary>
    [JsonPropertyName("template_id")]
    public string TemplateId { get; set; }

    /// <summary>
    /// 模板跳转链接（海外帐号没有跳转能力）
    /// </summary>
    [JsonPropertyName("url")]
    public string? Url { get; set; }

    /// <summary>
    /// 跳小程序所需数据，不需跳小程序可不用传该数据
    /// appid:所需跳转到的小程序appid（该小程序appid必须与发模板消息的公众号是绑定关联关系，暂不支持小游戏）
    /// pagepath:所需跳转到小程序的具体页面路径，支持带参数,（示例index?foo=bar），要求该小程序已发布，暂不支持小游戏
    /// </summary>
    [JsonPropertyName("miniprogram")]
    public IDictionary<string, string>? MiniProgram { get; set; }

    /// <summary>
    /// 所需跳转到的小程序appid（该小程序appid必须与发模板消息的公众号是绑定关联关系，暂不支持小游戏）
    /// </summary>
    [JsonPropertyName("appid")]
    public string AppId { get; set; }

    /// <summary>
    /// 所需跳转到小程序的具体页面路径，支持带参数,（示例index?foo=bar），要求该小程序已发布，暂不支持小游戏
    /// </summary>
    [JsonPropertyName("pagepath")]
    public string? PagePath { get; set; }

    /// <summary>
    /// 模板数据
    /// name:{
    ///     value:"",
    ///     color:""
    /// }
    /// </summary>
    [JsonPropertyName("data")]
    public IDictionary<string, IDictionary<string, string>> Data { get; set; }

    /// <summary>
    /// 模板内容字体颜色，不填默认为黑色
    /// </summary>
    [JsonPropertyName("color")]
    public string? Color { get; set; }

    protected override string GetRequestUri()
    {
        return $"{Endpoint}?access_token={AccessToken}";
    }
}
