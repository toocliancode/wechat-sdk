using Mediator;

using System.Threading.Tasks;

namespace WeChat;

public static class MediatorExtensions
{
    public static Task<TWeChatResponse> Send<TWeChatResponse>(this IMediator mediator, WeChatHttpRequestBase<TWeChatResponse> request, IWeChatSettings settings)
        where TWeChatResponse : WeChatResponseBase
    {
        request.Configure(settings);
        return mediator.Send(request);
    }
}
