using System.Text.Json.Serialization;

namespace WeChat.Applet.Urls;

/// <summary>
/// 跳转到的目标小程序信息
/// </summary>
public class GenerateSchemeJumpWxa
{
    /// <summary>
    /// 通过 scheme 码进入的小程序页面路径，必须是已经发布的小程序存在的页面，不可携带 query。path 为空时会跳转小程序主页。
    /// </summary>
    [JsonPropertyName("path")]
    public string Path { get; set; }

    /// <summary>
    /// 通过 scheme 码进入小程序时的 query，最大1024个字符，只支持数字，大小写英文以及部分特殊字符：!#$&amp;'()*+,/:;=?@-._~%
    /// </summary>
    [JsonPropertyName("query")]
    public string Query { get; set; }
}
