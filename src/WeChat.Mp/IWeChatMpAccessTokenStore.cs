namespace WeChat;

/// <summary>
/// 【微信公众号】 access_token 存储器
/// </summary>
public interface IWeChatMpAccessTokenStore
{
    Task<string> GetAsync(WeChatMpOptions options);
}
