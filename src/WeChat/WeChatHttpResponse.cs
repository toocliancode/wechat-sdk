using System.Net;

namespace WeChat;

[Serializable]
public class WeChatHttpResponse : WeChatResponse
{
    [JsonIgnore]
    public virtual HttpStatusCode StatusCode { get; set; }

    public override bool IsSucceed()
    {
        return StatusCode == HttpStatusCode.OK;
    }
}
