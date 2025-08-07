namespace WeChat;

/// <summary>
/// 【微信公众号】 jsapi 凭据存储器
/// </summary>
public interface IWeChatMpTicketStore
{
    /// <summary>
    /// 获取指定配置凭证
    /// </summary>
    /// <param name="options"></param>
    /// <param name="ticketType">凭证类型：jsapi、wx_card</param>
    /// <returns></returns>
    Task<string> GetAsync(WeChatMpOptions options, string ticketType = "jsapi");
}
