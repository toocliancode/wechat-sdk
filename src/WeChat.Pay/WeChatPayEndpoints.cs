namespace WeChat
{
    public static class WeChatPayEndpoints
    {
        /// <summary>
        /// 获取平台证书列表
        /// https://wechatpay-api.gitbook.io/wechatpay-api-v3/jie-kou-wen-dang/ping-tai-zheng-shu
        /// </summary>
        public const string Certificates = "CertificatesEndpoint";
        public const string CertificatesValue = "https://api.mch.weixin.qq.com/v3/certificates";

        /// <summary>
        /// APP下单API
        /// https://pay.weixin.qq.com/wiki/doc/apiv3/wxpay/pay/transactions/chapter3_1.shtml
        /// </summary>
        public const string TransactionsApp = "TransactionsAppEndpoint";
        public const string TransactionsAppValue = "https://api.mch.weixin.qq.com/v3/pay/transactions/app";

        /// <summary>
        /// JSAPI统一下单API
        /// https://pay.weixin.qq.com/wiki/doc/apiv3/wxpay/pay/transactions/chapter3_2.shtml
        /// </summary>
        public const string TransactionsJsapi = "TransactionsJsapiEndpoint";
        public const string TransactionsJsapiValue = "https://api.mch.weixin.qq.com/v3/pay/transactions/jsapi";

        /// <summary>
        /// Native下单API
        /// https://pay.weixin.qq.com/wiki/doc/apiv3/wxpay/pay/transactions/chapter3_3.shtml
        /// </summary>
        public const string TransactionsNative = "TransactionsNativeEndpoint";
        public const string TransactionsNativeValue = "https://api.mch.weixin.qq.com/v3/pay/transactions/native";

        /// <summary>
        /// H5下单API
        /// https://pay.weixin.qq.com/wiki/doc/apiv3/wxpay/pay/transactions/chapter3_4.shtml
        /// </summary>
        public const string TransactionsH5 = "TransactionsH5Endpoint";
        public const string TransactionsH5Value = "https://api.mch.weixin.qq.com/v3/pay/transactions/h5";

        /// <summary>
        /// 查询订单API - 微信支付订单号查询
        /// https://pay.weixin.qq.com/wiki/doc/apiv3/wxpay/pay/transactions/chapter3_5.shtml#menu1
        /// </summary>
        public const string TransactionsId = "TransactionsIdEndpoint";
        public const string TransactionsIdValue = "https://api.mch.weixin.qq.com/v3/pay/transactions/id/<transaction_id>?mchid=<mchid>";

        /// <summary>
        /// 查询订单API - 商户订单号查询
        /// https://pay.weixin.qq.com/wiki/doc/apiv3/wxpay/pay/transactions/chapter3_5.shtml#menu2
        /// </summary>
        public const string TransactionsOutTradeNo = "TransactionsOutTradeNoEndpoint";
        public const string TransactionsOutTradeNoValue = "https://api.mch.weixin.qq.com/v3/pay/transactions/out-trade-no/<out_trade_no>?mchid=<mchid>";

        /// <summary>
        /// 关单API
        /// https://pay.weixin.qq.com/wiki/doc/apiv3/wxpay/pay/transactions/chapter3_6.shtml
        /// </summary>
        public const string TransactionsOutTradeNoClose = "TransactionsOutTradeNoCloseEndpoint";
        public const string TransactionsOutTradeNoCloseValue = "https://api.mch.weixin.qq.com/v3/pay/transactions/out-trade-no/<out_trade_no>/close";
    }
}
