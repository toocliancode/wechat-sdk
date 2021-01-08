using Mediator;

using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;

using System;
using System.Text.Json;
using System.Threading.Tasks;

using WeChat.Request;

namespace WeChat.Stores
{
    public class WeChatJsapiTicketStore : IWeChatJsapiTicketStore
    {
        private readonly IServiceProvider _serviceProvider;

        private readonly IOptions<WeChatOptions> _options;

        private readonly IMediator _mediator;

        private readonly IDistributedCache _cache;

        public WeChatJsapiTicketStore(
            IServiceProvider serviceProvider,
            IOptions<WeChatOptions> options,
            IMediator mediator,
            IDistributedCache cache)
        {
            _serviceProvider = serviceProvider;
            _options = options;
            _mediator = mediator;
            _cache = cache;
        }

        public async Task<string> GetAsync(string ticketType = "jsapi")
        {
            return await GetAsync((resolver, endpointName) => _options.Value.GetConfiguration(endpointName), ticketType);
        }

        public async Task<string> GetAsync(Func<IServiceProvider, string, WeChatConfiguration> factory, string ticketType = "jsapi")
        {
            var configuration = factory(_serviceProvider, WeChatEndpoints.Ticket);
            return await GetAsync(configuration, ticketType);
        }
        public async Task<string> GetAsync(WeChatConfiguration configuration, string ticketType = "jsapi")
        {
            var cacheKey = $"wechat:{configuration.AppId}:{ticketType}:ticket";
            var ticket = await _cache.GetStringAsync(cacheKey);
            if (string.IsNullOrWhiteSpace(ticket))
            {
                var response = await _mediator.Send(new WeChatTicketRequest((resolver, endpointName) => configuration, ticketType));

                if (response.IsSuccessed())
                {
                    await _cache.SetStringAsync(
                        cacheKey,
                        response.Ticket,
                        new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(7200) });

                    ticket = response.Ticket;
                }
                throw new Exception($"获取微信ticket失败：{JsonSerializer.Serialize(response)}");
            }
            return ticket;
        }
    }
}
