using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Mediator.HttpClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using WeChat.Applet.Response;

namespace WeChat.Applet.Request
{
    /// <summary>
    /// 登录凭证校验。通过 wx.login 接口获得临时登录凭证 code 后传到开发者服务器调用此接口完成登录流程。更多使用方法详见
    /// https://developers.weixin.qq.com/miniprogram/dev/api-backend/open-api/login/auth.code2Session.html
    /// </summary>
    public class WeChatCode2SessionRequest : WeChatAppletHttpRequestBase<WeChatCode2SessionResponse>
    {
        /// <summary>
        /// 实例化一个新的 登录凭证校验 请求
        /// </summary>
        /// <param name="jsCode">登录时获取的 code</param>
        public WeChatCode2SessionRequest(string jsCode)
        {
            JsCode = jsCode;
        }

        protected override string EndpointName => WeChatAppletEndpoints.Code2Session;

        /// <summary>
        /// 登录时获取的 code
        /// </summary>
        [JsonPropertyName("js_code")]
        public string JsCode { get; set; }

        /// <summary>
        /// 授权类型，此处只需填写 authorization_code
        /// </summary>
        [JsonPropertyName("grent_code")]
        public string GrantType => "authorization_code";

        public override Task Request(IHttpRequestContext context)
        {
            var options = context.RequestServices.GetRequiredService<IOptions<WeChatOptions>>().Value;

            if (string.IsNullOrWhiteSpace(Configuration.AppId))
            {
                var configuration = options.GetConfiguration(Configuration.Name);
                Configuration.Configure(configuration.AppId, configuration.Secret);
            }

            var endpoint = options.GetEndpoint(EndpointName);
            var body = new Dictionary<string, string>
            {
                ["appid"] = Configuration.AppId,
                ["secret"] = Configuration.Secret,
                ["js_code"] = JsCode,
                ["grent_code"] = GrantType
            };
            context.Message.RequestUri = new System.Uri($"{endpoint}?{HttpUtility.ToQuery(body)}");

            return Task.CompletedTask;
        }
    }
}
