namespace WeChat.Applet.Checks;

/// <summary>
/// 策略类型的检测结果
/// </summary>
public class WeChatAppletSecCheckDetail
{
    /// <summary>
    /// 策略类型
    /// </summary>
    [JsonPropertyName("strategy")]
    public string Strategy { get; set; }

    /// <summary>
    /// 错误码，仅当该值为0时，该项结果有效
    /// </summary>
    [JsonPropertyName("errcode")]
    public int ErrCode { get; set; }

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

    /// <summary>
    /// 0-100，代表置信度，越高代表越有可能属于当前返回的标签（label）
    /// </summary>
    [JsonPropertyName("prob")]
    public int Prob { get; set; }

    /// <summary>
    /// 命中的自定义关键词
    /// </summary>
    [JsonPropertyName("keyword")]
    public string Keyword { get; set; }

}