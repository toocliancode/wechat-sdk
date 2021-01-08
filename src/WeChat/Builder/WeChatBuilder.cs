using Microsoft.Extensions.DependencyInjection;

using System;

namespace WeChat.Builder
{
    public class WeChatBuilder
    {
        public WeChatBuilder(IServiceCollection services)
        {
            Services = services;
        }

        public IServiceCollection Services { get; set; }

        public WeChatBuilder Configure(Action<WeChatOptions> configure)
        {
            Services.Configure(configure);
            return this;
        }
    }
}
