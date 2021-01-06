
using System.Collections.Generic;
using System.Text.Encodings.Web;

namespace WeChat
{
    public class WeChatDictionary<T> : Dictionary<string, T>
    {
        public T GetValue(string key)
        {
            return TryGetValue(key, out var value) ? value : default;
        }
    }
}
