
using Microsoft.Extensions.DependencyInjection.Extensions;

using System;
using System.Collections.Generic;
using System.Linq;

using WeChat;
using WeChat.Builder;
using WeChat.Stores;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static WeChatBuilder AddWeChat(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.Configure<WeChatOptions>(options =>
            {
                options.AddOrUpdateEndpoints(new Dictionary<string, string>
                {
                    [WeChatEndpoints.AccessToken] = WeChatEndpoints.AccessTokenValue,
                    [WeChatEndpoints.Ticket] = WeChatEndpoints.TicketValue,
                });
            });

            if (services
                .LastOrDefault(d => d.ServiceType == typeof(WeChatBuilder))?
                .ImplementationInstance is not WeChatBuilder builder)
            {
                builder = new WeChatBuilder(services);
                services.AddSingleton(builder);
            }

            services.TryAddSingleton<IWeChatAccessTokenStore, WeChatAccessTokenStore>();
            services.TryAddSingleton<IWeChatJsapiTicketStore, WeChatJsapiTicketStore>();
            services.TryAddTransient(typeof(IWeChatRequestHandler<,>), typeof(WeChatRequestHandler<,>));

            //services.AddHttpClient(httpClientName);

            return builder;
        }
    }
}
