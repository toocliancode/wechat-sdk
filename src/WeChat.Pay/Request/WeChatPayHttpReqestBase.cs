using Mediator.HttpClient;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WeChat.Pay.Request
{
    public abstract class WeChatPayHttpReqestBase<TWeChatResponse> :WeChatHttpRequestBase<TWeChatResponse>
        where TWeChatResponse : WeChatResponseBase
    {
        public override Task Request(IHttpRequestContext context)
        {
            var endpointName = GetEndpointName();

            return base.Request(context);
        }

        //protected virtual Task HeaderHandler(IHttpRequestContext context)
        //{

        //    context.Message.Headers.Authorization = new AuthenticationHeaderValue("WECHATPAY2-SHA256-RSA2048", token);
        //    context.Message.Headers.UserAgent.Add(new ProductInfoHeaderValue(new ProductHeaderValue("Unknown")));
        //    context.Message.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //}

        public override HttpClient CreateClient(IHttpClientCreateContext context)
        {
            return context.HttpClientFactory.CreateClient();
        }
    }
}
