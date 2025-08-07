using Microsoft.Extensions.DependencyInjection.Extensions;

using WeChat;
using WeChat.Mp;

namespace Microsoft.Extensions.DependencyInjection;

public static class MediationConfigurationExtensions
{
    public static IMediationConfiguration AddWeChatMp(this IMediationConfiguration configuration)
    {
        configuration.AddWeChat();
        configuration.Services.TryAddTransient<IWeChatMpAccessTokenStore, WeChatMpAccessTokenStore>();
        configuration.Services.TryAddTransient<IWeChatMpTicketStore, WeChatMpTicketStore>();

        configuration.Services.TryAddTransient<IRequestHandler<JsapiConfig.Request, JsapiConfig.Response>, JsapiConfig.Handler>();

        return configuration;
    }
}
