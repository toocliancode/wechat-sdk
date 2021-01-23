using Mediator.HttpClient;

using Microsoft.Extensions.DependencyInjection;

using System.Text.Json.Serialization;
using System.Threading.Tasks;

using WeChat.Mp.Response;

namespace WeChat.Mp.Request
{
    /// <summary>
    /// 微信jssdk配置 请求
    /// </summary>
    public class WeChatJsapiConfigRequest : WeChatRequestBase<WeChatJsapiConfigResponse>
    {
        /// <summary>
        /// 实例化一个新的 微信jssdk配置 请求
        /// </summary>
        /// <param name="url">需要微信jssdk配置 的页面链接</param>
        public WeChatJsapiConfigRequest(string url)
        {
            Url = url;
        }

        /// <summary>
        /// 需要微信jssdk配置 的页面链接
        /// </summary>
        [JsonPropertyName("url")]
        public string Url { get; set; }

        public override async Task<WeChatJsapiConfigResponse> Handler(IWeChatRequetHandleContext context)
        {
            var configuration = ConfigurationFactory(context.RequestServices, WeChatEndpoints.Ticket);

            //获取凭证
            var ticketStore = context.RequestServices.GetRequiredService<IWeChatJsapiTicketStore>();
            var jsapiTicket = await ticketStore.GetAsync(ConfigurationFactory);

            // 设置随机字符串
            var noncestr = HttpUtility.GenerateNonceStr();
            // 设置时间戳
            var timestamp = HttpUtility.GetTimeStamp();

            var dictionary = new WeChatDictionary
            {
                {"noncestr",noncestr },
                {"timestamp",timestamp },
                {"url",Url },
                {"jsapi_ticket",jsapiTicket }
            };

            var response = new WeChatJsapiConfigResponse(configuration.AppId, timestamp, noncestr)
            {
                Signature = WeChatSignature.Sign(dictionary, WeChatSignType.SHA1)
            };
            return response;
        }
    }
}
