using Mediator.HttpClient;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

using System;
using System.Net.Http;
using System.Text.Json;
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
        private Func<IServiceProvider, string, WeChatConfiguration> _configurationFactory = (prodiver, configurationName)
                          => prodiver.GetRequiredService<IOptions<WeChatOptions>>().Value.GetConfiguration(configurationName);

        private Action<IServiceProvider, WeChatConfiguration, WeChatDictionary<object>> _parameterFactory = (provider, configuration, body) => { };

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

        /// <summary>
        /// 配置获取委托方法
        /// </summary>
        public Func<IServiceProvider, string, WeChatConfiguration> ConfigurationFactory
        {
            get => _configurationFactory;
            set => _configurationFactory = value ?? throw new ArgumentNullException(nameof(ConfigurationFactory));
        }

        public override async Task Request(IHttpRequestContext context)
        {
            var endpointName = GetEndpointName();
            var configuration = ConfigurationFactory(context.RequestServices, endpointName);

            ParameterHandler(configuration);

            _parameterFactory?.Invoke(context.RequestServices, configuration, Body);

            var dictionary = Body;
            var method = GetHttpMethod();

            if (method.Equals(HttpMethod.Get))
            {
                context.Message.RequestUri = await HandleEndpointAsync(context.RequestServices, endpointName, method, dictionary);
            }
            else
            {
                context.Message.Method = method;
                context.Message.RequestUri = await HandleEndpointAsync(context.RequestServices, endpointName, method, dictionary);
                context.Message.Content = new StringContent(JsonSerializer.Serialize(dictionary));
            }

            await Task.CompletedTask;
        }

        protected virtual async Task<Uri> HandleEndpointAsync(
            IServiceProvider serviceProvider,
            string endpointName,
            HttpMethod method,
            WeChatDictionary<object> dictionary)
        {
            var options = serviceProvider.GetRequiredService<IOptions<WeChatOptions>>().Value;
            var endpoint = options.GetEndpoint(endpointName);

            return (method.Equals(HttpMethod.Get), (this) is IEnableAccessToken) switch
            {
                (true, true) => await GetTokenUri(),
                (true, false) => new Uri($"{endpoint}?{HttpUtility.ToQuery(dictionary.ToStringValue())}"),
                (false, false) => new Uri(endpoint),
                _ => await GetTokenPostUri()
            };

            async Task<Uri> GetTokenUri()
            {
                var tokenStore = serviceProvider.GetRequiredService<IWeChatAccessTokenStore>();
                var accessToken = await tokenStore.GetAsync(ConfigurationFactory);
                dictionary["access_token"] = accessToken;
                return new Uri($"{endpoint}?{HttpUtility.ToQuery(dictionary.ToStringValue())}");
            }

            async Task<Uri> GetTokenPostUri()
            {
                var tokenStore = serviceProvider.GetRequiredService<IWeChatAccessTokenStore>();
                var accessToken = await tokenStore.GetAsync(ConfigurationFactory);
                //dictionary["access_token"] = accessToken;
                return new Uri($"{endpoint}?access_token={accessToken}");
            }
        }

        public override async Task<TWeChatResponse> Response(IHttpResponseContext context)
        {
            var content = await context.Message.Content.ReadAsByteArrayAsync();
            var response = JsonSerializer.Deserialize<TWeChatResponse>(content);

            response.Raw = content;
            response.StatusCode = context.Message.StatusCode;
            return response;
        }

        public WeChatDictionary<object> Body { get; } = new WeChatDictionary<object>();

        /// <summary>
        /// 主要参数处理
        /// </summary>
        /// <param name="configuration"></param>
        protected virtual void ParameterHandler(WeChatConfiguration configuration)
        {
        }

        public Action<IServiceProvider, WeChatConfiguration, WeChatDictionary<object>> ParameterFactory { get => _parameterFactory; set => _parameterFactory = value; }

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

        public override HttpClient CreateClient(IHttpClientCreateContext context)
        {
            return context.HttpClientFactory.CreateClient("WeChatHttpClient");
        }
    }
}