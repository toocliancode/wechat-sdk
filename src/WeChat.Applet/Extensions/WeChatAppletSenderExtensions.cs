using WeChat;

namespace Mediation;

public static class WeChatAppletSenderExtensions
{
    public static async Task<TResponse> SendAsync<TResponse>(this ISender sender, WeChatAppletHttpRequest<TResponse> request, WeChatAppletOptions options)
       where TResponse : WeChatAppletHttpResponse, new()
    {
        request.WithOptions(options);
        return await sender.Send(request);
    }
}