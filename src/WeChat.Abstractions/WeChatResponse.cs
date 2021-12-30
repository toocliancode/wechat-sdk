using System.Text.Json.Serialization;
using System.Xml.Serialization;
namespace WeChat;

[XmlRoot("xml")]
public class WeChatResponse
{
    [JsonIgnore]
    [XmlIgnore]
    public byte[] Raw { get; set; }

    public virtual bool IsSucceed()
    {
        return Raw == null;
    }
}