using Mediator.HttpClient;

using Microsoft.Extensions.DependencyInjection;

using System.Threading.Tasks;

using WeChat.Mp.Response;

namespace WeChat.Mp.Request
{
    public class WeChatJsapiConfigRequest : WeChatRequestBase<WeChatJsapiConfigResponse>
    {
        public WeChatJsapiConfigRequest(string url)
        {
            Url = url;
        }

        public string Url { get; set; }

        public override async Task<WeChatJsapiConfigResponse> HandleAsync(IWeChatRequetHandleContext context)
        {
            var configuration = ConfigurationFactory(context.RequestService, WeChatEndpoints.Ticket);

            //获取凭证
            var ticketStore = context.RequestService.GetRequiredService<IJsapiTicketStore>();
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
