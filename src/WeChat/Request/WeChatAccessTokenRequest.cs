using System.Text.Json.Serialization;

using WeChat.Response;

namespace WeChat.Request
{
    /// <summary>
    /// 微信 access_token 请求
    /// 
    /// https://developers.weixin.qq.com/doc/offiaccount/Basic_Information/Get_access_token.html
    /// </summary>
    public class WeChatAccessTokenRequest : WeChatHttpRequestBase<WeChatAccessTokenResponse>
    {
        public WeChatAccessTokenRequest()
        {
        }

        public WeChatAccessTokenRequest(string appId, string secret)
        {
            AppId = appId;
            Secret = secret;
            Configuration.Configure(appId, secret);
        }

        protected override string EndpointName => WeChatEndpoints.AccessToken;

        /// <summary>
        /// 微信公众号、小程序 appid
        /// </summary>
        [JsonPropertyName("appid")]
        public string AppId { get; set; }

        /// <summary>
        /// 密钥
        /// </summary>
        [JsonPropertyName("secret")]
        public string Secret { get; set; }

        /// <summary>
        /// 授权类型
        /// </summary>
        [JsonPropertyName("grant_type")]
        public string GrantType { get; } = "client_credential";

        public override WeChatConfiguration Configure(IWeChatSettings settings)
        {
            AppId = settings.AppId;
            Secret = settings.Secret;

            return base.Configure(settings);
        }
    }
}
