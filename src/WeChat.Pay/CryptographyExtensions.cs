using System.Security.Cryptography;
using System.Text;

namespace WeChat.Pay;

internal static class CryptographyExtensions
{
    /// <summary>
    /// MD5 加密
    /// </summary>
    /// <param name="input">需要加密的内容</param>
    /// <param name="encoding">字符编码</param>
    /// <returns></returns>
    public static string MD5Encrypt(this string input, Encoding? encoding = null)
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

    public static string AesGcmDecrypt(string nonce, string ciphertext, string associatedData, string key)
    {
        if (string.IsNullOrEmpty(nonce))
        {
            throw new ArgumentNullException(nameof(nonce));
        }

        if (string.IsNullOrEmpty(ciphertext))
        {
            throw new ArgumentNullException(nameof(ciphertext));
        }

        if (string.IsNullOrEmpty(associatedData))
        {
            throw new ArgumentNullException(nameof(associatedData));
        }

        if (string.IsNullOrEmpty(key))
        {
            throw new ArgumentNullException(nameof(key));
        }

        using var aesGcm = new AesGcm(Encoding.UTF8.GetBytes(key));
        var nonceBytes = Encoding.UTF8.GetBytes(nonce);
        var ciphertextWithTagBytes = Convert.FromBase64String(ciphertext); // ciphertext 实际包含了 tag，即尾部16字节
        var ciphertextBytes = ciphertextWithTagBytes[0..^16]; // 排除尾部16字节
        var tagBytes = ciphertextWithTagBytes[^16..]; // 获取尾部16字节
        var plaintextBytes = new byte[ciphertextBytes.Length];
        var associatedDataBytes = Encoding.UTF8.GetBytes(associatedData);
        aesGcm.Decrypt(nonceBytes, ciphertextBytes, tagBytes, plaintextBytes, associatedDataBytes);
        return Encoding.UTF8.GetString(plaintextBytes);
    }

    public static string SHA256WithRSAEncrypt(RSA rsa, string data)
    {
        if (rsa == null)
        {
            throw new ArgumentNullException(nameof(rsa));
        }

        if (string.IsNullOrEmpty(data))
        {
            throw new ArgumentNullException(nameof(data));
        }

        return Convert.ToBase64String(rsa.SignData(Encoding.UTF8.GetBytes(data), HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1));
    }

    public static bool SHA256WithRSAEqual(RSA rsa, string data, string sign)
    {
        if (rsa == null)
        {
            throw new ArgumentNullException(nameof(rsa));
        }

        if (string.IsNullOrEmpty(data))
        {
            throw new ArgumentNullException(nameof(data));
        }

        if (string.IsNullOrEmpty(sign))
        {
            throw new ArgumentNullException(nameof(sign));
        }

        return rsa.VerifyData(Encoding.UTF8.GetBytes(data), Convert.FromBase64String(sign), HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
    }
}
