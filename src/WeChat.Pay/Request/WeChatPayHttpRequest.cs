using Mediator.HttpClient;

using Microsoft.Extensions.DependencyInjection;

using System.Text.Json.Serialization;

namespace WeChat.Pay;

public class WeChatPayHttpRequest<TWeChatResponse>
    : WeChatHttpRequest<TWeChatResponse>
    where TWeChatResponse : WeChatResponseBase, new()
{
    /// <inheritdoc/>
    [JsonIgnore]
    public override HttpMethod Method { get; set; } = HttpMethod.Post;

    /// <summary>
    /// 是否需要检查签名。
    /// 默认值：true
    /// </summary>
    [JsonIgnore]
    protected virtual bool SignatureCheck => true;

    /// <summary>
    /// 微信支付配置选项
    /// </summary>
    [JsonIgnore]
    public virtual new WeChatPayOptions Options { get; set; }

    public virtual WeChatPayHttpRequest<TWeChatResponse> WithOptions(WeChatPayOptions options)
    {
        Options = options;
        return this;
    }

    public virtual WeChatPayHttpRequest<TWeChatResponse> Configure(Action<WeChatPayOptions> configure)
    {
        Options ??= new();
        configure(Options);
        return this;
    }

    public override async Task Request(IHttpRequestContext context)
    {
        if (this is IHasMchId mchId &&
            string.IsNullOrWhiteSpace(mchId.MchId))
        {
            mchId.MchId = Options.MchId;
        }

        if (!string.IsNullOrWhiteSpace(Options.TransactionNotifyUrl) &&
            this is IHasTransactionNotifyUrl transactionNotifyUrl &&
            string.IsNullOrWhiteSpace(transactionNotifyUrl.NotifyUrl))
        {
            transactionNotifyUrl.NotifyUrl = Options.TransactionNotifyUrl;
        }

        if (!string.IsNullOrWhiteSpace(Options.RefundNotifyUrl) &&
            this is IHasRefundNotifyUrl mayRefundNotifyUrl &&
            string.IsNullOrWhiteSpace(mayRefundNotifyUrl.NotifyUrl))
        {
            mayRefundNotifyUrl.NotifyUrl = Options.RefundNotifyUrl;
        }

        await base.Request(context);

        // 签名处理
        await context
             .RequestServices
             .GetRequiredService<IWeChatPayAuthorizationHandler>()
             .Handle(context.Message, Options);
    }

    protected virtual void ParameterHandle()
    {

    }

    public override async Task<TWeChatResponse> Response(IHttpResponseContext context)
    {
        // 响应签名检查
        if (SignatureCheck)
        {
            await context
                 .RequestService
                 .GetRequiredService<IWeChatPayResponseSignatureChecker>()
                 .Check(context.Message, Options);

        }

        return await base.Response(context);
    }
}
