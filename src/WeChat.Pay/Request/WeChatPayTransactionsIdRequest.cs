
using WeChat.Pay.Response;

namespace WeChat.Pay.Request
{
    /// <summary>
    /// 查询订单API - 微信支付订单号查询
    /// https://pay.weixin.qq.com/wiki/doc/apiv3/wxpay/pay/transactions/chapter3_5.shtml#menu1
    /// </summary>
    public class WeChatPayTransactionsIdRequest : WeChatPayHttpReqestBase<WeChatPayTransactionsIdResponse>
    {
        /// <summary>
        /// 实例化一个查询订单API - 微信支付订单号查询
        /// </summary>
        public WeChatPayTransactionsIdRequest()
        {
        }

        /// <summary>
        /// 实例化一个查询订单API - 微信支付订单号查询
        /// </summary>
        /// <param name="transactionId">微信支付订单号</param>
        public WeChatPayTransactionsIdRequest(string transactionId)
        {
            TransactionId = transactionId;
        }

        protected override string EndpointName => WeChatPayEndpoints.TransactionsId;

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

        protected override void ParameterHandler(WeChatPayOptions settings)
        {
            MchId = settings.MchId;
        }

        protected override string EndpointHandler(string endpoint)
        {
            return endpoint
                .Replace("<transaction_id>", TransactionId)
                .Replace("<mchid>", MchId);
        }
    }
}
