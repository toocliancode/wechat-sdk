using Microsoft.Extensions.Configuration;

using System.Text.Json;

namespace WeChat;

/// <summary>
/// 微信配置
/// </summary>
public class WeChatConfiguration : WeChatDictionary
{
    /// <summary>
    /// 实例化一个微信配置
    /// </summary>
    public WeChatConfiguration()
    {
        Name = "WeChat";
    }

    /// <summary>
    /// 实例化一个微信配置
    /// </summary>
    public WeChatConfiguration(string name = "WeChat")
    {
        Name = name;
    }

    /// <summary>
    /// 实例化一个微信配置
    /// </summary>
    /// <param name="appId">微信应用号(公众平台AppId/开放平台AppId/小程序AppId/企业微信CorpId)</param>
    /// <param name="secret">微信应用密钥</param>
    public WeChatConfiguration(string appId, string secret) : this()
    {
        AppId = appId;
        Secret = secret;
    }

    /// <summary>
    /// 配置名称
    /// </summary>
    public string Name
    {
        get => GetValue("Name");
        set => TryAdd("Name", value);
    }

    /// <summary>
    /// 微信应用号(公众平台AppId/开放平台AppId/小程序AppId/企业微信CorpId)
    /// </summary>
    public string AppId
    {
        get => GetValue(WeChatConstants.AppId);
        set => TryAdd(WeChatConstants.AppId, value);
    }

    /// <summary>
    /// 微信应用密钥
    /// </summary>
    public string Secret
    {
        get => GetValue(WeChatConstants.Secret);
        set => TryAdd(WeChatConstants.Secret, value);
    }

    /// <summary>
    /// 配置键值appId、secret
    /// </summary>
    /// <param name="appId">微信应用号(公众平台AppId/开放平台AppId/小程序AppId/企业微信CorpId)</param>
    /// <param name="secret">微信应用密钥</param>
    public WeChatConfiguration Configure(string appId, string secret)
    {
        AppId = appId;
        Secret = secret;
        return this;
    }

    /// <summary>
    /// 设置配置名称
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public WeChatConfiguration Configure(string name)
    {
        Name = name;
        return this;
    }

    /// <summary>
    /// 从<see cref="IConfiguration"/>配置
    /// </summary>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public IWeChatSettings Configure(IConfiguration configuration)
    {
        return Configure<WeChatSettings>(configuration);
    }

    /// <summary>
    /// 从<see cref="IConfiguration"/>配置
    /// </summary>
    /// <typeparam name="TWeChatSettings"></typeparam>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public TWeChatSettings Configure<TWeChatSettings>(IConfiguration configuration)
        where TWeChatSettings : IWeChatSettings
    {
        var options = configuration.Get<TWeChatSettings>();

        Configure(options);

        return options;
    }

    /// <summary>
    /// 从<see cref="IWeChatSettings"/>配置
    /// </summary>
    /// <param name="options"></param>
    public WeChatConfiguration Configure(IWeChatSettings options)
    {
        using var document = JsonDocument.Parse(JsonSerializer.Serialize((object)options));
        foreach (var jsonProperty in document.RootElement.EnumerateObject())
        {
            this[jsonProperty.Name] = jsonProperty.Value.GetString();
        }
        return this;
    }

    /// <summary>
    /// 获取配置
    /// </summary>
    /// <typeparam name="TWeChatSettings"></typeparam>
    /// <returns></returns>
    public TWeChatSettings Get<TWeChatSettings>()
        where TWeChatSettings : IWeChatSettings
    {
        return JsonSerializer.Deserialize<TWeChatSettings>(JsonSerializer.Serialize((object)this));
    }
}
