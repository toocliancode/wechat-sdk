using System.Text.Json.Serialization;

namespace WeChat.Applet.Urls;

/// <summary>
/// 云开发静态网站自定义 H5 配置参数
/// </summary>
public class GenerateUrlLinkCcloudBase
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
    public string Path { get; set; } = "/";

    /// <summary>
    /// 云开发静态网站 H5 页面 query 参数，最大 1024 个字符，只支持数字，大小写英文以及部分特殊字符：!#$&amp;'()*+,/:;=?@-._~%
    /// </summary>
    [JsonPropertyName("query")]
    public string Query { get; set; }

    /// <summary>
    /// 第三方批量代云开发时必填，表示创建该 env 的 appid （小程序/第三方平台）
    /// </summary>
    [JsonPropertyName("resource_appid")]
    public string ResourceAppid { get; set; }
}
