using WeChat;

namespace Microsoft.Extensions.DependencyInjection;

public static class WeChatMpSenderExtensions
{
    public static async Task<TResponse> SendAsync<TResponse>(this ISender sender, WeChatMpHttpRequest<TResponse> request, WeChatMpOptions options)
       where TResponse : WeChatMpHttpResponse, new()
    {
        request.WithOptions(options);
        return await sender.Send(request);
    }
}