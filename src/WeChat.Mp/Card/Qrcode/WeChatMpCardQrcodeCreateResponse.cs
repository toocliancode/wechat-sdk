namespace WeChat.Mp.Card;

public class WeChatMpCardQrcodeCreateResponse
    : WeChatHttpResponse
{
    /// <summary>
    /// 获取的二维码ticket，凭借此ticket调用 通过ticket换取二维码接口 可以在有效时间内换取二维码
    /// </summary>
    [JsonPropertyName("ticket")]
    public string Ticket { get; set; }

    /// <summary>
    /// 二维码图片解析后的地址，开发者可根据该地址自行生成需要的二维码图片
    /// </summary>
    [JsonPropertyName("url")]
    public string? Url { get; set; }

    /// <summary>
    /// 二维码显示地址，点击后跳转二维码页面
    /// </summary>
    [JsonPropertyName("show_qrcode_url")]
    public string? ShowQrcodeUrl { get; set; }
}