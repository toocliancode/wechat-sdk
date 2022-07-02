namespace WeChat.Applet.Checks;

public class WeChatAppletMsgSecCheckResponse : WeChatHttpResponse
{
    /// <summary>
    /// 综合了多个策略的结果给出了建议
    /// </summary>
    [JsonPropertyName("result")]
    public WeChatAppletSecCheckResult Result { get; set; }

    /// <summary>
    /// 包含多个策略类型的检测结果
    /// </summary>
    [JsonPropertyName("detail")]
    public List<WeChatAppletSecCheckDetail> Details { get; set; }

    /// <summary>
    /// 是否检测通过
    /// </summary>
    /// <returns></returns>
    public bool IsPass()
    {
        return IsSucceed() && Result.Suggest == "pass";
    }
}
