using Microsoft.Extensions.Caching.Distributed;

using WeChat.Mp;

namespace WeChat;

public class WeChatMpAccessTokenStore(
    ISender sender,
    IDistributedCache cache) : IWeChatMpAccessTokenStore
{
    protected ISender Sender { get; } = sender;
    protected IDistributedCache Cache { get; } = cache;

    public virtual async Task<string> GetAsync(WeChatMpOptions options)
    {
        var cacheKey = $"WeChatMp:AppId-{options.AppId}:AccessToken";
        var token = await Cache.GetStringAsync(cacheKey);

        if (token != null)
        {
            return token;
        }

        var request = AccessToken.ToRequest(options.AppId, options.Secret);
        var response = await Sender.Send(request);

        if (!response.IsSucceed())
        {
            throw new WeChatException($"获取微信 access_token 失败：{JsonSerializer.Serialize(response)}");
        }

        await Cache.SetStringAsync(
               key: cacheKey,
               value: response.AccessToken,
               options: new DistributedCacheEntryOptions
               {
                   AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(response.ExpiresIn - 5)
               });

        return response.AccessToken;
    }
}