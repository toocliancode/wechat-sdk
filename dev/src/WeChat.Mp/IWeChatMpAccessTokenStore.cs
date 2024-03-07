namespace WeChat;

/// <summary>
/// 【微信公众号】 acces_token 存储器
/// </summary>
public interface IWeChatMpAccessTokenStore
{
    Task<string> GetAsync();
}
