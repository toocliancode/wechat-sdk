namespace WeChat;

/// <summary>
/// 【微信小程序】 acces_token 存储器
/// </summary>
public interface IWeChatAppletAccessTokenStore
{
    Task<string> GetAsync();
}