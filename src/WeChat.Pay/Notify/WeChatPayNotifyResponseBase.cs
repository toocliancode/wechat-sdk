using System.Text.Json.Serialization;

namespace WeChat.Pay.Notify;

public class WeChatPayNotifyResponseBase
{
    /// <summary>
    /// 通知明文内容
    /// </summary>
    [JsonIgnore]
    public string ResourcePlaintext { get; set; }
}
