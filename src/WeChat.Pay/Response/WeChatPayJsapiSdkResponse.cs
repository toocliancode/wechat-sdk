namespace WeChat.Pay.Response
{
    /// <summary>
    /// JSAPI调起支付API 参数获取
    /// https://pay.weixin.qq.com/wiki/doc/apiv3/wxpay/pay/transactions/chapter3_8.shtml
    /// </summary>
    public class WeChatPayJsapiSdkResponse
    {
        /// <summary>
        /// 实例化一个JSAPI调起支付API 参数获取
        /// </summary>
        public WeChatPayJsapiSdkResponse()
        {
        }

        /// <summary>
        /// JSAPI调起支付API 参数获取
        /// </summary>
        /// <param name="appId">应用Id</param>
        /// <param name="timeStamp">时间戳</param>
        /// <param name="nonceStr">随机字符串</param>
        /// <param name="package">订单详情扩展字符串</param>
        /// <param name="paySign">签名</param>
        /// <param name="signType">签名方式</param>
        public WeChatPayJsapiSdkResponse(
            string appId,
            string timeStamp,
            string nonceStr,
            string package,
            string paySign,
            string signType = "RSA")
        {
            AppId = appId;
            TimeStamp = timeStamp;
            NonceStr = nonceStr;
            Package = package;
            PaySign = paySign;
            SignType = signType;
        }

        /// <summary>
        /// 应用Id
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 时间戳
        /// </summary>
        public string TimeStamp { get; set; }

        /// <summary>
        /// 随机字符串
        /// </summary>
        public string NonceStr { get; set; }

        /// <summary>
        /// 订单详情扩展字符串
        /// </summary>
        public string Package { get; set; }

        /// <summary>
        /// 签名方式
        /// </summary>
        public string SignType { get; set; } = "RSA";

        /// <summary>
        /// 签名
        /// </summary>
        public string PaySign { get; set; }
    }

    /// <summary>
    /// App调起支付API 参数获取
    /// https://pay.weixin.qq.com/wiki/doc/apiv3/wxpay/pay/transactions/chapter3_7.shtml
    /// </summary>
    public class WeChatPayAppSdkResponse
    {
        /// <summary>
        /// 实例化一个App调起支付API 参数获取
        /// </summary>
        public WeChatPayAppSdkResponse()
        {
        }

        /// <summary>
        /// App调起支付API 参数获取
        /// </summary>
        /// <param name="appId">应用Id</param>
        /// <param name="partnerId">商户号</param>
        /// <param name="prepayId">预支付交易会话Id</param>
        /// <param name="timeStamp">时间戳</param>
        /// <param name="nonceStr">随机字符串</param>
        /// <param name="paySign">签名</param>
        /// <param name="package">订单详情扩展字符串</param>
        public WeChatPayAppSdkResponse(
            string appId,
            string partnerId,
            string prepayId,
            string timeStamp,
            string nonceStr,
            string paySign, 
            string package= "Sign=WXPay")
        {
            AppId = appId;
            PartnerId = partnerId;
            PrepayId = prepayId;
            TimeStamp = timeStamp;
            NonceStr = nonceStr;
            PaySign = paySign;
            Package = package;
        }

        /// <summary>
        /// 应用Id
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 商户号
        /// </summary>
        public string PartnerId { get; set; }

        /// <summary>
        /// 预支付交易会话Id
        /// </summary>
        public string PrepayId { get; set; }

        /// <summary>
        /// 订单详情扩展字符串
        /// </summary>
        public string Package { get; set; } = "Sign=WXPay";

        /// <summary>
        /// 时间戳
        /// </summary>
        public string TimeStamp { get; set; }

        /// <summary>
        /// 随机字符串
        /// </summary>
        public string NonceStr { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        public string PaySign { get; set; }
    }
}
