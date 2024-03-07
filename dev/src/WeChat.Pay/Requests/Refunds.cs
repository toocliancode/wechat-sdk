namespace WeChat.Pay;

#pragma warning disable CS8601

/// <summary>
/// 【微信支付】关闭订单
/// 
/// <para>文档：<a href="https://pay.weixin.qq.com/wiki/doc/apiv3/apis/chapter3_1_3.shtml"></a></para>
/// <para>接口最后更新时间：2022.08.29</para>
/// </summary>
public class Refunds
{
    public static string Endpoint = "/v3/refund/domestic/refunds";

    public class Model : WeChatDictionary<object>
    {
        public Model()
        {

        }

        /// <summary>
        /// 关闭订单
        /// </summary>
        /// <param name="transactionId">微信支付订单号</param>
        /// <param name="outTradeNo">商户订单号</param>
        /// <param name="outRefundNo">商户退款单号</param>
        /// <param name="amount">金额信息</param>
        /// <param name="reason">退款原因</param>
        /// <param name="notifyUrl">退款结果回调 url</param>
        /// <param name="fundsAccount">退款资金来源</param>
        public Model(
            string? transactionId,
            string? outTradeNo,
            string outRefundNo,
            RefundAmount amount,
            string? reason = default,
            string? notifyUrl = default,
            string? fundsAccount = default)
        {
            TransactionId = transactionId;
            OutTradeNo = outTradeNo;
            OutRefundNo = outRefundNo;
            Reason = reason;
            NotifyUrl = notifyUrl;
            FundsAccount = fundsAccount;
            Amount = amount;
        }

        /// <summary>
        /// 微信支付订单号
        /// </summary>
        /// <remarks>
        /// 原支付交易对应的微信订单号。
        /// <para>示例值：1217752501201407033233368018</para>
        /// </remarks>
        [JsonPropertyName("transaction_id")]
        public string? TransactionId { get => GetValueOrDefault<string?>("transaction_id", null); set => this["transaction_id"] = value; }

        /// <summary>
        /// 商户订单号
        /// </summary>
        /// <remarks>
        /// 原支付交易对应的商户订单号。
        /// <para>示例值：1217752501201407033233368018</para>
        /// </remarks>
        [JsonPropertyName("out_trade_no")]
        public string? OutTradeNo { get => GetValueOrDefault<string?>("out_trade_no", null); set => this["out_trade_no"] = value; }

        /// <summary>
        /// 商户退款单号
        /// </summary>
        /// <remarks>
        /// 商户系统内部的退款单号，商户系统内部唯一，只能是数字、大小写字母_-|*@ ，同一退款单号多次请求只退一笔。
        /// <para>示例值：1217752501201407033233368018</para>
        /// </remarks>
        [JsonPropertyName("out_refund_no")]
        public string OutRefundNo { get => GetValueOrDefault("out_refund_no", string.Empty); set => this["out_refund_no"] = value; }

        /// <summary>
        /// 退款原因
        /// </summary>
        /// <remarks>
        /// 若商户传入，会在下发给用户的退款消息中体现退款原因。
        /// <para>示例值：商品已售完</para>
        /// </remarks>
        [JsonPropertyName("reason")]
        public string? Reason { get => GetValueOrDefault<string?>("reason", null); set => this["reason"] = value; }

        /// <summary>
        /// 退款结果回调url
        /// </summary>
        /// <remarks>
        /// 异步接收微信支付退款结果通知的回调地址，通知url必须为外网可访问的url，不能携带参数。 如果参数中传了notify_url，则商户平台上配置的回调地址将不会生效，优先回调当前传的这个地址。
        /// <para>示例值：https://weixin.qq.com</para>
        /// </remarks>
        [JsonPropertyName("notify_url")]
        public string? NotifyUrl { get => GetValueOrDefault<string?>("notify_url", null); set => this["notify_url"] = value; }

        /// <summary>
        /// 退款资金来源
        /// </summary>
        /// <remarks>
        /// 若传递此参数则使用对应的资金账户退款，否则默认使用未结算资金退款（仅对老资金流商户适用）。
        /// 枚举值：
        /// AVAILABLE：可用余额账户
        /// <para>示例值：AVAILABLE</para>
        /// </remarks>
        [JsonPropertyName("funds_account")]
        public string? FundsAccount { get => GetValueOrDefault<string?>("funds_account", null); set => this["funds_account"] = value; }

        /// <summary>
        /// 金额信息
        /// </summary>
        /// <remarks>
        /// 订单金额信息。
        /// </remarks>
        [JsonPropertyName("amount")]
        public RefundAmount Amount { get => GetValueOrDefault<RefundAmount>("funds_account", new()); set => this["funds_account"] = value; }

        /// <summary>
        /// 退款商品
        /// </summary>
        /// <remarks>
        /// 指定商品退款需要传此参数，其他场景无需传递。
        /// </remarks>
        [JsonPropertyName("goods_detail")]
        public List<RefundGoodsDetail>? GoodsDetail { get => GetValueOrDefault<List<RefundGoodsDetail>?>("funds_account", null); set => this["funds_account"] = value; }
    }

