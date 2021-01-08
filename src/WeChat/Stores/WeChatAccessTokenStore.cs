using Mediator;

using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;

using System;
using System.Text.Json;
using System.Threading.Tasks;

using WeChat.Request;

namespace WeChat.Stores
{
    public class WeChatAccessTokenStore : IWeChatAccessTokenStore
    {
        private readonly IServiceProvider _serviceProvider;

        private readonly IOptions<WeChatOptions> _options;

        private readonly IMediator _mediator;

        private readonly IDistributedCache _cache;
        public WeChatAccessTokenStore(
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

        public async Task<string> GetAsync()
        {
            return await GetAsync((provider, endpointName) => _options.Value.GetConfiguration(endpointName));
        }

        public async Task<string> GetAsync(WeChatConfiguration configuration)
        {
            return await GetAsync((provider, endpointName) => configuration);
        }

        public async Task<string> GetAsync(Func<IServiceProvider, string, WeChatConfiguration> factory)
        {
            var configuration = factory(_serviceProvider, WeChatEndpoints.AccessToken);
            var cacheKey = $"wechat:{configuration.AppId}:access_token";
            var token = await _cache.GetStringAsync(cacheKey);

            if (string.IsNullOrWhiteSpace(token))
            {
                var response = await _mediator.Send(new WeChatAccessTokenRequest(factory));
                if (!response.IsSuccessed())
                {
                    throw new Exception($"获取微信access_token失败：{JsonSerializer.Serialize(response)}");
                }
                await _cache.SetStringAsync(
                        cacheKey,
                        response.AccessToken,
                        new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(response.ExpiresIn) });

                token = response.AccessToken;
            }

            return token;
        }
    }
}
