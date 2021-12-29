
using Mediator;

using System.Text.Json.Serialization;

namespace WeChat;

[OnHandler(typeof(IWeChatRequestHandler<,>))]
public abstract class WeChatRequestBase<TWeChatResponse> : IRequest<TWeChatResponse>
{
    /// <summary>
    /// 微信支付配置选项
    /// </summary>
    [JsonIgnore]
    public virtual WeChatOptions Options { get; protected set; }

    public virtual void WithOptions(WeChatOptions options) => Options = options;

    public virtual void Configure(Action<WeChatOptions> configure)
    {
        Options ??= new();
        configure(Options);
    }

    public abstract Task<TWeChatResponse> Handle(IWeChatRequetHandleContext context);
}
