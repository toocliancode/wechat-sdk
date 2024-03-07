using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

using WeChat;

namespace Mediation;

public static class MediationConfigurationExtensions
{
    public static IMediationConfiguration AddWeChat(this IMediationConfiguration configuration)
    {
        configuration.Services.TryAddTransient<IWeChatSerializer, WeChatSerializer>();

        return configuration;
    }
}