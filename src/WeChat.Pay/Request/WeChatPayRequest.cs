namespace WeChat.Pay;

public abstract class WeChatPayRequest<TWeChatResponse>
    : WeChatRequestBase<TWeChatResponse>
{
    /// <summary>
    /// 微信支付配置选项
    /// </summary>
    [JsonIgnore]
    public new WeChatPayOptions Options { get; protected set; }

    public void WithOptions(WeChatPayOptions options) => Options = options;

    public void Configure(Action<WeChatPayOptions> configure)
    {
        Options ??= new();
        configure(Options);
    }
}