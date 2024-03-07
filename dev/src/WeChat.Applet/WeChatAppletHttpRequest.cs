using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace WeChat;

public class WeChatAppletHttpRequest<TResponse> :
    WeChatHttpRequest<TResponse>
    where TResponse : WeChatAppletHttpResponse, new()
{
    protected WeChatAppletOptions Options { get; private set; }

    protected Lazy<IWeChatAppletAccessTokenStore> AccessTokenStoreLazy { get; private set; }

    protected override async Task InitializeAsync(IServiceProvider serviceProvider)
    {
        await base.InitializeAsync(serviceProvider);

        Options = serviceProvider.GetRequiredService<IOptions<WeChatAppletOptions>>().Value;
        AccessTokenStoreLazy = new Lazy<IWeChatAppletAccessTokenStore>(serviceProvider.GetRequiredService<IWeChatAppletAccessTokenStore>);
    }

    protected async Task<string> GetAccessTokenAsync()
    {
        return await AccessTokenStoreLazy.Value.GetAsync();
    }
}