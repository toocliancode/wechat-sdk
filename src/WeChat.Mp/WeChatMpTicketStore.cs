using Microsoft.Extensions.Caching.Distributed;

using WeChat.Mp;

namespace WeChat;

public class WeChatMpTicketStore(
    ISender sender,
    IDistributedCache cache) : IWeChatMpTicketStore
{
    protected ISender Sender { get; } = sender;
    protected IDistributedCache Cache { get; } = cache;

    public async Task<string> GetAsync(WeChatMpOptions options, string ticketType = "jsapi")
    {
        var cacheKey = $"WeChatMp:AppId-{options.AppId}:Ticket";
        var ticket = await Cache.GetStringAsync(cacheKey);

        if (ticket != null)
        {
            return ticket;
        }

        var request = Ticket.ToRequest(ticketType);
        var response = await Sender.SendAsync(request, options);

        if (!response.IsSucceed())
        {
            throw new WeChatException($"获取微信 ticket 失败：{JsonSerializer.Serialize(response)}");
        }

        await Cache.SetStringAsync(
               key: cacheKey,
               value: response.Ticket,
               options: new DistributedCacheEntryOptions
               {
                   AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(response.ExpiresIn - 5)
               });

        return response.Ticket;
    }
}