using Microsoft.Extensions.DependencyInjection.Extensions;

using WeChat;

namespace Microsoft.Extensions.DependencyInjection;

public static class MediationConfigurationExtensions
{
    public static IMediationConfiguration AddWeChat(this IMediationConfiguration configuration)
    {
        configuration.AddHttpClient();

        configuration.Services.TryAddTransient<IWeChatSerializer, WeChatSerializer>();

        return configuration;
    }
}