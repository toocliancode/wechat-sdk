
using System.Text.Json.Serialization;

namespace WeChat.Pay;

public abstract class WeChatPayRequest<TWeChatResponse>
    : WeChatRequestBase<TWeChatResponse>
{
    /// <summary>
    /// 微信支付配置选项
    /// </summary>
    [JsonIgnore]
    public WeChatPayOptions Options { get; protected set; }

    public WeChatPayRequest<TWeChatResponse> WithOptions(WeChatPayOptions options)
    {
        Options = options;
        return this;
    }

    public WeChatPayRequest<TWeChatResponse> Configure(Action<WeChatPayOptions> configure)
    {
        Options ??= new();
        configure(Options);
        return this;
    }
}