    public class Response : WeChatHttpResponse
    {
        /// <summary>
        /// 微信支付退款单号
        /// </summary>
        [JsonPropertyName("refund_id")]
        public string RefundId { get; set; }

        /// <summary>
        /// 商户退款单号
        /// </summary>
        [JsonPropertyName("out_refund_no")]
        public string OutRefundNo { get; set; }

        /// <summary>
        /// 微信支付订单号
        /// 微信支付系统生成的订单号
        /// 示例值：1217752501201407033233368018
        /// </summary>
        [JsonPropertyName("transaction_id")]
        public string TransactionId { get; set; }

        /// <summary>
        /// 商户订单号
        /// 商户系统内部订单号，只能是数字、大小写字母_-*且在同一个商户号下唯一，详见【商户订单号】。
        /// 特殊规则：最小字符长度为6
        /// 示例值：1217752501201407033233368018
        /// </summary>
        [JsonPropertyName("out_trade_no")]
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 退款渠道
        /// </summary>
        /// <remarks>
        /// 枚举值：
        /// ORIGINAL：原路退款
        /// BALANCE：退回到余额
        /// OTHER_BALANCE：原账户异常退到其他余额账户
        /// OTHER_BANKCARD：原银行卡异常退到其他银行卡
        /// </remarks>
        [JsonPropertyName("channel")]
        public string Channel { get; set; }

        /// <summary>
        /// 退款入账账户
        /// </summary>
        /// <remarks>
        /// 取当前退款单的退款入账方，有以下几种情况：
        /// 1）退回银行卡：{银行名称
        /// }{卡类型}{ 卡尾号}
        /// 2）退回支付用户零钱: 支付用户零钱
        /// 3）退还商户: 商户基本账户商户结算银行账户
        /// 4）退回支付用户零钱通: 支付用户零钱通
        /// </remarks>
        [JsonPropertyName("user_received_account")]
        public string UserReceivedAccount { get; set; }

        /// <summary>
        /// 退款成功时间
        /// </summary>
        /// <remarks>
        /// 退款成功时间，当退款状态为退款成功时有返回。
        /// </remarks>
        /// <example>
        /// 示例值：2020-12-01T16:18:12+08:00
        /// </example>
        [JsonPropertyName("success_time")]
        public DateTimeOffset? SuccessTime { get; set; }

        /// <summary>
        /// 退款创建时间
        /// </summary>
        /// <remarks>
        /// 退款受理时间
        /// </remarks>
        /// <example>
        /// 示例值：2020-12-01T16:18:12+08:00
        /// </example>
        [JsonPropertyName("create_time")]
        public DateTimeOffset CreateTime { get; set; }

        /// <summary>
        /// 退款状态
        /// </summary>
        /// <remarks>
        /// 退款到银行发现用户的卡作废或者冻结了，导致原路退款银行卡失败，可前往商户平台-交易中心，手动处理此笔退款。
        /// 枚举值：
        /// SUCCESS：退款成功
        /// CLOSED：退款关闭
        /// PROCESSING：退款处理中
        /// ABNORMAL：退款异常
        /// 示例值：SUCCESS
        /// </remarks>
        [JsonPropertyName("status")]
        public string Status { get; set; }

        /// <summary>
        /// 资金账户
        /// </summary>
        /// <remarks>
        /// 退款所使用资金对应的资金账户类型
        /// 枚举值：
        /// UNSETTLED : 未结算资金
        /// AVAILABLE : 可用余额
        /// UNAVAILABLE : 不可用余额
        /// OPERATION : 运营户
        /// BASIC : 基本账户（含可用余额和不可用余额）
        /// 示例值：UNSETTLED
        /// </remarks>
        [JsonPropertyName("funds_account")]
        public string FundsAccount { get; set; }

        /// <summary>
        /// 金额信息
        /// </summary>
        /// <remarks>
        /// 金额详细信息。
        /// </remarks>
        [JsonPropertyName("amount")]
        public RefundAmountResponse Amount { get; set; }

        /// <summary>
        /// 优惠退款信息
        /// </summary>
        /// <remarks>
        /// 优惠退款信息。
        /// </remarks>
        [JsonPropertyName("promotion_detail")]
        public List<RefundPromotionDetail>? PromotionDetail { get; set; }
    }

    public class Request : WeChatPayHttpRequest<Response>
    {
        public Request()
        {

        }

        public Request(Model model)
        {
            Model = model;
        }

        public Model Model { get; set; }

        protected override Task InitializeRequestMessageAsync(IHttpRequestContext context)
        {
            Model.NotifyUrl ??= Options.RefundNotifyUrl;

            var content = WeChatSerializer.Serialize(Model);

            context.Message.Method = HttpMethod.Post;
            context.Message.RequestUri = new Uri($"{WeChatPayProperties.Domain}{Endpoint}");
            context.Message.Content = new StringContent(content, System.Text.Encoding.UTF8, "application/json");

            return Task.CompletedTask;
        }
    }
}
