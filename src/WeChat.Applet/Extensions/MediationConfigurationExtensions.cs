using Microsoft.Extensions.DependencyInjection.Extensions;

using WeChat;

namespace Microsoft.Extensions.DependencyInjection;

public static class MediationConfigurationExtensions
{
    public static IMediationConfiguration AddWeChatApplet(this IMediationConfiguration configuration)
    {
        configuration.AddWeChat();
        configuration.Services.TryAddTransient<IWeChatAppletAccessTokenStore, WeChatAppletAccessTokenStore>();

        return configuration;
    }
}