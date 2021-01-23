
using Mediator;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

using System;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WeChat
{
    [OnHandler(typeof(IWeChatRequestHandler<,>))]
    public abstract class WeChatRequestBase<TWeChatResponse> : IRequest<TWeChatResponse>
    {
        public Func<IServiceProvider, string, WeChatConfiguration> ConfigurationFactory { get; set; }
            = (prodiver, configurationName)
            => prodiver.GetRequiredService<IOptions<WeChatOptions>>().Value.GetConfiguration(configurationName);

        public abstract Task<TWeChatResponse> Handler(IWeChatRequetHandleContext context);
    }
}
