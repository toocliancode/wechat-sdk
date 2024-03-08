using Mediation;

using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;

using System.Text.Json;

using WeChat.Mp;

namespace WeChat;

public class WeChatMpAccessTokenStore(
    ISender sender,
    IDistributedCache cache,
    IOptions<WeChatMpOptions> options) : IWeChatMpAccessTokenStore
{
    protected ISender Sender { get; } = sender;
    protected IDistributedCache Cache { get; } = cache;
    protected WeChatMpOptions Options { get; } = options.Value;

    public virtual async Task<string> GetAsync()
    {
        var cacheKey = $"WeChatMp:AppId-{Options.AppId}:AccessToken";
        var token = await Cache.GetStringAsync(cacheKey);

        if (token != null)
        {
            return token;
        }

        var request = AccessToken.ToRequest(Options.AppId, Options.Secret);
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