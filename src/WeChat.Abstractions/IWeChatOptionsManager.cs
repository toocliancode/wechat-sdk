namespace WeChat;

public interface IWeChatOptionsManager
{
    Task<WeChatOptions> GetAsync(string? name = default);
}
