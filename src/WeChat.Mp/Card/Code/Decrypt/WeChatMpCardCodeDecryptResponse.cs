namespace WeChat.Mp.Card;

public class WeChatMpCardCodeDecryptResponse
    : WeChatHttpResponse
{
    /// <summary>
    /// 解密后获取的真实Code
    /// </summary>
    [JsonPropertyName("code")]
    public string Code { get; set; }
}
