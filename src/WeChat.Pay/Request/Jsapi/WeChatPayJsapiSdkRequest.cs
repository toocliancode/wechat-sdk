using Mediation.HttpClient;

using Microsoft.Extensions.DependencyInjection;

using System.Security.Cryptography.X509Certificates;

using WeChat.Pay.Jsapi;

namespace WeChat.Pay;

#pragma warning disable 8604

/// <summary>
/// JSAPI调起支付API 参数获取
/// https://pay.weixin.qq.com/wiki/doc/apiv3/wxpay/pay/transactions/chapter3_8.shtml
/// </summary>
public class WeChatPayJsapiSdkRequest : WeChatPayRequest<WeChatPayJsapiSdkResponse>
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

    public override Task<WeChatPayJsapiSdkResponse> Handle(IWeChatRequetHandleContext context)
    {
        var certificateStore = context.RequestServices.GetRequiredService<IWeChatPayCertificateStore>();

        if (!certificateStore.TryGet(Options, out var certificate2) ||
            certificate2 == null)
        {
            throw new WeChatPayException("WeChatPayJsapiSdkRequest：获取证书失败");
        }
        var rsa = certificate2.GetRSAPrivateKey();

        var appId = Options.AppId;
        var timeStamp = HttpUtility.GetTimeStamp();
        var nonceStr = HttpUtility.GenerateNonceStr();
        var package = $"prepay_id={PrepayId}";
        var paySign = CryptographyExtensions.SHA256WithRSAEncrypt(rsa, $"{appId}\n{timeStamp}\n{nonceStr}\n{package}\n");

        return Task.FromResult(new WeChatPayJsapiSdkResponse(Options.AppId, timeStamp, nonceStr, package, paySign));
    }
}
