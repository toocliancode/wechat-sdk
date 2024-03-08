namespace WeChat.Pay;

/// <summary>
/// 【微信支付】Native下单
/// 
/// <para>文档：<a href="https://pay.weixin.qq.com/wiki/doc/apiv3/wxpay/pay/transactions/chapter3_3.shtml"></a></para>
/// <para>接口最后更新时间：2022.09.05</para>
/// </summary>
public class TransactionsNative
{
    public static string Endpoint = "/v3/pay/transactions/native";

    public class Model : WeChatDictionary<object>
    {
        public Model()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="description">商品描述。</param>
        /// <param name="outTradeNo">商户订单号</param>
        /// <param name="amount">订单金额，单位分</param>
        public Model(string description, string outTradeNo, int amount)
        {
            Description = description;
            OutTradeNo = outTradeNo;

            Amount = new Amount(amount);
        }

        /// <summary>
        /// 商品描述。
        /// </summary>
        /// <remarks>
        /// 示例值：Image形象店-深圳腾大-QQ公仔
        /// </remarks>
        public string Description { get => GetValueOrDefault("description", string.Empty); set => this["description"] = value; }

        /// <summary>
        /// 商户订单号
        /// </summary>
        /// <remarks>
        /// <para>商户系统内部订单号，只能是数字、大小写字母_-*且在同一个商户号下唯一，详见【商户订单号】。</para>
        /// <para>特殊规则：最小字符长度为6</para>
        /// <para>示例值：1217752501201407033233368018</para>
        /// </remarks>
        public string OutTradeNo { get => GetValueOrDefault("out_trade_no", string.Empty); set => this["out_trade_no"] = value; }

        /// <summary>
        /// 交易结束时间
        /// </summary>
        public DateTimeOffset? TimeExpire { get => GetValueOrDefault<DateTimeOffset?>("time_expire", null); set => this["time_expire"] = value; }

        /// <summary>
        /// 附加数据
        /// </summary>
        public string? Attach { get => GetValueOrDefault<string?>("attach", null); set => this["attach"] = value; }

        /// <summary>
        /// 通知地址。
        /// </summary>
        /// <remarks>
        /// 不传则使用 <see cref="WeChatPayOptions.TransactionNotifyUrl"/>。
        /// </remarks>
        public string? NotifyUrl { get => GetValueOrDefault<string?>("notify_url", null); set => this["notify_url"] = value; }

        /// <summary>
        /// 订单优惠标记。
        /// </summary>
        public string? GoodsTag { get => GetValueOrDefault<string?>("goods_tag", null); set => this["goods_tag"] = value; }

        /// <summary>
        /// 电子发票入口开放标识
        /// </summary>
        public bool? SupportFapiao { get => GetValueOrDefault<bool?>("support_fapiao", null); set => this["support_fapiao"] = value; }

        /// <summary>
        /// 订单金额
        /// </summary>
        public Amount Amount { get => GetValueOrDefault<Amount>("amount", new()); set => this["amount"] = value; }

        /// <summary>
        /// 优惠功能
        /// </summary>
        public Detail? Detail { get => GetValueOrDefault<Detail?>("detail", null); set => this["detail"] = value; }

        /// <summary>
        /// 场景信息
        /// </summary>
        public SceneInfo? SceneInfo { get => GetValueOrDefault<SceneInfo?>("scene_info", null); set => this["scene_info"] = value; }

        /// <summary>
        /// 结算信息
        /// </summary>
        public SettleInfo? SettleInfo { get => GetValueOrDefault<SettleInfo?>("settle_info", null); set => this["settle_info"] = value; }
    }

    public class Response : WeChatHttpResponse
    {
        /// <summary>
        /// 二维码链接
        /// </summary>
        /// <remarks>
        /// <para>此URL用于生成支付二维码，然后提供给用户扫码支付。</para>
        /// <para>注意：code_url并非固定值，使用时按照URL格式转成二维码即可。</para>
        /// <para>示例值：weixin://wxpay/bizpayurl/up?pr=NwY5Mz9&amp;groupid=00</para>
        /// </remarks>
        [JsonPropertyName("code_url")]
        public string CodeUrl { get; set; }
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
            Model["appid"] = Options.AppId;
            Model["mchid"] = Options.MchId;

            Model.NotifyUrl ??= Options.TransactionNotifyUrl;

            var content = WeChatSerializer.Serialize(Model);

            context.Message.Method = HttpMethod.Post;
            context.Message.RequestUri = new Uri($"{WeChatPayProperties.Domain}{Endpoint}");
            context.Message.Content = new StringContent(content, System.Text.Encoding.UTF8, "application/json");

            return Task.CompletedTask;
        }
    }

    /// <param name="description">商品描述。</param>
    /// <param name="outTradeNo">商户订单号</param>
    /// <param name="amount">订单金额，单位分</param>
    public static Request ToRequest(string description, string outTradeNo, int amount)
        => new(new(description, outTradeNo, amount));
}