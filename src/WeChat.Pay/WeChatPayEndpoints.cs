namespace WeChat
{
    public static class WeChatPayEndpoints
    {
        /// <summary>
        /// 获取平台证书列表
        /// </summary>
        public const string Certificates = "CertificatesEndpoint";
        public const string CertificatesValue = "https://api.mch.weixin.qq.com/v3/certificates";

        /// <summary>
        /// JSAPI 统一下单API
        /// https://pay.weixin.qq.com/wiki/doc/apiv3/apis/chapter3_1_1.shtml
        /// </summary>
        public const string PayTransactionsJsapi = "PayTransactionsJsapiEndpoint";
        public const string PayTransactionsJsapiValue = "https://api.mch.weixin.qq.com/v3/pay/transactions/jsapi";
    }
}
