using Microsoft.Extensions.DependencyInjection;

using System.Net.Http.Headers;

namespace WeChat.Applet.Checks;

public class WeChatAppletImageSecCheckResponse
    : WeChatHttpResponse
{
    /// <summary>
    /// true:表示有敏感信息
    /// </summary>
    /// <returns></returns>
    public bool IsRisky()
    {
        return ErrCode == 87014;
    }
}

public class WeChatAppletImageSecCheckRequest
    : WeChatHttpRequest<WeChatAppletImageSecCheckResponse>
     , IHasAccessToken
{
    public static string Endpoint = "/wxa/msg_sec_check?access_token={access_token}";


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