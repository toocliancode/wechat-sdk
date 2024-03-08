
using Microsoft.Extensions.Options;

using System.Security.Cryptography.X509Certificates;

namespace WeChat.Pay;

/// <summary>
/// 【微信支付】JSAPI调起支付API 参数获取
/// 
///  <para>文档：<a href="https://pay.weixin.qq.com/wiki/doc/apiv3/wxpay/pay/transactions/chapter3_8.shtml"></a></para>
/// <para>接口最后更新时间：2023.06.13</para>
/// </summary>
public class TransactionsJsapiSdk
{
    public class Response
    {
        /// <summary>
        /// 实例化一个JSAPI调起支付API 参数获取
        /// </summary>
        public Response()
        {
        }

        /// <summary>
        /// JSAPI调起支付API 参数获取
        /// </summary>
        /// <param name="appId">应用Id</param>
        /// <param name="timeStamp">时间戳</param>
        /// <param name="nonceStr">随机字符串</param>
        /// <param name="package">订单详情扩展字符串</param>
        /// <param name="paySign">签名</param>
        /// <param name="signType">签名方式</param>
        public Response(
            string appId,
            string timeStamp,
            string nonceStr,
            string package,
            string paySign,
            string signType = "RSA")
        {
            AppId = appId;
            TimeStamp = timeStamp;
            NonceStr = nonceStr;
            Package = package;
            PaySign = paySign;
            SignType = signType;
        }

        /// <summary>
        /// 应用Id
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 时间戳
        /// </summary>
        public string TimeStamp { get; set; }

        /// <summary>
        /// 随机字符串
        /// </summary>
        public string NonceStr { get; set; }

        /// <summary>
        /// 订单详情扩展字符串
        /// </summary>
        public string Package { get; set; }

        /// <summary>
        /// 签名方式
        /// </summary>
        public string SignType { get; set; } = "RSA";

        /// <summary>
        /// 签名
        /// </summary>
        public string PaySign { get; set; }
    }

    /// <summary>
    /// 实例化一个 JSAPI调起支付API 参数获取
    /// </summary>
    /// <param name="prepayId">预支付交易会话Id</param>
    public class Request(string prepayId) : IRequest<Response>
    {
        /// <summary>
        /// 预支付交易会话Id
        /// </summary>
        public string PrepayId { get; } = prepayId;
    }

    public class Handler(IWeChatPayCertificateStore certificateStore, IOptions<WeChatPayOptions> options) : IRequestHandler<Request, Response>
    {
        protected IWeChatPayCertificateStore CertificateStore { get; } = certificateStore;
        protected WeChatPayOptions Options { get; } = options.Value;

        public Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            if (!CertificateStore.TryGet(Options, out var certificate2) ||
                certificate2 == null)
            {
                throw new WeChatException("JsapiSdk：获取证书失败");
            }
            var rsa = certificate2.GetRSAPrivateKey()!;

            var appId = Options.AppId;
            var timeStamp = HttpUtility.GetTimeStamp();
            var nonceStr = HttpUtility.GenerateNonceStr();
            var package = $"prepay_id={request.PrepayId}";
            var paySign = CryptographyExtensions.SHA256WithRSAEncrypt(rsa, $"{appId}\n{timeStamp}\n{nonceStr}\n{package}\n");

            return Task.FromResult(new Response(Options.AppId, timeStamp, nonceStr, package, paySign));
        }
    }

    /// <param name="prepayId">预支付交易会话Id</param>
    public static Request ToRequest(string prepayId) => new(prepayId);
}