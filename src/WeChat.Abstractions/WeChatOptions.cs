using System.Collections.Generic;

namespace WeChat
{
    /// <summary>
    /// 微信配置选项
    /// </summary>
    public class WeChatOptions
    {
        /// <summary>
        /// 端点
        /// </summary>
        public IDictionary<string, string> Endpoints { get; } = new Dictionary<string, string>();

        ///// <summary>
        ///// 默认配置
        ///// </summary>
        //public WeChatConfiguration Configuration { get; } = new WeChatConfiguration();

        /// <summary>
        /// 微信配置
        /// 名称：微信应用配置
        /// </summary>
        public IDictionary<string, WeChatConfiguration> Configurations { get; } = new Dictionary<string, WeChatConfiguration>();

        /// <summary>
        /// 添加或修改端点
        /// </summary>
        /// <param name="endpointName">端点名称</param>
        /// <param name="endpointValue">端点</param>
        public void AddOrUpdateEndpoint(string endpointName, string endpointValue)
        {
            Endpoints[endpointName] = endpointValue;
        }

        /// <summary>
        /// 添加或修改端点
        /// </summary>
        /// <param name="endpoints"></param>
        public void AddOrUpdateEndpoints(IDictionary<string, string> endpoints)
        {
            foreach (var item in endpoints)
            {
                AddOrUpdateEndpoint(item.Key, item.Value);
            }
        }

        /// <summary>
        /// 获取端点
        /// </summary>
        /// <param name="endpointName">端点名称</param>
        /// <returns></returns>
        public string GetEndpoint(string endpointName)
        {
            if (Endpoints.TryGetValue(endpointName, out string endpoint))
            {
                return endpoint;
            }

            throw new KeyNotFoundException($"未找到名为{endpointName}的端点，需进行配置");
        }

        /// <summary>
        /// 根据配置名称获取配置
        /// </summary>
        /// <param name="configurationName">配置名称。例如：wecaht</param>
        /// <returns></returns>
        public WeChatConfiguration GetConfiguration(string configurationName)
        {
            if (Configurations.TryGetValue(configurationName, out var configuration))
            {
                return configuration;
            }
            throw new KeyNotFoundException($"未找到名为{configurationName}的配置");
        }
    }
}
