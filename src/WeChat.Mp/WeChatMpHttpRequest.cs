using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace WeChat;

public class WeChatMpHttpRequest<TResponse> :
    WeChatHttpRequest<TResponse>
    where TResponse : WeChatMpHttpResponse, new()
{
    protected virtual WeChatMpOptions Options { get; private set; }

    protected virtual Lazy<IWeChatMpAccessTokenStore> AccessTokenStoreLazy { get; private set; }

    protected override async Task InitializeAsync(IServiceProvider serviceProvider)
    {
        await base.InitializeAsync(serviceProvider);

        Options ??= serviceProvider.GetRequiredService<IOptions<WeChatMpOptions>>().Value;
        AccessTokenStoreLazy ??= new Lazy<IWeChatMpAccessTokenStore>(serviceProvider.GetRequiredService<IWeChatMpAccessTokenStore>);
    }

    protected virtual async Task<string> GetAccessTokenAsync()
    {
        return await AccessTokenStoreLazy.Value.GetAsync(Options);
    }

    public virtual void WithOptions(WeChatMpOptions options)
    {
        Options = options;
    }
}