namespace WeChat;

/// <summary>
/// 微信xml序列化 
/// </summary>
public interface IWeChatXmlSerializer
{
    string Serialize<T>(T obj) where T : class, new();

    T Deserialize<T>(byte[] stream) where T : class, new();
}