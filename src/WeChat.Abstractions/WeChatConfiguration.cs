using Microsoft.Extensions.Configuration;

using System.Text.Json;

namespace WeChat
{
    /// <summary>
    /// 微信配置
    /// </summary>
    public class WeChatConfiguration : WeChatDictionary
    {
        /// <summary>
        /// 实例化一个微信配置
        /// </summary>
        public WeChatConfiguration()
        {
        }

        /// <summary>
        /// 实例化一个微信配置
        /// </summary>
        /// <param name="appId">微信应用号(公众平台AppId/开放平台AppId/小程序AppId/企业微信CorpId)</param>
        /// <param name="secret">微信应用密钥</param>
        public WeChatConfiguration(string appId, string secret)
        {
            AppId = appId;
            Secret = secret;
        }

        /// <summary>
        /// 微信应用号(公众平台AppId/开放平台AppId/小程序AppId/企业微信CorpId)
        /// </summary>
        public string AppId
        {
            get => GetValue(WeChatConstants.AppId);
            set => Configure(WeChatConstants.AppId, value);
        }

        /// <summary>
        /// 微信应用密钥
        /// </summary>
        public string Secret
        {
            get => GetValue(WeChatConstants.Secret);
            set => Configure(WeChatConstants.Secret, value);
        }

        /// <summary>
        /// 配置键值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        private void Configure(string key, string value)
        {
            if (!string.IsNullOrWhiteSpace(key) && string.IsNullOrWhiteSpace(value))
            {
                this[key] = value;
            }
        }

        /// <summary>
        /// 从<see cref="IConfiguration"/>配置
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public IWeChatSettings Configure(IConfiguration configuration)
        {
            return Configure<WeChatSettings>(configuration);
        }

        /// <summary>
        /// 从<see cref="IConfiguration"/>配置
        /// </summary>
        /// <typeparam name="TWeChatOptions"></typeparam>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public TWeChatOptions Configure<TWeChatOptions>(IConfiguration configuration)
            where TWeChatOptions : IWeChatSettings
        {
            var options = configuration.Get<TWeChatOptions>();

            Configure(options);

            return options;
        }

        /// <summary>
        /// 从<see cref="IWeChatSettings"/>配置
        /// </summary>
        /// <param name="options"></param>
        public void Configure(IWeChatSettings options)
        {
            using var document = JsonDocument.Parse(JsonSerializer.Serialize((object)options));
            foreach (var jsonProperty in document.RootElement.EnumerateObject())
            {
                this[jsonProperty.Name] = jsonProperty.Value.GetString();
            }
        }

        /// <summary>
        /// 获取配置
        /// </summary>
        /// <typeparam name="TWeChatOptions"></typeparam>
        /// <returns></returns>
        public TWeChatOptions Get<TWeChatOptions>()
            where TWeChatOptions : IWeChatSettings
        {
            return JsonSerializer.Deserialize<TWeChatOptions>(JsonSerializer.Serialize((object)this));
        }
    }
}
