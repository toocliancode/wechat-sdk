
using Mediation.HttpClient;

namespace WeChat.Applet.QrCode;

/// <summary>
/// <b>[wxacode.createQRCode]</b>
/// 创建小程序二维码请求
/// 适用于需要的码数量较少的业务场景。通过该接口生成的小程序码，永久有效，有数量限制
/// https://developers.weixin.qq.com/miniprogram/dev/api-backend/open-api/qr-code/wxacode.createQRCode.html
/// </summary>
public class WeChatAppletCreateWxaQrCodeRequest
    : WeChatHttpRequest<WeChatHttpResponse>
    , IHasAccessToken
{
    public static string Endpoint = "/cgi-bin/wxaapp/createwxaqrcode?access_token={access_token}";

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatAppletCreateWxaQrCodeRequest"/>
    /// </summary>
    public WeChatAppletCreateWxaQrCodeRequest()
        : base(HttpMethod.Post)
    {

    }

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatAppletCreateWxaQrCodeRequest"/>
    /// </summary>
    /// <param name="accessToken">微信API access_token</param>
    /// <param name="path">扫码进入的小程序页面路径，最大长度 128 字节，不能为空；对于小游戏，可以只传入 query 部分，来实现传参效果，
    /// 如：传入 "?foo=bar"，即可在 wx.getLaunchOptionsSync 接口中的 query 参数获取到 {foo:"bar"}。</param>
    /// <param name="width">二维码的宽度，单位 px。最小 280px，最大 1280px。默认值 430</param>
    public WeChatAppletCreateWxaQrCodeRequest(
        string path,
        int? width = 430,
        string? accessToken = default)
        : this()
    {
        AccessToken = accessToken;
        Path = path;
        Width = width;
    }

    /// <inheritdoc/>
    [JsonIgnore]
    public string? AccessToken { get; set; }

    /// <summary>
    /// 扫码进入的小程序页面路径，最大长度 128 字节，不能为空；对于小游戏，可以只传入 query 部分，来实现传参效果，
    /// 如：传入 "?foo=bar"，即可在 wx.getLaunchOptionsSync 接口中的 query 参数获取到 {foo:"bar"}。
    /// </summary>
    [JsonPropertyName("path")]
    public string Path { get; set; }

    /// <summary>
    /// 二维码的宽度，单位 px。最小 280px，最大 1280px。
    /// 默认值 430
    /// </summary>
    [JsonPropertyName("width")]
    public int? Width { get; set; }

    protected override string GetRequestUri()
        => $"{WeChatProperties.Domain}{Endpoint}"
        .Replace("{access_token}", AccessToken);

    public override async Task<WeChatHttpResponse> Response(IHttpResponseContext context)
    {
        var data = await context.Message.Content.ReadAsByteArrayAsync();
        WeChatHttpResponse response;
        try
        {
            response = JsonSerializer.Deserialize<WeChatHttpResponse>(data, JsonSerializerOptions) ?? new();
        }
        catch (Exception)
        {
            response = new();
        }

        response.Raw = data;
        response.StatusCode = context.Message.StatusCode;

        return response;
    }
}
