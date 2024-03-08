namespace WeChat.Pay;

/// <summary>
/// 【微信支付】获取平台证书列表
/// 
/// <para>文档：<a href="https://wechatpay-api.gitbook.io/wechatpay-api-v3/jie-kou-wen-dang/ping-tai-zheng-shu"></a></para>
/// </summary>
public class PlatformCertificate
{
    public static string Endpoint = "/v3/certificates";

    public class Response : WeChatHttpResponse
    {
        [JsonPropertyName("data")]
        public List<CertificateInfo> Certificates { get; set; }
    }

    public class Request : WeChatPayHttpRequest<Response>
    {
        [JsonIgnore]
        protected override bool SignatureCheck => false;

        protected override Task InitializeRequestMessageAsync(IHttpRequestContext context)
        {
            var url = $"{WeChatPayProperties.Domain}{Endpoint}";

            context.Message.RequestUri = new(url);

            return Task.CompletedTask;
        }
    }

    public static Request ToRequest() => new();
}