namespace WeChat;

public interface IWeChatOptionsManager
{
    Task<TOptions> GetAsync<TOptions>(string? name = default, TOptions? options = default) where TOptions : WeChatOptions, new();
}
