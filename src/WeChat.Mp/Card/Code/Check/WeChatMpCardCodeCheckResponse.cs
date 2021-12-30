namespace WeChat.Mp.Card;

public class WeChatMpCardCodeCheckResponse
    : WeChatHttpResponse
{
    /// <summary>
    /// 已经成功存入的code
    /// </summary>
    [JsonPropertyName("exist_code")]
    public List<string> ExistCodes { get; set; }

    /// <summary>
    /// 没有存入的code
    /// </summary>
    [JsonPropertyName("not_exist_code")]
    public List<string> NotExistCodes { get; set; }
}
