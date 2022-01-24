using System.Net;
using System.Text.Json.Serialization;

namespace WeChat;

[Serializable]
public class WeChatHttpResponseBase : WeChatResponse
{

    [JsonIgnore]
    public HttpStatusCode StatusCode { get; set; }

    public override bool IsSucceed()
    {
        return StatusCode == HttpStatusCode.OK;
    }
}
