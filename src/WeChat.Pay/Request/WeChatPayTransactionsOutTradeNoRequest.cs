
using WeChat.Pay.Response;

namespace WeChat.Pay.Request
{
    /// <summary>
    /// 查询订单API - 商户订单号查询
    /// https://pay.weixin.qq.com/wiki/doc/apiv3/wxpay/pay/transactions/chapter3_5.shtml#menu2
    /// </summary>
    public class WeChatPayTransactionsOutTradeNoRequest : WeChatPayHttpReqestBase<WeChatPayTransactionsOutTradeNoResponse>
    {
        /// <summary>
        /// 实例化一个查询订单API - 商户订单号查询
        /// </summary>
        public WeChatPayTransactionsOutTradeNoRequest()
        {
        }

        /// <summary>
        /// 实例化一个查询订单API - 商户订单号查询
        /// </summary>
        /// <param name="outTradeNo">商户订单号</param>
        public WeChatPayTransactionsOutTradeNoRequest(string outTradeNo)
        {
            OutTradeNo = outTradeNo;
        }

        protected override string EndpointName => WeChatPayEndpoints.TransactionsOutTradeNo;

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
        public string OutTradeNo { get; set; }

        protected override void ParameterHandler(WeChatPayOptions settings)
        {
            MchId = settings.MchId;
        }

        protected override string EndpointHandler(string endpoint)
        {
            return endpoint
                           .Replace("<out_trade_no>", OutTradeNo)
                           .Replace("<mchid>", MchId);
        }
    }
}
