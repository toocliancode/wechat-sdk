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
        private readonly IMediator _mediator;
        private readonly IDistributedCache _cache;

        public WeChatJsapiTicketStore(
            IMediator mediator,
            IDistributedCache cache)
        {
            _mediator = mediator;
            _cache = cache;
        }

        public async Task<string> GetAsync(string appId, string secret, string ticketType = "jsapi")
        {
            var cacheKey = $"wechat:{appId}:{ticketType}:ticket";
            var ticket = await _cache.GetStringAsync(cacheKey);
            if (string.IsNullOrWhiteSpace(ticket))
            {
                var request = new WeChatTicketRequest(ticketType);
                request.Configure(appId, secret);
                var response = await _mediator.Send(request);

                if (response.IsSuccessed())
                {
                    await _cache.SetStringAsync(
                        cacheKey,
                        response.Ticket,
                        new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(response.ExpiresIn) });

                    ticket = response.Ticket;
                }
                else
                {
                    throw new Exception($"获取微信ticket失败：{JsonSerializer.Serialize(response)}");
                }
            }
            return ticket;
        }
    }
}
