
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace WeChat.Pay;

public class Notify<TNotifyResponse> where TNotifyResponse : NotifyResponse
{
    public class Response
    {
        /// <summary>
        /// 通知明文内容
        /// </summary>
        [JsonIgnore]
        public string ResourcePlaintext { get; set; }
    }

    public class Request : IRequest<TNotifyResponse>
    {
        /// <summary>
        /// 通知ID
        /// </summary>
        /// <remarks>
        /// 通知的唯一ID
        /// <para>示例值：EV-2018022511223320873</para>
        /// </remarks>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// 通知创建时间
        /// </summary>
        /// <remarks>
        /// 通知创建的时间，格式为yyyyMMddHHmmss
        /// <para>示例值：20180225112233</para>
        /// </remarks>
        [JsonPropertyName("create_time")]
        public string CreateTime { get; set; }

        /// <summary>
        /// 通知类型
        /// </summary>
        /// <remarks>
        /// 通知的类型
        /// TRANSACTION.SUCCESS：支付成功
        /// REFUND.SUCCESS：退款成功通知
        /// REFUND.ABNORMAL：退款异常通知
        /// REFUND.CLOSED：退款关闭通知
        /// <para>示例值：TRANSACTION.SUCCESS</para>
        /// </remarks>
        [JsonPropertyName("event_type")]
        public string EventType { get; set; }

        /// <summary>
        /// 概要
        /// </summary>
        /// <remarks>
        /// <para>示例值：支付成功</para>
        /// </remarks>
        [JsonPropertyName("summary")]
        public string Summary { get; set; }

        /// <summary>
        /// 通知数据类型
        /// </summary>
        /// <remarks>
        /// 通知的资源数据类型，支付成功通知为encrypt-resource
        /// <para>示例值：encrypt-resource</para>
        /// </remarks>
        [JsonPropertyName("resource_type")]
        public string ResourceType { get; set; }

        /// <summary>
        /// 通知数据
        /// </summary>
        /// <remarks>
        /// 通知资源数据
        /// json格式，见示例
        /// </remarks>
        [JsonPropertyName("resource")]
        public Resource Resource { get; set; }
    }

    public class Handler(
        IOptions<WeChatPayOptions> options,
        IWeChatSerializer weChatSerializer,
        ILogger<Handler> logger) : IRequestHandler<Request, TNotifyResponse>
    {
        protected WeChatPayOptions Options { get; } = options.Value;

        protected IWeChatSerializer WeChatSerializer { get; } = weChatSerializer;
        protected ILogger<Handler> Logger { get; } = logger;

        public Task<TNotifyResponse> Handle(Request request, CancellationToken cancellationToken)
        {
            Logger.LogDebug("响应内容：{@request}", request);

            var resourcePlaintext = CryptographyExtensions.AesGcmDecrypt(request.Resource.Nonce, request.Resource.Ciphertext, request.Resource.AssociatedData, Options.V3Key);

            Logger.LogDebug("解析内容：{resourcePlaintext}", resourcePlaintext);

            var response = WeChatSerializer.Deserialize<TNotifyResponse>(resourcePlaintext);
            response.ResourcePlaintext = resourcePlaintext;

            return Task.FromResult(response);
        }
    }
}
