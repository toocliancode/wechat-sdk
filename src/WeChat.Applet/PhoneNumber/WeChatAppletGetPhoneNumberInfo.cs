namespace WeChat.Applet;

public class WeChatAppletGetPhoneNumberInfo
{
    /// <summary>
    /// 用户绑定的手机号（国外手机号会有区号）
    /// </summary>
    [JsonPropertyName("phoneNumber")]
    public string PhoneNumber { get; set; }

    /// <summary>
    /// 没有区号的手机号
    /// </summary>
    [JsonPropertyName("purePhoneNumber")]
    public string PurePhoneNumber { get; set; }

    /// <summary>
    /// 区号
    /// </summary>
    [JsonPropertyName("countryCode")]
    public string CountryCode { get; set; }

    /// <summary>
    /// 数据水印
    /// </summary>
    [JsonPropertyName("watermark")]
    public WeChatWatermark Watermark { get; set; }
}