
using System.Text.Json.Serialization;

using WeChat.Pay.Close;

namespace WeChat.Pay;

/// <summary>
/// 关单API
/// https://pay.weixin.qq.com/wiki/doc/apiv3/wxpay/pay/transactions/chapter3_6.shtml
/// </summary>
public class WeChatPayTransactionsOutTradeNoCloseRequest
    : WeChatPayHttpRequest<WeChatPayTransactionsOutTradeNoCloseResponse>
    , IHasMchId
{
    public static string Endpoint = " https://api.mch.weixin.qq.com/v3/pay/transactions/out-trade-no/{out_trade_no}/close";

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatPayTransactionsOutTradeNoCloseRequest"/>
    /// </summary>
    public WeChatPayTransactionsOutTradeNoCloseRequest()
    {
    }

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatPayTransactionsOutTradeNoCloseRequest"/>
    /// </summary>
    /// <param name="outTradeNo">商户订单号</param>
    /// <param name="mchId">商户号，此处填写则使用自定义，不使用配置</param>
    public WeChatPayTransactionsOutTradeNoCloseRequest(
        string outTradeNo,
        string? mchId = default)
    {
        OutTradeNo = outTradeNo;
        MchId = mchId ?? string.Empty;
    }

    /// <summary>
    /// 直连商户号
    /// 直连商户的商户号，由微信支付生成并下发。
    /// 示例值：1230000109
    /// </summary>
    public string MchId { get; set; }

    /// <summary>
    /// 商户订单号
    /// 商户系统内部订单号，只能是数字、大小写字母_-*且在同一个商户号下唯一，详见【商户订单号】。
    /// 特殊规则：最小字符长度为6
    /// 示例值：1217752501201407033233368018
    /// </summary>
    [JsonIgnore]
    public string OutTradeNo { get; set; }

    protected override string GetRequestUri() => Endpoint.Replace("{out_trade_no}", OutTradeNo);
}
