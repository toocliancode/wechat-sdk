namespace WeChat;

public interface IWeChatPayOptionsManager
{
    Task<WeChatPayOptions> GetAsync(string? name = default);
}
