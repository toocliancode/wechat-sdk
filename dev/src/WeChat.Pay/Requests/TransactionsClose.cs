namespace WeChat.Pay;

/// <summary>
/// 【微信支付】关闭订单
/// 
/// <para>文档：<a href="https://pay.weixin.qq.com/wiki/doc/apiv3/apis/chapter3_1_3.shtml"></a></para>
/// <para>接口最后更新时间：2020.05.26</para>
/// </summary>
public class TransactionsClose
{
    public static string Endpoint = "/v3/pay/transactions/out-trade-no/{out_trade_no}/close";

    public class Response : WeChatHttpResponse
    {
        public override bool IsSucceed()
        {
            return StatusCode == System.Net.HttpStatusCode.NoContent;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="outTradeNo">商户系统内部订单号</param>
    public class Request(string outTradeNo) : WeChatPayHttpRequest<Response>
    {
        /// <summary>
        /// 商户系统内部订单号
        /// </summary>
        public string OutTradeNo { get; set; } = outTradeNo;

        protected override Task InitializeRequestMessageAsync(IHttpRequestContext context)
        {
            var url = $"{WeChatPayProperties.Domain}{Endpoint}".Replace("{out_trade_no}", OutTradeNo);

            var dict = new Dictionary<string, string>()
            {
                ["mchid"] = Options.MchId
            };
            var content = WeChatSerializer.Serialize(dict);

            context.Message.Method = HttpMethod.Post;
            context.Message.RequestUri = new Uri(url);
            context.Message.Content = new StringContent(content, System.Text.Encoding.UTF8, "application/json");

            return Task.CompletedTask;
        }

        public override Task<Response> Response(IHttpResponseContext context)
        {
            var response = new Response()
            {
                StatusCode = context.Message.StatusCode,
            };

            return Task.FromResult(response);
        }
    }
}
