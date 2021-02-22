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
        /// 获取指定配置的access_token
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="secret"></param>
        /// <returns></returns>
        Task<string> GetAsync(string appId, string secret);
    }
}
