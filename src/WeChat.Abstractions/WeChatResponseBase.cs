using System.Net;
using System.Text.Json.Serialization;

namespace WeChat
{
    public class WeChatResponseBase
    {
        [JsonIgnore]
        public byte[] Raw { get; set; }

        [JsonIgnore]
        public HttpStatusCode StatusCode { get; set; }

        public virtual bool IsSuccessed()
        {
            return StatusCode == HttpStatusCode.OK;
        }
    }
}
