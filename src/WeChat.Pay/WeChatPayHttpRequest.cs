using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace WeChat;

public abstract class WeChatPayHttpRequest<TResponse> : WeChatHttpRequest<TResponse> where TResponse : WeChatHttpResponse, new()
{
    /// <summary>
    /// 是否需要检查签名。
    /// 默认值：true
    /// </summary>
    [JsonIgnore]
    protected virtual bool SignatureCheck => true;

    protected virtual WeChatPayOptions Options { get; private set; }

    protected override async Task InitializeAsync(IServiceProvider serviceProvider)
    {
        await base.InitializeAsync(serviceProvider);

        Options = serviceProvider.GetRequiredService<IOptions<WeChatPayOptions>>().Value;
    }

    public override async Task Request(IHttpRequestContext context)
    {
        await base.Request(context);

        // 签名处理
        await context
             .RequestServices
             .GetRequiredService<IWeChatPayAuthorizationHandler>()
             .Handle(context.Message, Options);
    }
    public override async Task<TResponse> Response(IHttpResponseContext context)
    {
        // 响应签名检查
        if (SignatureCheck)
        {
            await context
                 .RequestServices
                 .GetRequiredService<IWeChatPayResponseSignatureChecker>()
                 .Check(context.Message, Options);

        }

        return await base.Response(context);
    }
}
