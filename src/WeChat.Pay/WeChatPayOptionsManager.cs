using Microsoft.Extensions.Configuration;

namespace WeChat;

public class WeChatPayOptionsManager : IWeChatPayOptionsManager
{
    protected IConfiguration Configuration { get; }

    public WeChatPayOptionsManager(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public Task<WeChatPayOptions> GetAsync(string? name = default)
    {
        name ??= "Default";
        var options = new WeChatPayOptions();
        Configuration
            .GetSection("WeChat")
            .GetSection(name)
            .Bind(options);

        return Task.FromResult(options);
    }
}