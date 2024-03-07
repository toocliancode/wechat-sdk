namespace WeChat;

public interface IWeChatSerializer
{
    string Serialize(object obj);

    T Deserialize<T>(string json);
}
