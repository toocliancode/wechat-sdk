namespace WeChat.Pay;

/// <summary>
/// 【微信支付】退款结果通知 - 响应解析内容
/// 
/// <para>文档：<a href="https://pay.weixin.qq.com/wiki/doc/apiv3/apis/chapter3_4_11.shtml"></a></para>
/// </summary>
[Serializable]
public class RefundNotifyResponse : NotifyResponse, INotification
{
    /// <summary>
    /// 商户号
    /// </summary>
    /// <remarks>
    /// 直连商户的商户号，由微信支付生成并下发。
    /// <para>示例值：1230000109</para>
    /// </remarks>
    [JsonPropertyName("mchid")]
    public string MchId { get; set; }

    /// <summary>
    /// 商户订单号
    /// </summary>
    /// <remarks>
    /// 商户系统内部订单号，只能是数字、大小写字母_-*且在同一个商户号下唯一，详见【商户订单号】。
    /// 特殊规则：最小字符长度为6
    /// <para>示例值：1217752501201407033233368018</para>
    /// </remarks>
    [JsonPropertyName("out_trade_no")]
    public string OutTradeNo { get; set; }

    /// <summary>
    /// 微信支付订单号
    /// </summary>
    /// <remarks>
    /// 微信支付系统生成的订单号。
    /// <para>示例值：1217752501201407033233368018</para>
    /// </remarks>
    [JsonPropertyName("transaction_id")]
    public string TransactionId { get; set; }

    /// <summary>
    /// 商户退款单号
    /// </summary>
    [JsonPropertyName("out_refund_no")]
    public string OutRefundNo { get; set; }

    /// <summary>
    /// 微信支付退款单号
    /// </summary>
    [JsonPropertyName("refund_id")]
    public string RefundId { get; set; }

    /// <summary>
    /// 退款状态	
    /// </summary>
    /// <remarks>
    /// 退款状态，枚举值：
    /// <code>SUCCESS：退款成功</code>
    /// <code>CLOSED：退款关闭</code>
    /// <code>ABNORMAL：退款异常，退款到银行发现用户的卡作废或者冻结了，导致原路退款银行卡失败，可前往【商户平台—>交易中心】，手动处理此笔退款</code>
    /// </remarks>
    [JsonPropertyName("refund_status")]
    public string RefundStatus { get; set; }

    /// <summary>
    /// 退款成功时间
    /// </summary>
    /// <remarks>
    /// <para>1、退款成功时间，遵循rfc3339标准格式，格式为yyyy-MM-DDTHH:mm:ss+TIMEZONE，yyyy-MM-DD表示年月日，T出现在字符串中，表示time元素的开头，HH:mm:ss表示时分秒，TIMEZONE表示时区（+08:00表示东八区时间，领先UTC 8小时，即北京时间）。例如：2015-05-20T13:29:35+08:00表示，北京时间2015年5月20日13点29分35秒。</para>
    /// <para>2、当退款状态为退款成功时返回此参数。</para>
    /// </remarks>
    [JsonPropertyName("success_time")]
    public DateTimeOffset? SuccessTime { get; set; }

    /// <summary>
    /// 退款入账账户
    /// </summary>
    /// <remarks>
    /// <para>取当前退款单的退款入账方。</para>
    /// <para>1、退回银行卡：{银行名称}{卡类型}{ 卡尾号}</para>
    /// <para>2、退回支付用户零钱: 支付用户零钱</para>
    /// <para>3、退还商户: 商户基本账户、商户结算银行账户</para>
    /// <para>4、退回支付用户零钱通：支付用户零钱通</para>
    /// </remarks>
    [JsonPropertyName("user_received_account")]
    public string UserReceivedAccount { get; set; }

    /// <summary>
    /// 金额信息
    /// </summary>
    [JsonPropertyName("amount")]
    public AmountInfo Amount { get; set; }

    public class AmountInfo
    {
        /// <summary>
        /// 订单金额
        /// </summary>
        /// <remarks>
        /// 订单总金额，单位为分，只能为整数，详见支付金额
        /// </remarks>
        [JsonPropertyName("total")]
        public int Total { get; set; }

        /// <summary>
        /// 退款金额
        /// </summary>
        /// <remarks>退款金额，币种的最小单位，只能为整数，不能超过原订单支付金额，如果有使用券，后台会按比例退。</remarks>
        [JsonPropertyName("refund")]
        public int Refund { get; set; }

        /// <summary>
        /// 用户支付金额
        /// </summary>
        /// <remarks>用户实际支付金额，单位为分，只能为整数，详见支付金额</remarks>
        [JsonPropertyName("payer_total")]
        public int PayerTotal { get; set; }

        /// <summary>
        /// 用户退款金额
        /// </summary>
        /// <remarks>退款给用户的金额，不包含所有优惠券金额</remarks>
        [JsonPropertyName("payer_refund")]
        public int PayerRefund { get; set; }
    }
}