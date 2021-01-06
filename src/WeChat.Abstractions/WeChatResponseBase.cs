using System.Text.Json.Serialization;

namespace WeChat
{
    public abstract class WeChatResponseBase
    {
        [JsonIgnore]
        public byte[] Raw { get; set; }

        public virtual bool IsSuccessed()
        {
            return false;
        }
    }
}
