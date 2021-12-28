
using System.Text.Json.Serialization;

namespace WeChat.Applet.Urls;

public class WeChatAppletQueryUrlLinkResponse : WeChatResponse
{
    /// <summary>
    /// scheme 配置
    /// </summary>
    [JsonPropertyName("scheme_info")]
    public WeChatAppletQueryUrlLinkInfo SchemeInfo { get; set; }

    /// <summary>
    /// quota 配置
    /// </summary>
    [JsonPropertyName("scheme_quota")]
    public WeChatAppletQueryUrlLinkQuota SchemeQuota { get; set; }
}

public class WeChatAppletQueryUrlLinkInfo
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

    /// <summary>
    /// 云开发配置
    /// </summary>
    [JsonPropertyName("cloud_base")]
    public WeChatAppletQueryUrlLinkCloudBase CloudBase { get; set; }
}

public class WeChatAppletQueryUrlLinkCloudBase
{
    /// <summary>
    /// 云开发环境
    /// </summary>
    [JsonPropertyName("env")]
    public string Env { get; set; }

    /// <summary>
    /// 静态网站自定义域名，不填则使用默认域名
    /// </summary>
    [JsonPropertyName("domain")]
    public string Domain { get; set; }

    /// <summary>
    /// 云开发静态网站 H5 页面路径，不可携带 query
    /// </summary>
    [JsonPropertyName("path")]
    public string Path { get; set; }

    /// <summary>
    /// 云开发静态网站 H5 页面 query 参数
    /// </summary>
    [JsonPropertyName("query")]
    public string Query { get; set; }

    /// <summary>
    /// 第三方批量代云开发时必填，表示创建该 env 的 appid （小程序/第三方平台）
    /// </summary>
    [JsonPropertyName("resource_appid")]
    public string ResourceAppId { get; set; }
}


public class WeChatAppletQueryUrlLinkQuota
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
