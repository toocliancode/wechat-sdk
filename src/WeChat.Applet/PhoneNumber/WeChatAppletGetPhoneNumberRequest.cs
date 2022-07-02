namespace WeChat.Applet;

/// <summary>
/// <b>[phonenumber.getPhoneNumber]</b>
/// code换取用户手机号。 每个 code 只能使用一次，code的有效期为5min
/// <a href="https://developers.weixin.qq.com/miniprogram/dev/api-backend/open-api/phonenumber/phonenumber.getPhoneNumber.html"></a>
/// </summary>
public class WeChatAppletGetPhoneNumberRequest
    : WeChatHttpRequest<WeChatAppletGetPhoneNumberResponse>
    , IHasAccessToken
{
    public static string Endpoint = "/wxa/media_check_async?access_token={access_token}";

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatAppletGetPhoneNumberRequest"/>
    /// </summary>
    public WeChatAppletGetPhoneNumberRequest()
        : base(HttpMethod.Post)
    {
    }

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatAppletGetPhoneNumberRequest"/>
    /// </summary>
    /// <param name="code">手机号获取凭证:https://developers.weixin.qq.com/miniprogram/dev/framework/open-ability/getPhoneNumber.html</param>
    /// <param name="accessToken">自定义token</param>
    public WeChatAppletGetPhoneNumberRequest(string code, string? accessToken = default)
        : this()
    {
        Code = code;
        AccessToken = accessToken;
    }

    /// <inheritdoc/>
    [JsonIgnore]
    public string? AccessToken { get; set; }

    /// <summary>
    /// 手机号获取凭证:https://developers.weixin.qq.com/miniprogram/dev/framework/open-ability/getPhoneNumber.html
    /// </summary>
    [JsonPropertyName("code")]
    public string Code { get; set; }

    protected override string GetRequestUri() => $"{WeChatProperties.Domain}{Endpoint}".Replace("{access_token}", AccessToken);
}
