using Mediator.HttpClient;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WeChat.Pay.Request
{
    public abstract class WeChatPayHttpReqestBase<TWeChatResponse> :WeChatHttpRequestBase<TWeChatResponse>
        where TWeChatResponse : WeChatResponseBase
    {
        protected override WeChatConfiguration Configuration => base.Configuration.Configure("WeCahtPay");
        protected override HttpMethod Method => HttpMethod.Post;

        /// <summary>
        /// 是否需要检查签名
        /// </summary>
        protected virtual bool EnabledSignatureCheck => true;

        public override HttpClient CreateClient(IHttpClientCreateContext context) => context.HttpClientFactory.CreateClient(Configuration.Name);

        public override async Task Request(IHttpRequestContext context)
        {
            var options = context.RequestServices.GetRequiredService<IOptions<WeChatOptions>>().Value;

            WeChatPaySettings settings = null;
            if (string.IsNullOrWhiteSpace(Configuration.AppId))
            {
                var configuration = options.GetConfiguration(Configuration.Name);
                settings = configuration.Get<WeChatPaySettings>();

                Configuration.Configure(settings);
            }

            var endpoint = options.GetEndpoint(EndpointName);
            endpoint = EndpointHandler(endpoint);

            ContentHandler(context.Message);

            context.Message.Method = Method;
            context.Message.RequestUri = new Uri(endpoint);

           
            var  authorizationHandler = context.RequestServices.GetRequiredService<IWeChatPayAuthorizationHandler>();
            await authorizationHandler.Handler(context.Message, settings);
        }

        protected virtual string EndpointHandler(string endpoint)
        {
            return endpoint;
        }

        protected virtual void ContentHandler(HttpRequestMessage message)
        {
            if (Method.Equals(HttpMethod.Post))
            {
                message.Content = new StringContent(ToSerialize());
            }
        }

        public override async Task<TWeChatResponse> Response(IHttpResponseContext context)
        {
            var response =await base.Response(context);

            if (EnabledSignatureCheck)
            {
                var checker = context.RequestService.GetRequiredService<IWeChatPayResponseSignatureChecker>();
                await checker.Check(context.Message, Configuration.Get<WeChatPaySettings>());
            }

            return response;
        }
    }
}
