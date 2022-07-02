namespace WeChat.Applet.Checks;

/// <summary>
/// 综合了多个策略的结果给出了建议
/// </summary>
public class WeChatAppletSecCheckResult
{
    /// <summary>
    /// 建议，有risky、pass、review三种值
    /// </summary>
    [JsonPropertyName("suggest")]
    public string Suggest { get; set; }

    /// <summary>
    /// 命中标签枚举值，100 正常；10001 广告；20001 时政；20002 色情；20003 辱骂；20006 违法犯罪；20008 欺诈；20012 低俗；20013 版权；21000 其他
    /// </summary>
    [JsonPropertyName("label")]
    public int Label { get; set; }
}
