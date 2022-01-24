namespace WeChat.Applet.Urls;

public class WeChatAppletQuerySchemeResponse : WeChatHttpResponse
{
    /// <summary>
    /// scheme 配置
    /// </summary>
    [JsonPropertyName("scheme_info")]
    public WeChatAppletQuerySchemeInfo SchemeInfo { get; set; }

    /// <summary>
    /// quota 配置
    /// </summary>
    [JsonPropertyName("scheme_quota")]
    public WeChatAppletQuerySchemeQuota SchemeQuota { get; set; }
}

public class WeChatAppletQuerySchemeInfo
{
    /// <summary>
    /// 微信小程序应用号
    /// </summary>
    [JsonPropertyName("appid")]
    public string AppId { get; set; }

    /// <summary>
    /// 小程序页面路径
    /// </summary>
    [JsonPropertyName("path")]
    public string Path { get; set; }

    /// <summary>
    /// 小程序页面query
    /// </summary>
    [JsonPropertyName("query")]
    public string Query { get; set; }

    /// <summary>
    /// 创建时间，为 Unix 时间戳
    /// </summary>
    [JsonPropertyName("create_time")]
    public long CreateTime { get; set; }

    /// <summary>
    /// 到期失效时间，为 Unix 时间戳，0 表示永久生效
    /// </summary>
    [JsonPropertyName("expire_time")]
    public long ExpireTime { get; set; }

    /// <summary>
    /// 要打开的小程序版本。正式版为"release"，体验版为"trial"，开发版为"develop"
    /// </summary>
    [JsonPropertyName("env_version")]
    public string EnvVersion { get; set; }
}

public class WeChatAppletQuerySchemeQuota
{
    /// <summary>
    /// 长期有效 scheme 已生成次数
    /// </summary>
    [JsonPropertyName("long_time_used")]
    public long LongTimeUed { get; set; }

    /// <summary>
    /// 长期有效 scheme 生成次数上限
    /// </summary>
    [JsonPropertyName("long_time_limit")]
    public long LongTimeLimit { get; set; }
}
