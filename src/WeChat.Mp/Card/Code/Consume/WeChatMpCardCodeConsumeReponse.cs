namespace WeChat.Mp.Card;

public class WeChatMpCardCodeConsumeReponse
    : WeChatHttpResponse
{
    /// <summary>
    /// 用户在该公众号内的唯一身份标识
    /// </summary>
    [JsonPropertyName("openid")]
    public string OpenId { get; set; }

    /// <summary>
    /// 卡券
    /// </summary>
    [JsonPropertyName("card")]
    public WeChatMpCardCodeConsumeCardModel Card { get; set; }
}
