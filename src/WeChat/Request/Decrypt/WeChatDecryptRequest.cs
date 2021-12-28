
using System.Security.Cryptography;
using System.Text.Json;

namespace WeChat.Decrypt;

/// <summary>
/// 微信开放数据解密 请求
/// </summary>
public class WeChatDecryptRequest<TDecryptResponse>
    : WeChatRequestBase<TDecryptResponse>
    where TDecryptResponse : WeCahtDecryptResponseBase
{
    /// <summary>
    /// 实例化一个新的 微信开放数据解密 请求
    /// </summary>
    /// <param name="appId">微信应用号</param>
    /// <param name="sessionKey">会话密钥</param>
    /// <param name="encryptedData">加密字符串</param>
    /// <param name="iv">加密向量</param>
    public WeChatDecryptRequest(string appId, string sessionKey, string encryptedData, string iv)
    {
        AppId = appId;
        SessionKey = sessionKey;
        EncryptedData = encryptedData;
        Iv = iv;
    }

    /// <summary>
    /// 微信应用号
    /// </summary>
    public string AppId { get; set; }

    /// <summary>
    /// 会话密钥
    /// </summary>
    public string SessionKey { get; set; }

    /// <summary>
    /// 加密字符串
    /// </summary>
    public string EncryptedData { get; set; }

    /// <summary>
    /// 加密向量
    /// </summary>
    public string Iv { get; set; }

    public override Task<TDecryptResponse> Handle(IWeChatRequetHandleContext context)
    {
        var aes = Aes.Create();
        aes.KeySize = 256;
        aes.BlockSize = 128;
        aes.Mode = CipherMode.CBC;
        aes.IV = Convert.FromBase64String(Iv ?? "");
        aes.Key = Convert.FromBase64String(SessionKey ?? "");
        aes.Padding = PaddingMode.PKCS7;

        var cipher = Convert.FromBase64String(EncryptedData ?? "");
        var decryptText = aes.CreateDecryptor().TransformFinalBlock(cipher, 0, cipher.Length);

        var response = JsonSerializer.Deserialize<TDecryptResponse>(decryptText);

        if (AppId != response?.Watermark?.AppId)
        {
            throw new ArgumentException("AppId不匹配");
        }

        return Task.FromResult(response);
    }
}
