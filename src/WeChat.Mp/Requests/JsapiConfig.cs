using Microsoft.Extensions.Options;

namespace WeChat.Mp;

/// <summary>
/// 【微信公众号】JS-SDK使用权限签名算法(微信jssdk配置)
/// 
/// <para>文档：<a href="https://developers.weixin.qq.com/doc/offiaccount/OA_Web_Apps/JS-SDK.html#62"></a></para>
/// </summary>
public class JsapiConfig
{
    /// <summary>
    /// 响应
    /// </summary>
    /// <param name="appId">应用号</param>
    /// <param name="timestamp">时间戳</param>
    /// <param name="nonceStr">随机字符串</param>
    /// <param name="signature">签名</param>
    public class Response(string appId, string timestamp, string nonceStr, string signature)
    {
        public string AppId { get; } = appId;
        public string Timestamp { get; } = timestamp;
        public string NonceStr { get; } = nonceStr;
        public string Signature { get; } = signature;
    }

    /// <summary>
    /// 请求
    /// </summary>
    /// <param name="url">调用 jsapi 页面链接地址</param>
    public class Request(string url) : IRequest<Response>
    {
        public string Url { get; } = url;

        public WeChatMpOptions? Options { get; private set; }

        public void WithOptions(WeChatMpOptions options)
        {
            Options = options;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="Url">调用 jsapi 页面链接地址</param>
    /// <returns><see cref="Request"/></returns>
    public static Request ToRequest(string Url) => new(Url);

    public class Handler(IWeChatMpTicketStore ticketStore, IOptions<WeChatMpOptions> optionAccessor) : IRequestHandler<Request, Response>
    {
        protected IWeChatMpTicketStore TicketStore { get; } = ticketStore;

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            var options = request.Options?? optionAccessor.Value;

            // 票据
            var ticket = await TicketStore.GetAsync(options);
            // 设置时间戳
            var timestamp = HttpUtility.GetTimeStamp();
            // 设置随机字符串
            var noncestr = HttpUtility.GenerateNonceStr();

            var dictionary = new SortedDictionary<string, string>()
            {
                {"jsapi_ticket",ticket },
                {"noncestr",noncestr },
                {"timestamp",timestamp },
                {"url",request.Url },
            };

            var response = new Response(options.AppId, timestamp, noncestr, WeChatSignature.Sign(dictionary, WeChatSignType.SHA1));

            return response;
        }
    }
}