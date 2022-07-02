namespace WeChat.Applet.Checks;

/// <summary>
/// 异步校验图片/音频是否含有违法违规内容通知
/// <a href="https://developers.weixin.qq.com/miniprogram/dev/api-backend/open-api/sec-check/security.mediaCheckAsync.html#%E5%BC%82%E6%AD%A5%E6%A3%80%E6%B5%8B%E7%BB%93%E6%9E%9C%E6%8E%A8%E9%80%81%E7%A4%BA%E4%BE%8B"></a>
/// </summary>
public class WeChatAppletMediaCheckAsyncNotify
    : WeChatHttpResponse
{
    /// <summary>
    /// 小程序的username
    /// </summary>
    [JsonPropertyName("ToUserName")]
    public string ToUserName { get; set; }

    /// <summary>
    /// 平台推送服务UserName
    /// </summary>
    [JsonPropertyName("FromUserName")]
    public string FromUserName { get; set; }

    /// <summary>
    /// 发送时间
    /// </summary>
    [JsonPropertyName("CreateTime")]
    public long CreateTime { get; set; }

    /// <summary>
    /// 默认为：Event
    /// </summary>
    [JsonPropertyName("MsgType")]
    public string MsgType { get; set; }

    /// <summary>
    /// 默认为：wxa_media_check
    /// </summary>
    [JsonPropertyName("Event")]
    public string Event { get; set; }

    /// <summary>
    /// 小程序的appid
    /// </summary>
    [JsonPropertyName("appid")]
    public string AppId { get; set; }

    /// <summary>
    /// 可用于区分接口版本
    /// </summary>
    [JsonPropertyName("version")]
    public int Version { get; set; }

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