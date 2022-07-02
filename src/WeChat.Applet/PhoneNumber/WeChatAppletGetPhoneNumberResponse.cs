namespace WeChat.Applet;

public class WeChatAppletGetPhoneNumberResponse
    : WeChatHttpResponse
{
    [JsonPropertyName("phone_info")]
    public WeChatAppletGetPhoneNumberInfo PhoneInfo { get; set; }
}
