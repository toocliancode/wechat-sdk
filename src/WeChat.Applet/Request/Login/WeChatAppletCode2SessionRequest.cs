using Mediator.HttpClient;

using System.Text.Json.Serialization;

namespace WeChat.Applet.Login;

#pragma warning disable CA1822

/// <summary>
/// <b>[auth.code2Session]</b>
/// 登录凭证校验。通过 wx.login 接口获得临时登录凭证 code 后传到开发者服务器调用此接口完成登录流程。更多使用方法详见
/// https://developers.weixin.qq.com/miniprogram/dev/api-backend/open-api/login/auth.code2Session.html
/// </summary>
public class WeChatAppletCode2SessionRequest : WeChatHttpRequest<WeChatAppletCode2SessionResponse>
{
    public static string Endpoint = "https://api.weixin.qq.com/sns/jscode2session";

    /// <summary>
    /// 微信小程序应用号
    /// </summary>
    [JsonPropertyName("appid")]
    public string AppId { get; set; }

    /// <summary>
    /// 微信小程序密钥
    /// </summary>
    [JsonPropertyName("secret")]
    public string Secret { get; set; }

    /// <summary>
    /// 登录时获取的 code
    /// </summary>
    [JsonPropertyName("js_code")]
    public string JsCode { get; set; }

    /// <summary>
    /// 授权类型，此处只需填写 authorization_code
    /// </summary>
    [JsonPropertyName("grant_type")]
    public string GrantType => "authorization_code";

    public WeChatAppletCode2SessionRequest()
    {

    }

    public WeChatAppletCode2SessionRequest(string appId, string secret, string jsCode)
    {
        AppId = appId;
        Secret = secret;
        JsCode = jsCode;
    }
    protected override string GetRequestUri()
    {
        var body = new Dictionary<string, string>
        {
            ["appid"] = AppId,
            ["secret"] = Secret,
            ["js_code"] = JsCode,
            ["grant_type"] = GrantType
        };

        return $"{Endpoint}?{HttpUtility.ToQuery(body)}";
    }
}
