using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

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
        /// <summary>
        /// 实例化一个新的 微信开放数据解密 请求
        /// </summary>
        /// <param name="sessionKey">会话密钥</param>
        /// <param name="encryptedData">加密字符串</param>
        /// <param name="iv">加密向量</param>
        public DecryptRequest(string sessionKey, string encryptedData, string iv)
        {
            SessionKey = sessionKey;
            EncryptedData = encryptedData;
            Iv = iv;
        }

        ///// <summary>
        ///// 微信应用号
        ///// </summary>
        //public string AppId { get; set; }

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

        public override Task<TDecryptResponse> Handler(IWeChatRequetHandleContext context)
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

            var options = context.RequestServices.GetRequiredService<IOptions<WeChatOptions>>().Value;

            if (string.IsNullOrWhiteSpace(Configuration.AppId))
            {
                var configuration = options.GetConfiguration(Configuration.Name);
                Configuration.Configure(configuration.AppId, configuration.Secret);
            }
            if (Configuration.AppId != response?.Watermark?.AppId)
            {
                throw new ArgumentException("AppId不匹配");
            }

            return Task.FromResult(response);
        }
    }
}
