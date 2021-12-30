namespace WeChat.Mp.Media;

public class WeChatMpMediaUploadImgResponse
    : WeChatHttpResponse
{
    /// <summary>
    /// 商户图片url，用于创建卡券接口中填入。
    /// 特别注意：该链接仅用于微信相关业务，不支持引用。
    /// </summary>
    [JsonPropertyName("url")]
    public string Url { get; set; }
}