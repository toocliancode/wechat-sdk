using Microsoft.Extensions.Options;

using System.Security.Cryptography.X509Certificates;

namespace WeChat.Pay;

/// <summary>
/// 【微信支付】App调起支付API 参数获取
/// 
///  <para>文档：<a href="https://pay.weixin.qq.com/wiki/doc/apiv3/apis/chapter3_2_4.shtml"></a></para>
/// <para>接口最后更新时间：2020.09.29</para>
/// </summary>
public class TransactionsAppSdk
{
    public class Response
    {
        /// <summary>
        /// 实例化一个App调起支付API 参数获取
        /// </summary>
        public Response()
        {
        }

        /// <summary>
        /// App调起支付API 参数获取
        /// </summary>
        /// <param name="appId">应用Id</param>
        /// <param name="partnerId">商户号</param>
        /// <param name="prepayId">预支付交易会话Id</param>
        /// <param name="timeStamp">时间戳</param>
        /// <param name="nonceStr">随机字符串</param>
        /// <param name="paySign">签名</param>
        /// <param name="package">订单详情扩展字符串</param>
        public Response(
            string appId,
            string partnerId,
            string prepayId,
            string timeStamp,
            string nonceStr,
            string paySign,
            string package = "Sign=WXPay")
        {
            AppId = appId;
            PartnerId = partnerId;
            PrepayId = prepayId;
            TimeStamp = timeStamp;
            NonceStr = nonceStr;
            PaySign = paySign;
            Package = package;
        }

        /// <summary>
        /// 应用Id
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 商户号
        /// </summary>
        public string PartnerId { get; set; }

        /// <summary>
        /// 预支付交易会话Id
        /// </summary>
        public string PrepayId { get; set; }

        /// <summary>
        /// 订单详情扩展字符串
        /// </summary>
        public string Package { get; set; } = "Sign=WXPay";

        /// <summary>
        /// 时间戳
        /// </summary>
        public string TimeStamp { get; set; }

        /// <summary>
        /// 随机字符串
        /// </summary>
        public string NonceStr { get; set; }

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
            var mchid = Options.MchId;
            var timeStamp = HttpUtility.GetTimeStamp();
            var nonceStr = HttpUtility.GenerateNonceStr();
            var paySign = CryptographyExtensions.SHA256WithRSAEncrypt(rsa, $"{appId}\n{timeStamp}\n{nonceStr}\n{request.PrepayId}\n");

            return Task.FromResult(new Response(appId, mchid, request.PrepayId, timeStamp, nonceStr, paySign));
        }
    }
}