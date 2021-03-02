
using WeChat.Pay.Response;

namespace WeChat.Pay.Request
{
    /// <summary>
    /// 关单API
    /// https://pay.weixin.qq.com/wiki/doc/apiv3/wxpay/pay/transactions/chapter3_6.shtml
    /// </summary>
    public class WeChatPayTransactionsOutTradeNoCloseRequest : WeChatPayHttpReqestBase<WeChatPayTransactionsOutTradeNoCloseResponse>
    {
        /// <summary>
        /// 实例化一个关单API
        /// </summary>
        public WeChatPayTransactionsOutTradeNoCloseRequest()
        {
        }

        /// <summary>
        /// 实例化一个关单API
        /// </summary>
        /// <param name="outTradeNo">商户订单号</param>
        public WeChatPayTransactionsOutTradeNoCloseRequest(string outTradeNo)
        {
            OutTradeNo = outTradeNo;
        }

        protected override string EndpointName => WeChatPayEndpoints.TransactionsOutTradeNoClose;

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
        [System.Text.Json.Serialization.JsonIgnore]
        public string OutTradeNo { get; set; }

        protected override void ParameterHandler(WeChatPaySettings settings)
        {
            MchId = settings.MchId;
        }

        protected override string EndpointHandler(string endpoint)
        {
            return endpoint
                           .Replace("<out_trade_no>", OutTradeNo);
        }
    }
}
