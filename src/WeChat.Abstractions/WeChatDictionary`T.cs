namespace WeChat;

public class WeChatDictionary<T> : Dictionary<string, T>
{
    public T? GetValue(string key)
    {
        return TryGetValue(key, out var value) ? value : default;
    }

    public void AddRange(IDictionary<string, T> dict)
    {
        if (dict == null || dict.Count == 0)
        {
            return;
        }
        foreach (var item in dict)
        {
            TryAdd(item.Key, item.Value);
        }
    }

    public new bool TryAdd(string key, T value)
    {
        if (string.IsNullOrWhiteSpace(key))
        {
            return false;
        }
        this[key] = value;
        return true;
    }

    public new void Add(string key, T value)
    {
        TryAdd(key, value);
    }

    public WeChatDictionary<T> Set(string key, T value)
    {
        TryAdd(key, value);
        return this;
    }

    public WeChatDictionary<string?> ToStringValue()
    {
        var dict = new WeChatDictionary<string?>();
        foreach (var item in this)
        {
            dict.Add(item.Key, item.Value?.ToString());
        }
        return dict;
    }
}
