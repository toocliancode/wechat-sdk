using Mediation;

using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;

using System.Text.Json;

using WeChat.Applet;

namespace WeChat;

public class WeChatAppletAccessTokenStore(
    ISender sender,
    IDistributedCache cache,
    IOptions<WeChatAppletOptions> options) : IWeChatAppletAccessTokenStore
{
    protected ISender Sender { get; } = sender;
    protected IDistributedCache Cache { get; } = cache;
    protected WeChatAppletOptions Options { get; } = options.Value;

    public virtual async Task<string> GetAsync()
    {
        var cacheKey = $"WeChatApplet:AppId-{Options.AppId}:AccessToken";
        var token = await Cache.GetStringAsync(cacheKey);

        if (token != null)
        {
            return token;
        }

        var request = new AccessToken.Request(Options.AppId, Options.Secret);
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