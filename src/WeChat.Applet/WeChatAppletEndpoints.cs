namespace WeChat.Applet
{
    public static class WeChatAppletEndpoints
    {
        /// <summary>
        /// 登录凭证校验。通过 wx.login 接口获得临时登录凭证 code 后传到开发者服务器调用此接口完成登录流程
        /// GET  https://api.weixin.qq.com/sns/jscode2session?appid=APPID&amp;secret=SECRET&amp;js_code=JSCODE&amp;grant_type=authorization_code
        /// </summary>
        public const string Code2Session = "Code2SessionEndpoint";

        public const string Code2SessionValue = "https://api.weixin.qq.com/sns/jscode2session";

        /// <summary>
        /// 获取小程序二维码端点名称 
        /// 适用于需要的码数量较少的业务场景。通过该接口生成的小程序码，永久有效，有数量限制
        /// POST https://api.weixin.qq.com/cgi-bin/wxaapp/createwxaqrcode?access_token=ACCESS_TOKEN
        /// </summary>
        public const string CreateQrCode = "CreateQrCodeEndpoint";

        public const string CreateQrCodeValue = "https://api.weixin.qq.com/cgi-bin/wxaapp/createwxaqrcode";

        /// <summary>
        /// 获取小程序码端点名称
        /// 适用于需要的码数量较少的业务场景。通过该接口生成的小程序码，永久有效，有数量限制。
        /// POST https://api.weixin.qq.com/wxa/getwxacode?access_token=ACCESS_TOKEN..
        /// </summary>
        public const string GetWxaCode = "GetWxaCodeEndpoint";

        public const string GetWxaCodeValue = "https://api.weixin.qq.com/wxa/getwxacode";

        /// <summary>
        /// 获取小程序码端点名称 
        /// 适用于需要的码数量极多的业务场景。通过该接口生成的小程序码，永久有效，数量暂无限制。 
        /// POST POST https://api.weixin.qq.com/wxa/getwxacodeunlimit?access_token=ACCESS_TOKEN
        /// </summary>
        public const string GetWxaCodeUnlimit = "GetWxaCodeUnlimitEndpoint";

        public const string GetWxaCodeUnlimitValue = "https://api.weixin.qq.com/wxa/getwxacodeunlimit";

        /// <summary>
        /// 发送订阅消息
        /// </summary>
        public const string SubscribeMessageSend = "SubscribeMessageSendEndpoint";

        public const string SubscribeMessageSendValue = "https://api.weixin.qq.com/cgi-bin/message/subscribe/send";
    }
}
