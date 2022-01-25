using Mediation.HttpClient;

using Microsoft.Extensions.DependencyInjection;

using System.Text.Encodings.Web;

namespace WeChat.Pay;

public class WeChatPayHttpRequest<TWeChatResponse>
    : HttpRequestBase<TWeChatResponse>
    where TWeChatResponse : WeChatHttpResponseBase, new()
{
    /// <inheritdoc/>
    [JsonIgnore]
    public virtual HttpMethod Method { get; set; } = HttpMethod.Post;

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
    public virtual WeChatPayOptions Options { get; set; }

    public virtual WeChatPayHttpRequest<TWeChatResponse> WithOptions(WeChatPayOptions options)
    {
        Options = options;
        SetAppId(Options.AppId);
        SetMchId(Options.MchId);
        return this;
    }

    public virtual WeChatPayHttpRequest<TWeChatResponse> Configure(Action<WeChatPayOptions> configure)
    {
        Options ??= new();
        configure(Options);
        SetAppId(Options.AppId);
        SetMchId(Options.MchId);
        return this;
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

    protected virtual void SetMchId(string mchId)
    {
        if (!string.IsNullOrWhiteSpace(mchId) &&
            this is IHasMchId request &&
            request.MchId != mchId)
        {
            request.MchId = mchId;
        }
    }

    public override async Task Request(IHttpRequestContext context)
    {
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

        context.Message.Method = Method ?? HttpMethod.Get;
        context.Message.RequestUri = new(GetRequestUri());
        context.Message.Content = await GetContent(context.RequestServices);

        Configure(context);

        // 签名处理
        await context
             .RequestServices
             .GetRequiredService<IWeChatPayAuthorizationHandler>()
             .Handle(context.Message, Options);
    }

    protected virtual string GetRequestUri()
    {
        return string.Empty;
    }

    protected virtual async Task<HttpContent?> GetContent()
    {
        await Task.CompletedTask;

        return Method == HttpMethod.Post || Method == HttpMethod.Put
            ? new StringContent(JsonSerializer.Serialize((object)this, JsonSerializerOptions), System.Text.Encoding.UTF8, "application/json")
            : null;
    }
    protected virtual Task<HttpContent?> GetContent(IServiceProvider serviceProvider)
    {
        return GetContent();
    }

    protected virtual void Configure(IHttpRequestContext context)
    {

    }

    protected virtual void ParameterHandle()
    {

    }

    [JsonIgnore]
    public virtual JsonSerializerOptions? JsonSerializerOptions { get; set; } = new()
    {
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        DictionaryKeyPolicy = JsonNamingPolicy.CamelCase
    };

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
        var row = await context.Message.Content.ReadAsByteArrayAsync();
        var response = JsonSerializer.Deserialize<TWeChatResponse>(row, JsonSerializerOptions) ?? new();
        response.Raw = row;
        response.StatusCode = context.Message.StatusCode;

        return response;
    }
}
