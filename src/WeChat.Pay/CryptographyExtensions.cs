using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Parameters;

using System.Security.Cryptography;
using System.Text;

namespace WeChat;

internal static class CryptographyExtensions
{
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

        var cipher = new GcmBlockCipher(new AesEngine());
        var parameters = new AeadParameters(
            new KeyParameter(Encoding.UTF8.GetBytes(key)),
            128,
            Encoding.UTF8.GetBytes(nonce),
            Encoding.UTF8.GetBytes(associatedData));

        cipher.Init(false, parameters);

        var data = Convert.FromBase64String(ciphertext);
        var plaintext = new byte[cipher.GetOutputSize(data.Length)];
        int length = cipher.ProcessBytes(data, 0, data.Length, plaintext, 0);

        cipher.DoFinal(plaintext, length);

        return Encoding.UTF8.GetString(plaintext);

        //using var aesGcm = new AesGcm(Encoding.UTF8.GetBytes(key), 16);
        //var nonceBytes = Encoding.UTF8.GetBytes(nonce);
        //var ciphertextWithTagBytes = Convert.FromBase64String(ciphertext); // ciphertext 实际包含了 tag，即尾部16字节
        //var ciphertextBytes = ciphertextWithTagBytes[0..^16]; // 排除尾部16字节
        //var tagBytes = ciphertextWithTagBytes[^16..]; // 获取尾部16字节
        //var plaintextBytes = new byte[ciphertextBytes.Length];
        //var associatedDataBytes = Encoding.UTF8.GetBytes(associatedData);
        //aesGcm.Decrypt(nonceBytes, ciphertextBytes, tagBytes, plaintextBytes, associatedDataBytes);
        //return Encoding.UTF8.GetString(plaintextBytes);
    }

    public static string SHA256WithRSAEncrypt(RSA rsa, string data)
    {
        if (rsa is null)
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
        if (rsa is null)
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