using System;
using System.Threading.Tasks;

namespace WeChat
{
    /// <summary>
    /// 微信jsapi凭据存储
    /// </summary>
    public interface IWeChatJsapiTicketStore
    {
        /// <summary>
        /// 获取默认配置凭证
        /// </summary>
        /// <param name="ticketType">凭证类型：jsapi、wx_card</param>
        /// <returns></returns>
        Task<string> GetAsync(string ticketType = "jsapi");

        /// <summary>
        /// 获取指定配置凭证
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="ticketType"></param>
        /// <returns></returns>
        Task<string> GetAsync(WeChatConfiguration configuration, string ticketType = "jsapi");

        /// <summary>
        /// 获取指定端点凭证
        /// </summary>
        /// <param name="factory"></param>
        /// <param name="ticketType"></param>
        /// <returns></returns>
        Task<string> GetAsync(Func<IServiceProvider, string, WeChatConfiguration> factory, string ticketType = "jsapi");
    }
}
