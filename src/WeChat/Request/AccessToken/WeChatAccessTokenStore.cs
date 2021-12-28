using Mediator;

using Microsoft.Extensions.Caching.Distributed;

using System.Text.Json;

namespace WeChat.AccessToken;

public class WeChatAccessTokenStore : IWeChatAccessTokenStore
{
    private readonly IMediator _mediator;
    private readonly IDistributedCache _cache;

    public WeChatAccessTokenStore(
        IMediator mediator,
        IDistributedCache cache)
    {
        _mediator = mediator;
        _cache = cache;
    }

    public async Task<string> GetAsync(
        string appId,
        string secret,
        string grantType = "client_credential")
    {
        var cacheKey = $"wechat:{appId}:grant_type:{grantType}:access_token";
        var token = await _cache.GetStringAsync(cacheKey);

        if (string.IsNullOrWhiteSpace(token))
        {
            var response = await _mediator.Send(new WeChatAccessTokenRequest(appId, secret, grantType));
            if (!response.IsSuccessed())
            {
                throw new Exception($"获取微信access_token失败：{JsonSerializer.Serialize(response)}");
            }

            await _cache.SetStringAsync(
                    cacheKey,
                    response.AccessToken,
                    new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(response.ExpiresIn - 5) });

            token = response.AccessToken;
        }

        return token;
    }
}