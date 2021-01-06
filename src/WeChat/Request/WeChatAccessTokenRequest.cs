
using WeChat.Response;

namespace WeChat.Request
{
    /// <summary>
    /// 微信 access_token 请求
    /// </summary>
    public class WeChatAccessTokenRequest : WeChatHttpRequestBase<WeChatAccessTokenResponse>
    {
        protected override string GetEndpointName() => WeChatEndpoints.AccessToken;

        protected override void ParameterHandler(WeChatConfiguration configuration)
        {
            Body
                .Set("appid", configuration.AppId)
                .Set("secret", configuration.Secret)

                .Set("grant_type", "client_credential");
        }
    }
}
