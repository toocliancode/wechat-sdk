using System.Net;
using System.Text.Json.Serialization;

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
