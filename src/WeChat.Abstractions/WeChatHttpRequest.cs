using Mediation.HttpClient;

using Microsoft.Extensions.DependencyInjection;

using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WeChat;

/// <summary>
/// 构建微信Http请求类
/// </summary>
/// <typeparam name="TWeChatResponse"></typeparam>
public class WeChatHttpRequest<TWeChatResponse>
    : HttpRequestBase<TWeChatResponse>
    where TWeChatResponse : WeChatHttpResponseBase, new()
{
    public WeChatHttpRequest()
    {

    }
    public WeChatHttpRequest(HttpMethod method)
    {
        Method = method;
    }
    public WeChatHttpRequest(Func<string> requestUriFactory)
    {
        RequestUriFactory = requestUriFactory;
    }

    public WeChatHttpRequest(Func<Task<HttpContent?>> contentFactory)
    {
        ContentFactory = contentFactory;
    }
    public WeChatHttpRequest(Action<IHttpRequestContext> configureRequest)
    {
        ConfigureRequest = configureRequest;
    }

    public WeChatHttpRequest(Func<IHttpResponseContext, Task<TWeChatResponse>> responseFactory)
    {
        ResponseFactory = responseFactory;
    }

    public WeChatHttpRequest(
        HttpMethod? method = default,
        Func<string>? requestUriFactory = default,
        Func<Task<HttpContent?>>? contentFactory = default,
        Action<IHttpRequestContext>? configureRequest = default,
        Func<IHttpResponseContext, Task<TWeChatResponse>>? responseFactory = default
        )
    {
        Method = method ?? HttpMethod.Get;
        RequestUriFactory = requestUriFactory;
        ContentFactory = contentFactory;
        ConfigureRequest = configureRequest;
        ResponseFactory = responseFactory;
    }

    /// <summary>
    /// 微信支付配置选项
    /// </summary>
    [JsonIgnore]
    public virtual WeChatOptions Options { get; protected set; }

    public virtual void WithOptions(WeChatOptions options)
    {
        Options = options;

        SetAppId(Options.AppId);
        SetSecret(Options.Secret);
    }

    public virtual void Configure(Action<WeChatOptions> configure)
    {
        Options ??= new();
        configure(Options);

        SetAppId(Options.AppId);
        SetSecret(Options.Secret);
    }

    protected virtual void SetAppId(string appId)
    {
        if (!string.IsNullOrWhiteSpace(appId) &&
            this is IHasAppId request &&
            request.AppId != appId)
        {
            request.AppId = appId;
        }
    }

    protected virtual void SetSecret(string secret)
    {
        if (!string.IsNullOrWhiteSpace(secret) &&
            this is IHasSecret request &&
            request.Secret != secret)
        {
            request.Secret = secret;
        }
    }

    /// <summary>
    /// Http 请求方式
    /// </summary>
    [JsonIgnore]
    public virtual HttpMethod Method { get; set; } = HttpMethod.Get;

    /// <summary>
    /// 构建请求链接
    /// </summary>
    [JsonIgnore]
    public virtual Func<string>? RequestUriFactory { get; set; }

    /// <summary>
    /// 构建请求内容
    /// </summary>
    [JsonIgnore]
    public virtual Func<Task<HttpContent?>>? ContentFactory { get; set; }

    /// <summary>
    /// 配置请求
    /// </summary>
    [JsonIgnore]
    public virtual Action<IHttpRequestContext>? ConfigureRequest { get; set; }

    protected virtual string GetRequestUri()
        => RequestUriFactory?.Invoke() ?? throw new ArgumentNullException(nameof(RequestUriFactory));

    protected virtual async Task<HttpContent?> GetContent()
        => ContentFactory != null
        ? await ContentFactory()
        : Method == HttpMethod.Post || Method == HttpMethod.Put
        ? new StringContent(JsonSerializer.Serialize((object)this, JsonSerializerOptions))
        : null;
    protected virtual Task<HttpContent?> GetContent(IServiceProvider serviceProvider)
    {
        return GetContent();
    }

    protected virtual void Configure(IHttpRequestContext context)
    {
        ConfigureRequest?.Invoke(context);
    }

    public override async Task Request(IHttpRequestContext context)
    {
        switch (this)
        {
            case IHasAccessToken accessToken when string.IsNullOrWhiteSpace(accessToken.AccessToken):
                accessToken.AccessToken = await context
                     .RequestServices
                     .GetRequiredService<IWeChatAccessTokenStore>()
                     .GetAsync(Options.AppId, Options.Secret);
                break;
            case IHasCardTicket cardTicket when string.IsNullOrWhiteSpace(cardTicket.CardTicket):
                cardTicket.CardTicket = await context
                     .RequestServices
                     .GetRequiredService<IWeChatTicketStore>()
                     .GetAsync(Options.AppId, Options.Secret, "wx_card");
                break;
            case IHasJsapiTicket jsapiTicket when string.IsNullOrWhiteSpace(jsapiTicket.JsapiTicket):
                jsapiTicket.JsapiTicket = await context
                     .RequestServices
                     .GetRequiredService<IWeChatTicketStore>()
                     .GetAsync(Options.AppId, Options.Secret, "jsapi");
                break;
        }

        context.Message.Method = Method ?? HttpMethod.Get;
        if (RequestUriFactory == null)
        {
            context.Message.RequestUri = new(GetRequestUri());
        }
        if (ContentFactory == null)
        {
            context.Message.Content = await GetContent(context.RequestServices);
        }

        Configure(context);
    }

    public override HttpClient CreateClient(IHttpClientCreateContext context)
        => context.HttpClientFactory.CreateClient("WeChatClient");

    /// <summary>
    /// 处理响应
    /// </summary>
    public virtual Func<IHttpResponseContext, Task<TWeChatResponse>>? ResponseFactory { get; set; }

    [JsonIgnore]
    public virtual JsonSerializerOptions? JsonSerializerOptions { get; set; } = new()
    {
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        DictionaryKeyPolicy = JsonNamingPolicy.CamelCase
    };

    public override async Task<TWeChatResponse> Response(IHttpResponseContext context)
    {
        if (ResponseFactory != null)
        {
            return await ResponseFactory(context);
        }

        var row = await context.Message.Content.ReadAsByteArrayAsync();
        var response = JsonSerializer.Deserialize<TWeChatResponse>(row, JsonSerializerOptions) ?? new();
        response.Raw = row;
        response.StatusCode = context.Message.StatusCode;

        return response;
    }
}
