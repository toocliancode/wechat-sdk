using Mediation.HttpClient;

using Microsoft.Extensions.DependencyInjection;

using System.Security.Cryptography.X509Certificates;

using WeChat.Pay.App;

namespace WeChat.Pay;

#pragma warning disable 8604

/// <summary>
/// App调起支付API 参数获取
/// https://pay.weixin.qq.com/wiki/doc/apiv3/wxpay/pay/transactions/chapter3_8.shtml
/// </summary>
public class WeChatPayAppSdkRequest : WeChatPayRequest<WeChatPayAppSdkResponse>
{
    /// <summary>
    /// 实例化一个 JSAPI调起支付API 参数获取
    /// </summary>
    /// <param name="prepayId">预支付交易会话Id</param>
    public WeChatPayAppSdkRequest(string prepayId)
    {
        PrepayId = prepayId;
    }

    /// <summary>
    /// 预支付交易会话Id。
    /// 微信返回的支付交易会话Id。
    /// 示例值： WX1217752501201407033233368018
    /// </summary>
    public string PrepayId { get; set; }

    public override Task<WeChatPayAppSdkResponse> Handle(IWeChatRequetHandleContext context)
    {
        var certificateStore = context.RequestServices.GetRequiredService<IWeChatPayCertificateStore>();

        if (!certificateStore.TryGet(Options, out var certificate2) ||
            certificate2 == null)
        {
            throw new WeChatPayException("WeChatPayAppSdkRequest：获取证书失败");
        }
        var rsa = certificate2.GetRSAPrivateKey();

        var appId = Options.AppId;
        var mchid = Options.MchId;
        var timeStamp = HttpUtility.GetTimeStamp();
        var nonceStr = HttpUtility.GenerateNonceStr();
        var paySign = CryptographyExtensions.SHA256WithRSAEncrypt(rsa, $"{appId}\n{timeStamp}\n{nonceStr}\n{PrepayId}\n");

        return Task.FromResult(new WeChatPayAppSdkResponse(appId, mchid, PrepayId, timeStamp, nonceStr, paySign));
    }
}
