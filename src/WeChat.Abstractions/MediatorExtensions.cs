using Mediation;

namespace WeChat;

public static class MediationExtensions
{
    public static Task<TWeChatResponse> Send<TWeChatResponse>(
        this ISender mediator,
        WeChatHttpRequest<TWeChatResponse> request,
        WeChatOptions options,
        CancellationToken cancellationToken = default)
        where TWeChatResponse : WeChatHttpResponseBase, new()
    {
        request.WithOptions(options);
        return mediator.Send(request, cancellationToken);
    }
}
