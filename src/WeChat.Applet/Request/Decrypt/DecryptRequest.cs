using System;
using System.Security.Cryptography;
using System.Text.Json;
using System.Threading.Tasks;

using WeChat.Applet.Response.Decrypt;

namespace WeChat.Applet.Request.Decrypt
{
    /// <summary>
    /// 微信开放数据解密 请求
    /// </summary>
    //[OnHandler(typeof(DecryptRequestHandler<>))]
    public class DecryptRequest<TDecryptResponse> : WeChatRequestBase<TDecryptResponse>
        where TDecryptResponse : DecryptResponseBase
    {
        public string AppId { get; set; }

        public string SessionKey { get; set; }

        public string EncryptedData { get; set; }

        public string Iv { get; set; }

        public override Task<TDecryptResponse> HandleAsync(IWeChatRequetHandleContext context)
        {
            AesManaged aes = new AesManaged
            {
                KeySize = 256,
                BlockSize = 128,
                Mode = CipherMode.CBC,
                IV = Convert.FromBase64String(Iv ?? ""),
                Key = Convert.FromBase64String(SessionKey ?? ""),
                Padding = PaddingMode.PKCS7
            };

            var cipher = Convert.FromBase64String(EncryptedData ?? "");
            var decryptText = aes.CreateDecryptor().TransformFinalBlock(cipher, 0, cipher.Length);

            var response = JsonSerializer.Deserialize<TDecryptResponse>(decryptText);

            AppId ??= ConfigurationFactory(context.RequestService, "Decrypt").AppId;

            if (AppId != response?.Watermark?.AppId)
            {
                throw new ArgumentException("AppId不匹配");
            }

            return Task.FromResult(response);
        }
    }
}
