using System.Text.Json.Serialization;

namespace WeChat;

public class WeChatResponse : WeChatResponseBase
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

    public override bool IsSuccessed()
    {
        return ErrCode == 0;
    }
}
