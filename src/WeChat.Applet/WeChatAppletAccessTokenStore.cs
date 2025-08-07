using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;

using WeChat.Applet;

namespace WeChat;

public class WeChatAppletAccessTokenStore(
    ISender sender,
    IDistributedCache cache) : IWeChatAppletAccessTokenStore
{
    protected ISender Sender { get; } = sender;
    protected IDistributedCache Cache { get; } = cache;

    public virtual async Task<string> GetAsync(WeChatAppletOptions options)
    {
        var cacheKey = $"WeChatApplet:AppId-{options.AppId}:AccessToken";
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