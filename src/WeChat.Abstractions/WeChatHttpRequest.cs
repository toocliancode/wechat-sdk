using Mediator.HttpClient;

using System;
using System.Threading.Tasks;

namespace WeChat
{
    /// <summary>
    /// 构建微信Http请求类
    /// </summary>
    /// <typeparam name="TWeChatResponse"></typeparam>
    public class WeChatHttpRequest<TWeChatResponse> : HttpRequestBase<TWeChatResponse>
    {
        public WeChatHttpRequest()
        {
        }

        public WeChatHttpRequest(
            Func<IHttpRequestContext, Task> request,
            Func<IHttpResponseContext, Task<TWeChatResponse>> response)
        {
            Request = request;
            Response = response;
        }

        public override Task CreateAsync(IHttpRequestContext context) 
            => Request is null ? throw new ArgumentNullException(nameof(Request)) : Request(context);

        public override Task<TWeChatResponse> ParserAsync(IHttpResponseContext context) 
            => Response is null ? throw new ArgumentNullException(nameof(Response)) : Response(context);

        public Func<IHttpRequestContext,Task> Request { get; set; }

        public Func<IHttpResponseContext,Task<TWeChatResponse>> Response { get; set; }
    }
}
