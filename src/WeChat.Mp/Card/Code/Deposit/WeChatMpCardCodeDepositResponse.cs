namespace WeChat.Mp.Card;

public class WeChatMpCardCodeDepositResponse
    : WeChatHttpResponse
{
    /// <summary>
    /// 成功个数
    /// </summary>
    [JsonPropertyName("succ_code")]
    public int SuccCode { get; set; }

    /// <summary>
    /// 重复导入的code会自动被过滤
    /// </summary>
    [JsonPropertyName("duplicate_code")]
    public int DuplicateCode { get; set; }

    /// <summary>
    /// 失败个数
    /// </summary>
    [JsonPropertyName("fail_code")]
    public int FailCode { get; set; }
}
