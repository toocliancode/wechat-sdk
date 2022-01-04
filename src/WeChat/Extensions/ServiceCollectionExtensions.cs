
using Microsoft.Extensions.DependencyInjection.Extensions;

using WeChat;
using WeChat.AccessToken;
using WeChat.Builder;
using WeChat.Ticket;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static WeChatBuilder AddWeChat(this IServiceCollection services)
    {
        if (services == null)
        {
            throw new ArgumentNullException(nameof(services));
        }

        if (services
            .LastOrDefault(d => d.ServiceType == typeof(WeChatBuilder))?
            .ImplementationInstance is not WeChatBuilder builder)
        {
            builder = new WeChatBuilder(services);
            services.AddSingleton(builder);
        }

        services.AddDistributedMemoryCache();

        services.TryAddTransient<IWeChatXmlSerializer, WeChatXmlSerializer>();
        services.TryAddTransient<IWeChatAccessTokenStore, WeChatAccessTokenStore>();
        services.TryAddTransient<IWeChatTicketStore, WeChatJsapiTicketStore>();
        services.TryAddTransient(typeof(IWeChatRequestHandler<,>), typeof(WeChatRequestHandler<,>));
        services.TryAddTransient(typeof(Mediation.HttpClient.IHttpRequestHandler<,>), typeof(Mediation.HttpClient.HttpRequestHandler<,>));

        return builder;
    }
}
