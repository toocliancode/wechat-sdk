using System.Security.Cryptography;
using System.Text;

namespace WeChat;

public static class WeChatSignature
{
    public static string Sign(IDictionary<string, string> dictionary, string signType)
    {
        var sb = new StringBuilder();
        foreach (var iter in dictionary)
        {
            if (!string.IsNullOrEmpty(iter.Value) && iter.Key != "sign")
            {
                sb.Append(iter.Key).Append('=').Append(iter.Value).Append('&');
            }
        }

        var signContent = sb.ToString().TrimEnd('&');

        return signType switch
        {
            WeChatSignType.MD5 => signContent.MD5Encrypt().ToUpperInvariant(),
            WeChatSignType.SHA1 => signContent.SHA1Encrypt().ToUpperInvariant(),
            WeChatSignType.HMAC_SHA256 => signContent.SHA256Encrypt().ToUpperInvariant(),
            _ => throw new ArgumentException("Unknown sign type!"),
        };
    }

    public static string SignWithKey(WeChatDictionary dictionary, string key, string signType)
    {
        var sb = new StringBuilder();
        foreach (var iter in dictionary)
        {
            if (!string.IsNullOrEmpty(iter.Value) && iter.Key != "sign")
            {
                sb.Append(iter.Key).Append('=').Append(iter.Value).Append('&');
            }
        }

        var signContent = sb.Append("key=").Append(key).ToString();

        return signType switch
        {
            WeChatSignType.MD5 => signContent.MD5Encrypt().ToUpperInvariant(),
            WeChatSignType.SHA1 => signContent.SHA1Encrypt().ToUpperInvariant(),
            WeChatSignType.HMAC_SHA256 => signContent.SHA256Encrypt().ToUpperInvariant(),
            _ => throw new ArgumentException("Unknown sign type!"),
        };
    }
    public static string SignWithSecret(WeChatDictionary dictionary, string secret, List<string> include)
    {
        var sb = new StringBuilder();
        foreach (var iter in dictionary)
        {
            if (!string.IsNullOrEmpty(iter.Value) && include.Contains(iter.Key))
            {
                sb.Append(iter.Key).Append('=').Append(iter.Value).Append('&');
            }
        }

        var signContent = sb.Append("secret=").Append(secret).ToString();
        return signContent.MD5Encrypt().ToUpperInvariant();
    }

    /// <summary>
    /// MD5 加密
    /// </summary>
    /// <param name="input">明文</param>
    /// <param name="encoding">字符编码</param>
    /// <returns>密文</returns>
    public static string MD5Encrypt(
        this string input,
        Encoding? encoding = null)
    {
        encoding ??= Encoding.UTF8;

        using var md5Hasher = MD5.Create();
        var data = md5Hasher.ComputeHash(encoding.GetBytes(input));
        var sBuilder = new StringBuilder();

        foreach (var item in data)
        {
            sBuilder.Append(item.ToString("x2"));
        }

        return sBuilder.ToString();
    }

    /// <summary>
    /// SHA1 加密
    /// </summary>
    /// <param name="input">明文</param>
    /// <param name="encoding">字符编码</param>
    /// <returns>密文</returns>
    public static string SHA1Encrypt(
        this string input,
        Encoding? encoding = null)
    {
        encoding ??= Encoding.UTF8;

        using var sha1 = SHA1.Create();
        var data = sha1.ComputeHash(encoding.GetBytes(input));
        var sBuilder = new StringBuilder();
        foreach (var item in data)
        {
            sBuilder.Append(item.ToString("x2"));
        }
        return sBuilder.ToString();
    }

    /// <summary>
    /// SHA256 加密
    /// </summary>
    /// <param name="input">明文</param>
    /// <param name="encoding">字符编码</param>
    /// <returns>密文</returns>
    public static string SHA256Encrypt(
        this string input,
        Encoding? encoding = null)
    {
        encoding ??= Encoding.UTF8;

        using var sha256 = SHA256.Create();
        var bytes = encoding.GetBytes(input);
        var data = sha256.ComputeHash(bytes);
        return Convert.ToBase64String(data);
    }

}
