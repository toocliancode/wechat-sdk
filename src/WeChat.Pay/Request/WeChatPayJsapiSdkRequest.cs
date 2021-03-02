﻿using Mediator.HttpClient;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

using WeChat.Pay.Response;

namespace WeChat.Pay.Request
{
    /// <summary>
    /// JSAPI调起支付API 参数获取
    /// https://pay.weixin.qq.com/wiki/doc/apiv3/wxpay/pay/transactions/chapter3_8.shtml
    /// </summary>
    public class WeChatPayJsapiSdkRequest : WeChatRequestBase<WeChatPayJsapiSdkResponse>
    {
        /// <summary>
        /// 实例化一个 JSAPI调起支付API 参数获取
        /// </summary>
        /// <param name="prepayId">预支付交易会话Id</param>
        public WeChatPayJsapiSdkRequest(string prepayId)
        {
            PrepayId = prepayId;
        }

        /// <summary>
        /// 预支付交易会话Id
        /// 微信返回的支付交易会话Id。
        /// 示例值： WX1217752501201407033233368018
        /// </summary>
        public string PrepayId { get; set; }

        protected override WeChatConfiguration Configuration => base.Configuration.Configure("WeChatPay");
        public override Task<WeChatPayJsapiSdkResponse> Handler(IWeChatRequetHandleContext context)
        {
            var options = context.RequestServices.GetRequiredService<IOptions<WeChatOptions>>().Value;

            WeChatPaySettings settings = null;
            if (string.IsNullOrWhiteSpace(Configuration.AppId))
            {
                var configuration = options.GetConfiguration(Configuration.Name);
                settings = configuration.Get<WeChatPaySettings>();

                Configuration.Configure(settings);
            }

            var certificateStore = context.RequestServices.GetRequiredService<IWeChatPayCertificateStore>();

            if (!certificateStore.TryGet(settings, out var certificate2))
            {
                throw new WeChatPayException("WeChatPayJsapiSdkRequest：获取证书失败");
            }
            var rsa = certificate2.GetRSAPrivateKey();

            var appId = settings.AppId;
            var timeStamp = HttpUtility.GetTimeStamp();
            var nonceStr = HttpUtility.GenerateNonceStr();
            var package = $"prepay_id={PrepayId}";
            var paySign = CryptographyExtensions.SHA256WithRSAEncrypt(rsa, $"{appId}\n{timeStamp}\n{nonceStr}\n{package}");

            return Task.FromResult(new WeChatPayJsapiSdkResponse(Configuration.AppId, timeStamp, nonceStr, package, paySign));
        }
    }
}
