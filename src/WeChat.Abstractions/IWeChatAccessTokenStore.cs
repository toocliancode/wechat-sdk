using System;
using System.Threading.Tasks;

namespace WeChat
{
    /// <summary>
    /// 微信acces_token存储
    /// </summary>
    public interface IWeChatAccessTokenStore
    {
        /// <summary>
        /// 获取默认配置的access_token
        /// </summary>
        /// <returns></returns>
        Task<string> GetAsync();

        /// <summary>
        /// 获取指定端点配置的access_token
        /// </summary>
        /// <param name="factory"></param>
        /// <returns></returns>
        Task<string> GetAsync(Func<IServiceProvider, string, WeChatConfiguration> factory);

        /// <summary>
        /// 获取指定配置的access_token
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        Task<string> GetAsync(WeChatConfiguration configuration);
    }
}
