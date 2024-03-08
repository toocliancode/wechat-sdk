using Mediation.HttpClient;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using System.Text;

namespace WeChat;

public abstract class WeChatHttpRequest<TResponse> : HttpRequestBase<TResponse> where TResponse : WeChatHttpResponse, new()
{
    protected virtual ILogger Logger { get; private set; }

    protected virtual IWeChatSerializer WeChatSerializer { get; private set; }

    public override HttpClient CreateClient(IHttpClientCreateContext context) => context.HttpClientFactory.CreateClient("WeChat");

    protected virtual Task InitializeAsync(IServiceProvider serviceProvider)
    {
        var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();

        Logger = loggerFactory.CreateLogger(this.GetType().FullName!);
        WeChatSerializer = serviceProvider.GetRequiredService<IWeChatSerializer>();

        return Task.CompletedTask;
    }

    protected virtual Task InitializeRequestMessageAsync(IHttpRequestContext context)
    {
        return Task.CompletedTask;
    }

    public override async Task Request(IHttpRequestContext context)
    {
        await InitializeAsync(context.RequestServices);
        await InitializeRequestMessageAsync(context);
    }

    public override async Task<TResponse> Response(IHttpResponseContext context)
    {
        var json = await context.Message.Content.ReadAsStringAsync();

        Logger.LogDebug("响应内容：{json}", json);

        try
        {
            var response = WeChatSerializer.Deserialize<TResponse>(json ?? "{}");

            response.StatusCode = context.Message.StatusCode;
            response.Raw = Encoding.UTF8.GetBytes(json ?? string.Empty);

            return response;
        }
        catch (Exception ex)
        {
            throw new WeChatHttpRequestException($"响应内容：{json}", ex, context.Message.StatusCode);
        }
    }
}
