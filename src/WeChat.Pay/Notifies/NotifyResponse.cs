namespace WeChat.Pay;

public class NotifyResponse
{
    /// <summary>
    /// 通知明文内容
    /// </summary>
    [JsonIgnore]
    public string ResourcePlaintext { get; set; }
}
