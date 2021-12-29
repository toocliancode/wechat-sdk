
using System.Text.Json.Serialization;

using WeChat.Pay.Query;

namespace WeChat.Pay;

/// <summary>
/// 查询订单API - 微信支付订单号查询
/// https://pay.weixin.qq.com/wiki/doc/apiv3/wxpay/pay/transactions/chapter3_5.shtml#menu1
/// </summary>
public class WeChatPayTransactionsIdRequest
    : WeChatPayHttpRequest<WeChatPayTransactionsIdResponse>
    , IHasMchId
{
    public static string Endpoint = "https://api.mch.weixin.qq.com/v3/pay/transactions/id/{transaction_id}?mchid={mchid}";

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatPayTransactionsIdRequest"/>
    /// </summary>
    public WeChatPayTransactionsIdRequest()
    {
    }

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatPayTransactionsIdRequest"/>
    /// </summary>
    /// <param name="transactionId">微信支付订单号</param>
    /// <param name="mchId">商户号，此处填写则使用自定义，不使用配置</param>
    public WeChatPayTransactionsIdRequest(
        string transactionId,
        string? mchId = default)
    {
        TransactionId = transactionId;
        MchId = mchId ?? string.Empty;
    }

    /// <summary>
    /// 直连商户号
    /// 直连商户的商户号，由微信支付生成并下发。
    /// 示例值：1230000109
    /// </summary>
    public string MchId { get; set; }

    /// <summary>
    /// 微信支付订单号
    /// 微信支付系统生成的订单号
    /// 示例值：1217752501201407033233368018
    /// </summary>
    public string TransactionId { get; set; }

    [JsonIgnore]
    public override HttpMethod Method { get; set; } = HttpMethod.Get;

    protected override string GetRequestUri()
        => Endpoint
        .Replace("{transaction_id}", TransactionId)
        .Replace("{mchid}", MchId);
}
