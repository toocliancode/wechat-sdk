using Microsoft.Extensions.Configuration;

namespace WeChat;

public class WeChatOptionsManager : IWeChatOptionsManager
{
    protected IConfiguration Configuration { get; }

    public Task<TOptions> GetAsync<TOptions>(string? name = default, TOptions? options = default) where TOptions : WeChatOptions, new()
    {
        name ??= "Default";
        options ??= new TOptions();

        Configuration
            .GetSection("WeChat")
            .GetSection(name)
            .Bind(options);

        return Task.FromResult(options);
    }
}
