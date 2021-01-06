using Mediator.HttpClient;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WeChat
{
    /// <summary>
    /// 微信Http请求基类
    /// </summary>
    /// <typeparam name="TWeChatResponse"></typeparam>
    public abstract class WeChatHttpRequestBase<TWeChatResponse>
        : HttpRequestBase<TWeChatResponse>
        where TWeChatResponse : WeChatResponseBase
    {
        protected WeChatHttpRequestBase()
        {
        }

        /// <summary>
        /// 实例化一个Http请求
        /// </summary>
        /// <param name="configurationFactory">端点自定义配置获取</param>
        protected WeChatHttpRequestBase(Func<IServiceProvider, string, WeChatConfiguration> configurationFactory)
        {
            ConfigurationFactory = configurationFactory;
        }

        [JsonIgnore]
        public Func<IServiceProvider, string, WeChatConfiguration> ConfigurationFactory { get; set; }
            = (prodiver, configurationName)
            => prodiver.GetRequiredService<IOptions<WeChatOptions>>().Value.GetConfiguration(configurationName);

        public override async Task CreateAsync(IHttpRequestContext context)
        {
            var endpointName = GetEndpointName();
            var configuration = ConfigurationFactory(context.RequestService, endpointName);

            ParameterHandler(configuration);

            var dictionary = ToDictionary();
            var method = GetHttpMethod();

            if (method.Equals(HttpMethod.Get))
            {
                context.Message.RequestUri = await HandleEndpointAsync(context.RequestService, endpointName, method, dictionary);
            }
            else
            {
                context.Message.Method = method;
                context.Message.RequestUri = await HandleEndpointAsync(context.RequestService, endpointName, method, dictionary);
                context.Message.Content = new StringContent(JsonSerializer.Serialize(dictionary));
            }

            await Task.CompletedTask;
        }

        protected virtual async Task<Uri> HandleEndpointAsync(IServiceProvider serviceProvider, string endpointName, HttpMethod method, WeChatDictionary dictionary)
        {
            var options = serviceProvider.GetRequiredService<IOptions<WeChatOptions>>().Value;
            var endpoint = options.GetEndpoint(endpointName);

            return (method.Equals(HttpMethod.Get), (this) is IEnableAccessToken) switch
            {
                (true, true) => await GetTokenUri(),
                (true, false) => new Uri($"{endpoint}?{HttpUtility.ToQuery(dictionary)}"),
                (false, false) => new Uri(endpoint),
                _ => await GetTokenPostUri()
            };

            async Task<Uri> GetTokenUri()
            {
                var tokenStore = serviceProvider.GetRequiredService<IAccessTokenStore>();
                var accessToken = await tokenStore.GetAsync(ConfigurationFactory);
                dictionary["access_token"] = accessToken;
                return new Uri($"{endpoint}?{HttpUtility.ToQuery(dictionary)}");
            }

            async Task<Uri> GetTokenPostUri()
            {
                var tokenStore = serviceProvider.GetRequiredService<IAccessTokenStore>();
                var accessToken = await tokenStore.GetAsync(ConfigurationFactory);
                dictionary["access_token"] = accessToken;
                return new Uri($"{endpoint}?access_token={accessToken}");
            }
        }

        public override async Task<TWeChatResponse> ParserAsync(IHttpResponseContext context)
        {
            var content = await context.Message.Content.ReadAsByteArrayAsync();
            var response = JsonSerializer.Deserialize<TWeChatResponse>(content);

            response.Raw = content;
            return response;
        }

        public virtual WeChatDictionary ToDictionary()
        {
            var dictionary = new WeChatDictionary();
            using var document = JsonDocument.Parse(JsonSerializer.Serialize((object)this));

            foreach (var jsonProperty in document.RootElement.EnumerateObject())
            {
                var value = jsonProperty.Value.GetString();
                if (!string.IsNullOrEmpty(value))
                {
                    dictionary[jsonProperty.Name] = value;
                }
            }

            return dictionary;
        }

        /// <summary>
        /// 主要参数处理
        /// </summary>
        /// <param name="configuration"></param>
        protected virtual void ParameterHandler(WeChatConfiguration configuration)
        {
        }

        /// <summary>
        /// 获取Http请求方法
        /// </summary>
        /// <returns></returns>
        protected virtual HttpMethod GetHttpMethod() => HttpMethod.Get;

        /// <summary>
        /// 获取端点名称
        /// </summary>
        /// <returns></returns>
        protected abstract string GetEndpointName();
    }
}
