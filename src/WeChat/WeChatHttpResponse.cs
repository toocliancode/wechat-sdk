namespace WeChat;

public class WeChatHttpResponse : WeChatHttpResponseBase
{
    /// <summary>
    /// 错误码
    /// </summary>
    [JsonPropertyName("errcode")]
    public int ErrCode { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("errmsg")]
    public string ErrMsg { get; set; }

    public override bool IsSucceed()
    {
        return ErrCode == 0;
    }
}