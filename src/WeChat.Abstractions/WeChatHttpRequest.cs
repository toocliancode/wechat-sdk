﻿using Mediator.HttpClient;

using System.Text.Json;
using System.Text.Json.Serialization;

namespace WeChat;

/// <summary>
/// 构建微信Http请求类
/// </summary>
/// <typeparam name="TWeChatResponse"></typeparam>
public class WeChatHttpRequest<TWeChatResponse>
    : HttpRequestBase<TWeChatResponse>
    where TWeChatResponse : WeChatResponseBase, new()
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

    protected virtual void Configure(IHttpRequestContext context)
    {
        ConfigureRequest?.Invoke(context);
    }

    public override async Task Request(IHttpRequestContext context)
    {
        context.Message.Method = Method ?? HttpMethod.Get;
        if (RequestUriFactory != null)
        {
            context.Message.RequestUri = new(GetRequestUri());
        }
        if (ContentFactory != null)
        {
            context.Message.Content = await GetContent();
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
        Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
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
