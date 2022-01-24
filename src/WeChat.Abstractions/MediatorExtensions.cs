using Mediation;

namespace WeChat;

public static class MediationExtensions
{
    public static Task<TWeChatResponse> Send<TWeChatResponse>(
        this IMediator mediator,
        WeChatHttpRequest<TWeChatResponse> request,
        WeChatOptions options)
        where TWeChatResponse : WeChatHttpResponseBase, new()
    {
        request.WithOptions(options);
        return mediator.Send(request);
    }
}
