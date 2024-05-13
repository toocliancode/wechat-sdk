using System.Collections;

namespace WeChat;

#pragma warning disable CS8601

public class WeChatDictionary<T> : IDictionary<string, T>
{
    private readonly SortedDictionary<string, T> _dictionary = [];

    public ICollection<string> Keys => _dictionary.Keys;

    public ICollection<T> Values => _dictionary.Values;

    public int Count => _dictionary.Count;

    public bool IsReadOnly => false;

    public T this[string key]
    {
        get => _dictionary[key];
        set
        {
            if (key != null && value != null)
            {
                _dictionary[key] = value;
            }
        }
    }

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

    public bool TryAdd(string key, T? value)
    {
        if (string.IsNullOrWhiteSpace(key))
        {
            return false;
        }
        if (value == null)
        {
            return false;
        }
        this[key] = value;
        return true;
    }

    public void Add(string key, T value)
    {
        TryAdd(key, value);
    }

    public WeChatDictionary<T> Set(string key, T? value)
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

    public bool ContainsKey(string key) => _dictionary.ContainsKey(key);

    public bool Remove(string key) => _dictionary.Remove(key);

    public bool TryGetValue(string key, out T value) => _dictionary.TryGetValue(key, out value);

    public void Add(KeyValuePair<string, T> item) => Add(item.Key, item.Value);

    public void Clear() => _dictionary.Clear();

    public bool Contains(KeyValuePair<string, T> item) => _dictionary.Contains(item);

    public void CopyTo(KeyValuePair<string, T>[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }

    public bool Remove(KeyValuePair<string, T> item) => _dictionary.Remove(item.Key);

    public IEnumerator<KeyValuePair<string, T>> GetEnumerator() => _dictionary.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => _dictionary.GetEnumerator();

    public TValue GetValueOrDefault<TValue>(string key, TValue defaultValue)
    {
        if (_dictionary.TryGetValue(key, out var value) && value is TValue v)
        {
            return v;
        }

        if (defaultValue != null && defaultValue is T t)
        {
            Add(key, t);
        }

        return defaultValue;
    }
}
