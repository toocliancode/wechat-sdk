using System.Xml.Serialization;

namespace WeChat;

public class WeChatXmlSerializer : IWeChatXmlSerializer
{
    public T Deserialize<T>(byte[] stream) where T : class, new()
    {
        var type = typeof(T);
        var xmlSerializer = new XmlSerializer(type);
        T? obj = null;
        try
        {
            obj = (T?)xmlSerializer.Deserialize(new MemoryStream(stream)) ?? new();
            if (obj is WeChatResponse response)
            {
                response.Raw = stream;
            }
        }
        catch
        {
        }

        obj ??= new();
        return obj;
    }

    public string Serialize<T>(T obj) where T : class, new()
    {
        var xmlSerializer = new XmlSerializer(typeof(T));
        using var writer = new StringWriter();
        xmlSerializer.Serialize(writer, obj);
        return writer.ToString();
    }
}
