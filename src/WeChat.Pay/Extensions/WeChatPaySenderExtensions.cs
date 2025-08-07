using WeChat;

namespace Microsoft.Extensions.DependencyInjection;

public static class WeChatPaySenderExtensions
{
    public static async Task<TResponse> SendAsync<TResponse>(this ISender sender, WeChatPayHttpRequest<TResponse> request, WeChatPayOptions options)
       where TResponse : WeChatHttpResponse, new()
    {
        request.WithOptions(options);
        return await sender.Send(request);
    }
}