using System.Net.Http.Headers;

namespace WeChat.Mp.Media;

/// <summary>
/// 上传图文消息内的图片获取URL。
/// 
/// https://developers.weixin.qq.com/doc/offiaccount/Cards_and_Offer/Create_a_Coupon_Voucher_or_Card.html#5
/// </summary>
public class WeChatMpMediaUploadImgRequest
    : WeChatHttpRequest<WeChatMpMediaUploadImgResponse>
    , IHasAccessToken
{
    public static string Endpoint = "/cgi-bin/media/uploadimg?access_token={access_token}";

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpMediaUploadImgRequest"/>
    /// </summary>
    public WeChatMpMediaUploadImgRequest()
    {

    }

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpMediaUploadImgRequest"/>
    /// </summary>
    /// <param name="buffer">
    /// 文件的数据流。
    /// 上传的图片限制文件大小限制1MB，仅支持JPG、PNG格式
    /// </param>
    /// <param name="accessToken"></param>
    public WeChatMpMediaUploadImgRequest(
        byte[] buffer,
        string? accessToken = default)
    {
        Buffer = buffer;
        AccessToken = accessToken;
    }


    /// <inheritdoc/>
    [JsonIgnore]
    public string? AccessToken { get; set; }

    /// <summary>
    /// 文件的数据流。
    /// 上传的图片限制文件大小限制1MB，仅支持JPG、PNG格式
    /// </summary>
    public byte[] Buffer { get; set; }

    [JsonIgnore]
    public override HttpMethod Method { get; set; } = HttpMethod.Post;

    protected override string GetRequestUri() => $"{WeChatProperties.Domain}{Endpoint}"
        .Replace("{access_token}", AccessToken);

    protected override async Task<HttpContent?> GetContent()
    {
        await Task.CompletedTask;

        var boundary = Guid.NewGuid().ToString();
        var body = new MultipartFormDataContent(boundary);
        body.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data;boundary=" + boundary);
        body.Add(new ByteArrayContent(Buffer));
        return body;
    }
}
