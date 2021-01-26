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
            Func<IHttpRequestContext, Task> requestFactory,
            Func<IHttpResponseContext, Task<TWeChatResponse>> responseFactory)
        {
            RequestFactory = requestFactory;
            ResponseFactory = responseFactory;
        }

        public override Task Request(IHttpRequestContext context)
            => RequestFactory is null ? throw new ArgumentNullException(nameof(Request)) : Request(context);

        public override Task<TWeChatResponse> Response(IHttpResponseContext context)
            => ResponseFactory is null ? throw new ArgumentNullException(nameof(Response)) : Response(context);

        public Func<IHttpRequestContext, Task> RequestFactory { get; set; }

        public Func<IHttpResponseContext, Task<TWeChatResponse>> ResponseFactory { get; set; }
    }
}
