//using Mediation.HttpClient;

//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Options;

//namespace WeChat.Pay.Request;

//public abstract class WeChatPayHttpReqestBase<TWeChatResponse> : WeChatHttpRequestBase<TWeChatResponse>
//    where TWeChatResponse : WeChatResponseBase
//{
//    protected override WeChatConfiguration Configuration => base.Configuration.Configure("WeCahtPay");
//    protected override HttpMethod Method => HttpMethod.Post;

//    /// <summary>
//    /// 是否需要检查签名
//    /// </summary>
//    protected virtual bool EnabledSignatureCheck => true;

//    public override HttpClient CreateClient(IHttpClientCreateContext context) => context.HttpClientFactory.CreateClient(Configuration.Name);

//    public override async Task Request(IHttpRequestContext context)
//    {
//        var options = context.RequestServices.GetRequiredService<IOptions<WeChatOptions>>().Value;

//        WeChatPayOptions settings = null;
//        if (string.IsNullOrWhiteSpace(Configuration.AppId))
//        {
//            var configuration = options.GetConfiguration(Configuration.Name);
//            settings = configuration.Get<WeChatPayOptions>();

//            Configuration.Configure(settings);
//        }

//        ParameterHandler(settings);

//        var endpoint = options.GetEndpoint(EndpointName);
//        endpoint = EndpointHandler(endpoint);

//        ContentHandler(context.Message);

//        context.Message.Method = Method;
//        context.Message.RequestUri = new Uri(endpoint);


//        var authorizationHandler = context.RequestServices.GetRequiredService<IWeChatPayAuthorizationHandler>();
//        await authorizationHandler.Handle(context.Message, settings);
//    }

//    protected virtual string EndpointHandler(string endpoint)
//    {
//        return endpoint;
//    }

//    protected virtual void ParameterHandler(WeChatPayOptions settings)
//    {

//    }

//    protected virtual void ContentHandler(HttpRequestMessage message)
//    {
//        if (Method.Equals(HttpMethod.Post))
//        {
//            message.Content = new StringContent(ToSerialize());
//        }
//    }

//    public override async Task<TWeChatResponse> Response(IHttpResponseContext context)
//    {
//        if (EnabledSignatureCheck)
//        {
//            var checker = context.RequestService.GetRequiredService<IWeChatPayResponseSignatureChecker>();
//            await checker.Check(context.Message, Configuration.Get<WeChatPayOptions>());
//        }

//        return await base.Response(context);
//    }
//}
