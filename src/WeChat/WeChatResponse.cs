using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace WeChat;

[Serializable]
public class WeChatResponse
{
    [JsonIgnore]
    [XmlIgnore]
    public virtual byte[] Raw { get; set; }

    public virtual bool IsSucceed()
    {
        return Raw == null;
    }
}
