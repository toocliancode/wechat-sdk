using Microsoft.Extensions.DependencyInjection;

using System.Net.Http.Headers;

namespace WeChat.Applet.Checks;

/// <summary>
/// 图片检测
/// </summary>
public class WeChatAppletImageSecCheckRequest
    : WeChatHttpRequest<WeChatAppletImageSecCheckResponse>
    , IHasAccessToken
{
    public static string Endpoint = "/wxa/img_sec_check?access_token={access_token}";

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatAppletImageSecCheckRequest"/>
    /// </summary>
    /// <param name="url"></param>
    /// <param name="accessToken"></param>
    public WeChatAppletImageSecCheckRequest(
        string url,
        string? accessToken = default)
        : base(HttpMethod.Post)
    {
        AccessToken = accessToken;
        Url = url;
    }


    /// <inheritdoc/>
    [JsonIgnore]
    public string? AccessToken { get; set; }

    /// <summary>
    /// 检测的图片链接
    /// </summary>
    public string Url { get; set; }

    protected override string GetRequestUri()
        => $"{WeChatProperties.Domain}{Endpoint}"
        .Replace("{access_token}", AccessToken);

    protected override async Task<HttpContent?> GetContent(IServiceProvider serviceProvider)
    {
        await Task.CompletedTask;

        var factory = serviceProvider.GetRequiredService<IHttpClientFactory>();
        using var client = factory.CreateClient();
        using var response = await client.GetAsync(Url);
        if (!response.IsSuccessStatusCode)
        {
            throw new ArgumentException(nameof(Url));
        }

        var boundary = Guid.NewGuid().ToString();
        var body = new MultipartFormDataContent(boundary);
        body.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data;boundary=" + boundary);
        body.Add(new ByteArrayContent(await response.Content.ReadAsByteArrayAsync()));
        return body;
    }
}