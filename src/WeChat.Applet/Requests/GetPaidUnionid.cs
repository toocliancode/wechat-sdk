namespace WeChat.Applet;

/// <summary>
/// 【微信小程序】支付后获取 Unionid
/// 
/// <para>文档：<a href="https://developers.weixin.qq.com/miniprogram/dev/OpenApiDoc/user-info/basic-info/getPaidUnionid.html"></a></para>
/// </summary>
public class GetPaidUnionid
{
    public static string Endpoint = "/wxa/getpaidunionid?access_token={access_token}&openid={openid}&transaction_id={transaction_id}&mch_id={mch_id}&out_trade_no={out_trade_no}";

    public class Response : WeChatAppletHttpResponse
    {
        /// <summary>
        /// 用户唯一标识，调用成功后返回
        /// </summary>
        [JsonPropertyName("unionid")]
        public string Unionid { get; set; }
    }

    /// <param name="openid">支付用户唯一标识</param>
    /// <param name="mchId">微信支付分配的商户号，和商户订单号配合使用</param>
    /// <param name="transactionId">微信支付订单号</param>
    /// <param name="outTradeNo">微信支付商户订单号，和商户号配合使用</param>
    public class Request(
        string openid,
        string? transactionId = default,
        string? mchId = default,
        string? outTradeNo = default) :
        WeChatAppletHttpRequest<Response>
    {
        protected override async Task InitializeRequestMessageAsync(IHttpRequestContext context)
        {
            var token = await GetAccessTokenAsync();

            var url = $"{WeChatAppletProperties.Domain}{Endpoint}"
                .Replace("{access_token}", token)
                .Replace("{openid}", openid)
                .Replace("{transaction_id}", transactionId)
                .Replace("{mch_id}", mchId)
                .Replace("{out_trade_no}", outTradeNo)
                ;

            context.Message.Method = HttpMethod.Get;
            context.Message.RequestUri = new Uri(url);
        }
    }

    /// <param name="openid">支付用户唯一标识</param>
    /// <param name="mchId">微信支付分配的商户号，和商户订单号配合使用</param>
    /// <param name="transactionId">微信支付订单号</param>
    /// <param name="outTradeNo">微信支付商户订单号，和商户号配合使用</param>
    public static Request ToRequest(
        string openid,
        string? transactionId = default,
        string? mchId = default,
        string? outTradeNo = default)
        => new(openid, transactionId, mchId, outTradeNo);
}
