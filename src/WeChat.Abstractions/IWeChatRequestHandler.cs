using Mediation;

namespace WeChat;

/// <summary>
/// 微信请求处理器
/// </summary>
/// <typeparam name="TWeChatRequet"></typeparam>
/// <typeparam name="TWeChatResponse"></typeparam>
public interface IWeChatRequestHandler<TWeChatRequet, TWeChatResponse>
    : IRequestHandler<TWeChatRequet, TWeChatResponse>
    where TWeChatRequet : WeChatRequestBase<TWeChatResponse>
{
}
