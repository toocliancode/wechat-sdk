using System.Text.Encodings.Web;

namespace WeChat;

public class WeChatSerializer : IWeChatSerializer
{
    private readonly JsonSerializerOptions? JsonSerializerOptions = new()
    {
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        DictionaryKeyPolicy = JsonNamingPolicy.CamelCase
    };

    public T Deserialize<T>(string json)
    {
        return JsonSerializer.Deserialize<T>(json, JsonSerializerOptions)!;
    }

    public string Serialize(object obj)
    {
        return JsonSerializer.Serialize(obj, JsonSerializerOptions);
    }
}