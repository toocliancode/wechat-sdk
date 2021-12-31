namespace WeChat.Mp.Card;

public class WeChatMpCardUpdateResponse
    : WeChatHttpResponse
{
    /// <summary>
    /// 是否提交审核，false为修改后不会重新提审，true为修改字段后重新提审，该卡券的状态变为审核中
    /// </summary>
    [JsonPropertyName("send_check")]
    public bool SendCheck { get; set; }
}
