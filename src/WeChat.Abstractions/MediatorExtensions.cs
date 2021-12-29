using Mediator;

namespace WeChat;

public static class MediatorExtensions
{
    public static Task<TWeChatResponse> Send<TWeChatResponse>(
        this IMediator mediator,
        WeChatHttpRequest<TWeChatResponse> request,
        WeChatOptions options)
        where TWeChatResponse : WeChatResponseBase, new()
    {
        request.WithOptions(options);
        return mediator.Send(request);
    }
}
