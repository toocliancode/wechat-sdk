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
        public override async Task Request(IHttpRequestContext context)
        {
            var options = context.RequestServices.GetRequiredService<IOptions<WeChatOptions>>().Value;

            if (string.IsNullOrWhiteSpace(Configuration.AppId))
            {
                var configuration = options.GetConfiguration(Configuration.Name);
                Configuration.Configure(configuration.AppId, configuration.Secret);
            }

            var endpoint = options.GetEndpoint(EndpointName);
            endpoint = EndpointHandler(endpoint);
            
            if (Method.Equals(HttpMethod.Post))
            {
                context.Message.Content = new StringContent(ToSerialize());
            }

            context.Message.Method = Method;
            context.Message.RequestUri = new Uri(endpoint);

            await AuthorizationHandler(context);
        }

        protected virtual async Task AuthorizationHandler(IHttpRequestContext context)
        {
            var token = await BuildAuthAsync(context.Message, Configuration.Get<WeChatPaySettings>());
            context.Message.Headers.Authorization = new AuthenticationHeaderValue("WECHATPAY2-SHA256-RSA2048", token);
            context.Message.Headers.UserAgent.Add(new ProductInfoHeaderValue(new ProductHeaderValue("Unknown")));
            context.Message.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        protected async Task<string> BuildAuthAsync(HttpRequestMessage request, WeChatPaySettings settings)
        {
            string method = request.Method.ToString();
            string body = "";
            if (method == "POST" || method == "PUT" || method == "PATCH")
            {
                var content = request.Content;
                body = await content.ReadAsStringAsync();
            }

            string uri = request.RequestUri.PathAndQuery;
            var timestamp = HttpUtility.GetTimeStamp();
            string nonce = HttpUtility.GenerateNonceStr();

            string message = $"{method}\n{uri}\n{timestamp}\n{nonce}\n{body}\n";
            string signature = Sign(settings.CertificateRSAPrivateKey, message);
            return $"mchid=\"{settings.MchId}\",nonce_str=\"{nonce}\",timestamp=\"{timestamp}\",serial_no=\"{settings.CertificateSerialNo}\",signature=\"{signature}\"";
        }

        protected string Sign(RSA rsa, string message)
        {
            // NOTE： 私钥不包括私钥文件起始的-----BEGIN PRIVATE KEY-----
            //        亦不包括结尾的-----END PRIVATE KEY-----
            byte[] data = System.Text.Encoding.UTF8.GetBytes(message);
            return Convert.ToBase64String(rsa.SignData(data, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1));
        }

        protected virtual string EndpointHandler(string endpoint)
        {
            return endpoint;
        }

        public override HttpClient CreateClient(IHttpClientCreateContext context) => context.HttpClientFactory.CreateClient(Configuration.Name);

        public override Task<TWeChatResponse> Response(IHttpResponseContext context)
        {
            return base.Response(context);
        }
    }
}
