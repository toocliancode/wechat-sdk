namespace WeChat;

public static class WeChatOptionsManagerExtensions
{
    public static Task<TOptions> GetDefaultAsync<TOptions>(this IWeChatOptionsManager manager) where TOptions : WeChatOptions, new()
    {
        return manager.GetAsync<TOptions>();
    }
}