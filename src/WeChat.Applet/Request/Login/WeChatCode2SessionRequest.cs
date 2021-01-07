using System.Text.Json.Serialization;

using WeChat.Applet.Response;

namespace WeChat.Applet.Request
{
    /// <summary>
    /// 登录凭证校验。通过 wx.login 接口获得临时登录凭证 code 后传到开发者服务器调用此接口完成登录流程。更多使用方法详见
    /// https://developers.weixin.qq.com/miniprogram/dev/api-backend/open-api/login/auth.code2Session.html
    /// </summary>
    public class WeChatCode2SessionRequest : WeChatHttpRequestBase<WeChatCode2SessionResponse>
    {
        protected override string GetEndpointName() => WeChatAppletEndpoints.Code2Session;

        /// <summary>
        /// 登录时获取的 code
        /// </summary>
        [JsonPropertyName("js_code")]
        public string JsCode { get; set; }

        ///// <summary>
        ///// 授权类型，此处只需填写 authorization_code
        ///// </summary>
        //[JsonPropertyName("grent_code")]
        //public string GrantType => "authorization_code";

        protected override void ParameterHandler(WeChatConfiguration configuration)
        {
            Body
                .Set("js_code", JsCode)
                .Set("grent_code", "authorization_code");
        }
    }
}
