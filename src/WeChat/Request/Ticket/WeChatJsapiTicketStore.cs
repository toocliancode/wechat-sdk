
using Mediator;

using Microsoft.Extensions.Caching.Distributed;

namespace WeChat.Ticket;

public class WeChatJsapiTicketStore : IWeChatTicketStore
{
    private readonly IMediator _mediator;
    private readonly IDistributedCache _cache;
    private readonly IWeChatAccessTokenStore _accessTokenStore;

    public WeChatJsapiTicketStore(
        IMediator mediator,
        IDistributedCache cache,
        IWeChatAccessTokenStore accessTokenStore)
    {
        _mediator = mediator;
        _cache = cache;
        _accessTokenStore = accessTokenStore;
    }

    public async Task<string> GetAsync(string appId, string secret, string ticketType = "jsapi")
    {
        var cacheKey = $"wechat:{appId}:{ticketType}:ticket";
        var ticket = await _cache.GetStringAsync(cacheKey);

        if (ticket != null)
        {
            return ticket;
        }

        var token = await _accessTokenStore.GetAsync(appId, secret);

        var response = await _mediator.Send(new WeChatTicketRequest(token, ticketType));
        if (response.IsSucceed())
        {
            await _cache.SetStringAsync(
                cacheKey,
                response.Ticket,
                new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(response.ExpiresIn - 5) });

            ticket = response.Ticket;
        }
        else
        {
            throw new Exception($"获取微信ticket失败：{JsonSerializer.Serialize(response)}");
        }

        return ticket;
    }
}