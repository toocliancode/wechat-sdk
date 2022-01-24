
using WeChat.Pay.Domain;

namespace WeChat.Pay;

/// <summary>
/// 统一下单
/// </summary>
public class WeChatPayUnifiedorderRequest
    : WeChatPayHttpRequest<WeChatPayUnifiedorderResponse>
    , IHasAppId
    , IHasMchId
    , IHasTransactionNotifyUrl
{
    private readonly string _type = "Jsapi";

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatPayUnifiedorderRequest"/>
    /// </summary>
    public WeChatPayUnifiedorderRequest()
    {

    }

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatPayUnifiedorderRequest"/>
    /// </summary>
    /// <param name="type">下单类型：App、Jsapi、Native、H5</param>
    public WeChatPayUnifiedorderRequest(string type = "Jsapi")
    {
        _type = type;
    }

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatPayUnifiedorderRequest"/>
    /// </summary>
    /// <param name="description">商品描述</param>
    /// <param name="outTradeNo">商户订单号</param>
    /// <param name="amountTotal">订单金额</param>
    /// <param name="payerOpenId">支付者openid,Jsapi 支付时使用</param>
    /// <param name="notifyUrl">通知地址，不传则使用 <see cref="WeChatPayOptions.TransactionNotifyUrl"/></param>
    /// <param name="type">下单类型：App、Jsapi、Native、H5</param>
    public WeChatPayUnifiedorderRequest(
        string description,
        string outTradeNo,
        int amountTotal,
        string? payerOpenId = default,
        string? notifyUrl = default,
        string type = "Jsapi")
    {
        Description = description;
        OutTradeNo = outTradeNo;
        NotifyUrl = notifyUrl ?? string.Empty;
        Amount = new Amount(amountTotal);
        if (payerOpenId != null)
        {
            Payer = new PayerInfo(payerOpenId);
        }
        _type = type;
    }

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatPayUnifiedorderRequest"/>
    /// </summary>
    /// <param name="description">商品描述</param>
    /// <param name="outTradeNo">商户订单号</param>
    /// <param name="amount">订单金额</param>
    /// <param name="payer">支付者,Jsapi 支付时使用</param>
    /// <param name="notifyUrl">通知地址，不传则使用 <see cref="WeChatPayOptions.TransactionNotifyUrl"/></param>
    /// <param name="appId">应用号，此处填写则使用自定义，不使用配置</param>
    /// <param name="mchId">商户号，此处填写则使用自定义，不使用配置</param>
    /// <param name="timeExpire">交易结束时间</param>
    /// <param name="attach">附加数据</param>
    /// <param name="goodsTag">订单优惠标记</param>
    /// <param name="detail">优惠功能</param>
    /// <param name="sceneInfo">场景信息</param>
    /// <param name="settleInfo">结算信息</param>
    /// <param name="type">下单类型：App、Jsapi、Native、H5</param>
    public WeChatPayUnifiedorderRequest(
        string description,
        string outTradeNo,
        Amount amount,
        PayerInfo? payer = default,
        string? notifyUrl = default,
        string? appId = default,
        string? mchId = default,
        DateTimeOffset? timeExpire = default,
        string? attach = default,
        string? goodsTag = default,
        Detail? detail = default,
        SceneInfo? sceneInfo = default,
        SettleInfo? settleInfo = default,
        string type = "Jsapi")
    {
        AppId = appId ?? string.Empty;
        MchId = mchId ?? string.Empty;
        Description = description;
        OutTradeNo = outTradeNo;
        TimeExpire = timeExpire;
        Attach = attach;
        NotifyUrl = notifyUrl ?? string.Empty;
        GoodsTag = goodsTag;
        Amount = amount;
        Payer = payer;
        Detail = detail;
        SceneInfo = sceneInfo;
        SettleInfo = settleInfo;
        _type = type;
    }

    /// <summary>
    /// 公众号ID
    /// 直连商户申请的公众号或移动应用appid。
    /// 示例值：wxd678efh567hg6787
    /// </summary>
    [JsonPropertyName("appid")]
    public string? AppId { get; set; }

    /// <summary>
    /// 直连商户号
    /// 直连商户的商户号，由微信支付生成并下发。
    /// 示例值：1230000109
    /// </summary>
    [JsonPropertyName("mchid")]
    public string? MchId { get; set; }

    /// <summary>
    /// 商品描述
    /// 示例值：Image形象店-深圳腾大-QQ公仔
    /// </summary>
    [JsonPropertyName("description")]
    public string Description { get; set; }

    /// <summary>
    /// 商户订单号
    /// 商户系统内部订单号，只能是数字、大小写字母_-*且在同一个商户号下唯一，详见【商户订单号】。
    /// 特殊规则：最小字符长度为6
    /// 示例值：1217752501201407033233368018
    /// </summary>
    [JsonPropertyName("out_trade_no")]
    public string OutTradeNo { get; set; }

    /// <summary>
    /// 交易结束时间
    /// 订单失效时间，遵循rfc3339标准格式，格式为YYYY-MM-DDTHH:mm:ss+TIMEZONE，YYYY-MM-DD表示年月日，
    /// T出现在字符串中，表示time元素的开头，HH:mm:ss表示时分秒，TIMEZONE表示时区（+08:00表示东八区时间，领先UTC 8小时，即北京时间）。
    /// 例如：2015-05-20T13:29:35+08:00表示，北京时间2015年5月20日 13点29分35秒。
    /// 示例值：2018-06-08T10:34:56+08:00
    /// </summary>
    [JsonPropertyName("time_expire")]
    public DateTimeOffset? TimeExpire { get; set; }

    /// <summary>
    /// 附加数据
    /// 附加数据，在查询API和支付通知中原样返回，可作为自定义参数使用
    /// 示例值：自定义数据
    /// </summary>
    [JsonPropertyName("attach")]
    public string? Attach { get; set; }

    /// <summary>
    /// 通知地址
    /// 通知URL必须为直接可访问的URL，不允许携带查询串。
    /// 格式：URL
    /// 示例值：https://www.weixin.qq.com/wxpay/pay.php
    /// </summary>
    [JsonPropertyName("notify_url")]
    public string NotifyUrl { get; set; }

    /// <summary>
    /// 订单优惠标记
    /// 订单优惠标记
    /// 示例值：WXG
    /// </summary>
    [JsonPropertyName("goods_tag")]
    public string? GoodsTag { get; set; }

    /// <summary>
    /// 订单金额
    /// </summary>
    [JsonPropertyName("amount")]
    public Amount Amount { get; set; }

    /// <summary>
    /// 支付者,Jsapi 支付时使用
    /// </summary>
    [JsonPropertyName("payer")]
    public PayerInfo? Payer { get; set; }

    /// <summary>
    /// 优惠功能
    /// </summary>
    [JsonPropertyName("detail")]
    public Detail? Detail { get; set; }

    /// <summary>
    /// 场景信息
    /// </summary>
    [JsonPropertyName("scene_info")]
    public SceneInfo? SceneInfo { get; set; }

    /// <summary>
    /// 结算信息
    /// </summary>
    [JsonPropertyName("settle_info")]
    public SettleInfo? SettleInfo { get; set; }

    protected override string GetRequestUri() => _type switch
    {
        "App" => WeChatPayTransactionsAppRequest.Endpoint,
        "Native" => WeChatPayTransactionsNativeRequest.Endpoint,
        "H5" => WeChatPayTransactionsH5Request.Endpoint,
        "Jsapi" or _ => WeChatPayTransactionsJsapiRequest.Endpoint,
    };
}
