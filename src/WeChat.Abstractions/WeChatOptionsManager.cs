﻿using Microsoft.Extensions.Configuration;

namespace WeChat;

public class WeChatOptionsManager : IWeChatOptionsManager
{
    protected IConfiguration Configuration { get; }

    public WeChatOptionsManager(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public Task<WeChatOptions> GetAsync(string? name = default)
    {
        name ??= "Default";
        var options = new WeChatOptions();
        Configuration
            .GetSection("WeChat")
            .GetSection(name)
            .Bind(options);

        return Task.FromResult(options);
    }
}
